package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.Event;

public interface EventRepo extends JpaRepository<Event, Long> {

}
