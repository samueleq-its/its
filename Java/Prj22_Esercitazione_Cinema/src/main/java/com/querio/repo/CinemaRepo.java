package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.Cinema;

public interface CinemaRepo extends JpaRepository<Cinema,Integer> {

}
