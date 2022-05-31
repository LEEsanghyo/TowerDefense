package com.shshsh.java.study01.server_study;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@RestController
public class ServerStudyApplication {

	public static void main(String[] args) {
		SpringApplication.run(ServerStudyApplication.class, args);
	}

	@GetMapping("/hello")
	public String hello(@RequestParam(value = "name", defaultValue = "world") String name) {
		String response = String.format("Hello %s", name);
		System.out.println("[hello] response_data : [" + response + "]");

		return response;
	}

}
