package com.querio.controller;

import com.querio.entity.Transaction;
import com.querio.enums.TransactionType;
import com.querio.service.TransactionServiceImpl;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.Objects;
import java.util.UUID;

import java.util.List;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.io.Resource;
import org.springframework.core.io.UrlResource;
import org.springframework.http.ContentDisposition;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.util.StringUtils;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.multipart.MultipartFile;

@Controller
@RequestMapping("/transactions")
public class TransactionController {

	private final TransactionServiceImpl service;
	private final Path receiptStoragePath;
	private final String receiptUploadDir;

	public TransactionController(TransactionServiceImpl service,
			@Value("${app.receipts.upload-dir:uploads/receipts}") String receiptUploadDir) {
		this.service = service;
		this.receiptUploadDir = receiptUploadDir;
		this.receiptStoragePath = Paths.get(receiptUploadDir).toAbsolutePath().normalize();
		try {
			Files.createDirectories(this.receiptStoragePath);
		} catch (IOException e) {
			throw new IllegalStateException("Unable to create receipt upload directory", e);
		}
	}

	@GetMapping("")
	public String getTransactions(HttpSession session, Model model) {

		if (session.getAttribute("userId") != null) {
			model.addAttribute("loggedIn", true);
		}

		Long userId = (Long) session.getAttribute("userId");

		if (userId == null) {
			return "unauthorized";
		}

		List<Transaction> transactions = service.getByUserId(userId);

		model.addAttribute("title", "Transazioni");
		model.addAttribute("transactions", transactions);

		return "transactions";
	}

	@GetMapping("/{transId}")
	public String getTransactionDetails(HttpSession session, Model model, @PathVariable long transId) {

		Long userId = (Long) session.getAttribute("userId");
		Transaction transaction = service.getById(transId);

		// check se transazione esiste
		if (transaction == null) {
			return "redirect:/unauthorized";
		}

		// check user logged in
		if (userId == null) { // non autorizzato
			return "redirect:/unauthorized";
		}

		// check transaction di user
		if (transaction.getUser().getId() != userId) {
			return "redirect:/unauthorized";
		}

		model.addAttribute("title", "Dettagli Transazione");
		model.addAttribute("loggedIn", true);
		model.addAttribute(transaction);
		model.addAttribute("transactionTypes", TransactionType.values());
		return "transactionDetails";
	}

	@PostMapping("/{transId}")
	public String updateTransaction(HttpSession session, @PathVariable long transId, Transaction t,
			@RequestParam(name = "receiptFile", required = false) MultipartFile receiptFile,
			HttpServletRequest request) {

		Long userId = (Long) session.getAttribute("userId");
		Transaction transaction = service.getById(transId);

		// check richiesta valida
		if (userId == null) {
			return "redirect:/unauthorized";
		}
		if (transaction == null) {
			return "redirect:/unauthorized";
		}
		if (transaction.getUser().getId() != userId) {
			return "redirect:/unauthorized";
		}

		try {
			if (receiptFile != null && !receiptFile.isEmpty()) {
				t.setReceipt(saveReceipt(receiptFile));
			} else {
				t.setReceipt(transaction.getReceipt());
			}
			service.update(transId, t);
		} catch (Exception e) {
			return "redirect:/unauthorized";
		}

		return "redirect:" + request.getRequestURI();
	}

	@GetMapping("/{transId}/delete")
	public String deleteTransaction(HttpSession session, @PathVariable long transId) {

		Long userId = (Long) session.getAttribute("userId");
		Transaction transaction = service.getById(transId);

		// check richiesta valida
		if (userId == null) {
			return "redirect:/unauthorized";
		}
		if (transaction == null) {
			return "redirect:/unauthorized";
		}
		if (transaction.getUser().getId() != userId) {
			return "redirect:/unauthorized";
		}

		service.delete(transId);

		return "redirect:/transactions";
	}

