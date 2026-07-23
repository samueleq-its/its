package com.querio.service;

import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.springframework.stereotype.Service;

import com.querio.entity.Transaction;
import com.querio.entity.User;
import com.querio.enums.TransactionType;
import com.querio.repo.TransactionRepo;
import com.querio.repo.UserRepo;

@Service
public class TransactionServiceImpl implements TransactionService {

	private final TransactionRepo transactionRepo;
	private final UserRepo userRepo;

	public TransactionServiceImpl(TransactionRepo transactionRepo, UserRepo userRepo) {
		this.transactionRepo = transactionRepo;
		this.userRepo = userRepo;
	}

	public List<Transaction> getAll() {
		return transactionRepo.findAll();
	}

	public List<Transaction> getByUserId(long userId) {
		return transactionRepo
				.findAll()
				.stream()
				.filter(t -> t.getUser().getId() == userId)
				.toList();
	}

	public Transaction getById(long transId) {
		return transactionRepo.findById(transId).orElse(null);
	}

	public Transaction update(long transId, Transaction t) throws Exception {
		Transaction transaction = transactionRepo.findById(transId)
				.orElseThrow(() -> new Exception("transaction not found"));

		// set parametri non mofificabili
		t.setId(transaction.getId());
		t.setCreatedAt(transaction.getCreatedAt());
		t.setUser(transaction.getUser());
		t.setCreatedAt(transaction.getCreatedAt());
		return transactionRepo.save(t);
	}

	public Transaction create(Transaction t, long userId) throws Exception {
		User user = userRepo.findById(userId).orElseThrow(() -> new Exception("Utente non trovato"));
		t.setUser(user);
		t.setCreatedAt(LocalDateTime.now());
		return transactionRepo.save(t);
	}

	public void delete(long transId) {
		transactionRepo.deleteById(transId);
	}

	public Map<String, Object> getDashboarInfo(long userId) {
		Map<String, Object> dashboardData = new HashMap<>();

		List<Transaction> userTransactions = this.getByUserId(userId);

		// totale delle entrate;
		double entrate = userTransactions
				.stream()
				.filter(t -> t.getType() == TransactionType.ENTRATA)
				.mapToDouble(t -> t.getAmount())
				.sum();
		// totale delle uscite;
		double uscite = userTransactions
				.stream()
				.filter(t -> t.getType() == TransactionType.USCITA)
				.mapToDouble(t -> t.getAmount())
				.sum();
		// saldo totale;
		double totale = entrate - uscite;
		// spese suddivise per categoria;
		Map<String, Double> perCategoria = new HashMap<>();
		for (Transaction t : userTransactions) {
			String categoria = t.getCategory();
			double importo = t.getAmount();
			TransactionType tipo = t.getType();
			if (tipo == TransactionType.USCITA) {
				importo = -importo;
			}
			perCategoria.put(categoria, perCategoria.getOrDefault(categoria, 0.0) + importo);
		}
		// bilancio mensile
		double bilancioMensile = userTransactions
				.stream()
				.filter(t -> t.getDate().getMonth() == LocalDateTime.now().getMonth())
				.mapToDouble(t -> t.getType() == TransactionType.ENTRATA ? t.getAmount() : -t.getAmount())
				.sum();

		dashboardData.put("inflows", entrate);
		dashboardData.put("outflows", uscite);
		dashboardData.put("total", totale);
		dashboardData.put("perCategory", perCategoria);
		dashboardData.put("monthlyBalance", bilancioMensile);
		return dashboardData;
	}

}
