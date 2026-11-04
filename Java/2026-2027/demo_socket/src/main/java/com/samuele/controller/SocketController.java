package com.samuele.controller;

import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;

import com.samuele.service.SocketService;

@Controller
public class SocketController {

	private final SocketService service;

	public SocketController(SocketService service) {
		this.service = service;
	}

	@MessageMapping("/chat")
	@SendTo("/topic/messages")
	public String chat(String payload) {
		return service.process(payload);
	}
}
