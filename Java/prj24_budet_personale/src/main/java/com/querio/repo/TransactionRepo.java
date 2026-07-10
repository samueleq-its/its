package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.Transaction;

public interface TransactionRepo extends JpaRepository<Transaction, Long> {

}
