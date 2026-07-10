package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.Transaction;
import com.querio.repo.TransactionRepo;

@Service
public class TransactionService {

	private final TransactionRepo repo;

	public TransactionService(TransactionRepo repo) {
		this.repo = repo;
	}

	public List<Transaction> getAll() {
		return repo.findAll();
	}

	public List<Transaction> getByUserId(long userId) {
		return repo
				.findAll()
				.stream()
				.filter(t -> t.getUser().getId() == userId)
				.toList();
	}

	public Transaction getById(long transId) {
		return repo.findById(transId).orElse(null);
	}

}
