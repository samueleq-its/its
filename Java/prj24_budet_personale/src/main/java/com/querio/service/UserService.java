package com.querio.service;

import java.util.List;

import com.querio.entity.User;

/**
 * UserService
 */
public interface UserService {
	public List<User> getAll();

	public User getByEmail(String email);

	public User createUser(User user);

}
