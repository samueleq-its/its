package com.samuele.repo;

import org.springframework.stereotype.Repository;

@Repository
public class SocketRepo {

	public void save(String payload) {
		System.out.println(payload);
	}

}
