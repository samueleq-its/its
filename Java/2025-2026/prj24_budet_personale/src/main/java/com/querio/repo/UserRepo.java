package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.User;

public interface UserRepo extends JpaRepository<User, Long> {
	User findByEmail(String email);
}
