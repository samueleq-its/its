package com.querio.service;

import java.util.List;

import com.querio.entity.Event;

public interface EventService {

	List<Event> getAll();

	Event getEventById(long id);

	Event saveEvent(Event e);

	Event updateEvent(Long id, Event e);

	void deleteEvent(long id);

}
