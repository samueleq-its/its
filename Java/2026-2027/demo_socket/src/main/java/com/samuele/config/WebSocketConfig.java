package com.samuele.config;

import org.springframework.context.annotation.Configuration;
import org.springframework.messaging.simp.config.MessageBrokerRegistry;
import org.springframework.web.socket.config.annotation.EnableWebSocketMessageBroker;
import org.springframework.web.socket.config.annotation.StompEndpointRegistry;
import org.springframework.web.socket.config.annotation.WebSocketMessageBrokerConfigurer;

@Configuration
@EnableWebSocketMessageBroker
public class WebSocketConfig implements WebSocketMessageBrokerConfigurer {

	@Override
	public void registerStompEndpoints(StompEndpointRegistry registry) {
		registry.addEndpoint("/ws");
	}

	@Override
	public void configureMessageBroker(MessageBrokerRegistry registry) {
		// Messages sent here are handled by @MessageMapping methods
		registry.setApplicationDestinationPrefixes("/app");

		// Messages sent here are handled by the simple broker
		registry.enableSimpleBroker("/topic", "/queue");

		// Enables /user/queue/... destinations
		registry.setUserDestinationPrefix("/user");
	}
}