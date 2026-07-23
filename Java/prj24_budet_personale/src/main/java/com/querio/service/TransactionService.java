package com.querio.service;

import java.util.List;
import java.util.Map;

import com.querio.entity.Transaction;

/**
 * TransactionService
 */
public interface TransactionService {
	List<Transaction> getAll();

	List<Transaction> getByUserId(long userId);

	Transaction getById(long transId);

	Transaction update(long transId, Transaction t) throws Exception;

	Transaction create(Transaction t, long userId) throws Exception;

	void delete(long transId);

	Map<String, Object> getDashboarInfo(long userId);
}
