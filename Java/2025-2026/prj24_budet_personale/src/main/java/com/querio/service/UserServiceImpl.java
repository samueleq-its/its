package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.User;
import com.querio.repo.UserRepo;

// TODO: interfaccia
@Service
public class UserServiceImpl implements UserService {

	private final UserRepo repo;

	public UserServiceImpl(UserRepo repo) {
		this.repo = repo;
	}

	public List<User> getAll() {
		return repo.findAll();
	}

	public User getByEmail(String email) {
		return repo.findByEmail(email);
	}

	public User createUser(User user) {
		return repo.save(user);
	}

}
