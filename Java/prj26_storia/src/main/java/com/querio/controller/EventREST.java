package com.querio.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entity.Event;
import com.querio.service.EventService;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;

@RestController
@RequestMapping("/api/events")
public class EventREST {

	private final EventService eventService;

	public EventREST(EventService eventService) {
		this.eventService = eventService;
	}

	@GetMapping("")
	public ResponseEntity<List<Event>> getAll() {
		return ResponseEntity.ok(eventService.getAll());
	}

	@GetMapping("/{id}")
	public ResponseEntity<Event> getById(@PathVariable long id) {
		return ResponseEntity.ok(eventService.getEventById(id));
	}

	@GetMapping("/random")
	public ResponseEntity<Event> getRandom() {
		return ResponseEntity.ok(eventService.getRandom());
	}

	@PostMapping("")
	public ResponseEntity<Event> createEvent(@RequestBody Event e) {
		return ResponseEntity.ok(eventService.saveEvent(e));
	}

	@PostMapping("/many")
	public ResponseEntity<List<Event>> createManyEvents(@RequestBody List<Event> el) {
		for (Event e : el) {
			eventService.saveEvent(e);
		}
		return ResponseEntity.ok(eventService.getAll());
	}

	@PutMapping("/{id}")
	public ResponseEntity<Event> updateEvent(@PathVariable long id, @RequestBody Event e) {
		return ResponseEntity.ok(eventService.updateEvent(id, e));
	}

	@DeleteMapping("/{id}")
	public void deleteEvent(@PathVariable long id) {
		eventService.deleteEvent(id);
	}

}
