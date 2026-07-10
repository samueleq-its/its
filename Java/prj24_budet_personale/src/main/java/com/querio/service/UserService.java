package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.User;
import com.querio.repo.UserRepo;

@Service
public class UserService {

	private final UserRepo repo;

	public UserService(UserRepo repo) {
		this.repo = repo;
	}

	public List<User> getAll() {
		return repo.findAll();
	}

	public User getByEmail(String email) {
		return repo.findByEmail(email);
	}

}
