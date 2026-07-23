package com.querio.service;

import java.util.Collection;
import java.util.Collections;
import java.util.List;

import org.jspecify.annotations.Nullable;
import org.springframework.stereotype.Service;
import org.thymeleaf.expression.Lists;

import com.querio.entity.Event;
import com.querio.repo.EventRepo;

@Service
public class EventService implements IEventService {

	private final EventRepo eventRepo;

	public EventService(EventRepo eventRepo) {
		this.eventRepo = eventRepo;
	}

	@Override
	public List<Event> getAll() {
		return eventRepo.findAll();
	}

	@Override
	public Event getEventById(long id) {
		return eventRepo
				.findById(id)
				.orElseThrow(() -> new RuntimeException("event not found"));
	}

	@Override
	public Event saveEvent(Event e) {
		e.setId(0);
		return eventRepo.save(e);
	}

	@Override
	public Event updateEvent(Long id, Event e) {
		eventRepo.findById(id)
				.map(found -> {
					e.setId(id);
					return eventRepo.save(e);
				})
				.orElseThrow(() -> new RuntimeException("event not found"));
		return eventRepo.save(e);
	}

	@Override
	public void deleteEvent(long id) {
		eventRepo.deleteById(id);
	}

	public Event getRandom() {
		var events = eventRepo.findAll();
		Collections.shuffle(events);
		return events.getFirst();
	}

}
