package com.samuele.service;

import org.springframework.stereotype.Service;

import com.samuele.repo.SocketRepo;

@Service
public class SocketService {

	private final SocketRepo repo;

	public SocketService(SocketRepo repo) {
		this.repo = repo;
	}

	public String process(String payload) {

		repo.save(payload);

		try {
			Thread.sleep(3000);
		} catch (Exception e) {
		}

		return "response to " + payload;
	}

}