	@GetMapping("/create")
	public String getCreate(HttpSession session, Model model) {

		Long userId = (Long) session.getAttribute("userId");

		// check richiesta valida
		if (userId == null) {
			return "redirect:/unauthorized";
		}

		model.addAttribute("title", "Nuova Transazione");
		model.addAttribute("loggedIn", true);
		model.addAttribute("userId", userId);
		model.addAttribute("transactionTypes", TransactionType.values());
		return "createTransaction";
	}

	@PostMapping("/create")
	public String create(HttpSession session, Transaction t,
			@RequestParam(name = "receiptFile", required = false) MultipartFile receiptFile) throws Exception {

		Long userId = (Long) session.getAttribute("userId");

		// check richiesta valida
		if (userId == null) {
			return "redirect:/unauthorized";
		}

		if (receiptFile != null && !receiptFile.isEmpty()) {
			t.setReceipt(saveReceipt(receiptFile));
		}

		service.create(t, userId);

		return "redirect:/transactions";
	}

	@GetMapping("/{transId}/receipt")
	public ResponseEntity<Resource> downloadReceipt(HttpSession session, @PathVariable long transId) throws Exception {
		Long userId = (Long) session.getAttribute("userId");
		Transaction transaction = service.getById(transId);

		if (userId == null || transaction == null || transaction.getUser().getId() != userId) {
			return ResponseEntity.status(403).build();
		}

		if (transaction.getReceipt() == null || transaction.getReceipt().isBlank()) {
			return ResponseEntity.notFound().build();
		}

		Path receiptPath = resolveStoredReceiptPath(transaction.getReceipt());
		if (!Files.exists(receiptPath) || !Files.isRegularFile(receiptPath)) {
			return ResponseEntity.notFound().build();
		}

		Resource resource = new UrlResource(receiptPath.toUri());
		String contentType = Files.probeContentType(receiptPath);
		if (contentType == null) {
			contentType = MediaType.APPLICATION_OCTET_STREAM_VALUE;
		}

		return ResponseEntity.ok()
				.contentType(MediaType.parseMediaType(contentType))
				.header(HttpHeaders.CONTENT_DISPOSITION,
						ContentDisposition.attachment().filename(receiptPath.getFileName().toString()).build()
								.toString())
				.body(resource);
	}

	private String saveReceipt(MultipartFile receiptFile) throws IOException {
		String originalFileName = StringUtils
				.cleanPath(Objects.requireNonNullElse(receiptFile.getOriginalFilename(), "receipt"));
		String extension = "";
		int extensionStartIndex = originalFileName.lastIndexOf('.');
		if (extensionStartIndex >= 0) {
			extension = originalFileName.substring(extensionStartIndex);
		}

		String storedFileName = UUID.randomUUID() + extension;
		Path targetPath = receiptStoragePath.resolve(storedFileName).normalize();
		if (!targetPath.startsWith(receiptStoragePath)) {
			throw new IOException("Invalid receipt path");
		}

		Files.copy(receiptFile.getInputStream(), targetPath, StandardCopyOption.REPLACE_EXISTING);
		return receiptUploadDir.replace("\\", "/") + "/" + storedFileName;
	}

	private Path resolveStoredReceiptPath(String storedReceiptPath) {
		Path relativePath = Paths.get(storedReceiptPath).normalize();
		if (relativePath.isAbsolute()) {
			return relativePath;
		}
		return Paths.get(".").toAbsolutePath().normalize().resolve(relativePath).normalize();
	}

	@GetMapping("/dashboard")
	public String getMethodName(HttpSession session, Model model) {

		Long userId = (Long) session.getAttribute("userId");

		// check richiesta valida
		if (userId == null) {
			return "redirect:/unauthorized";
		}
		model.addAttribute("data", service.getDashboarInfo(userId));
		return "dashboard";
	}

}

/*
 * TODO:
 * - categoria dovrebbe essere un enum
 * - allegati
 */
