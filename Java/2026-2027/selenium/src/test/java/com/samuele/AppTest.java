package com.samuele;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

public class AppTest {
    private static final String webpage = "file:///c%3A/Users/samuele.querio/Documents/GitHub/its/Java/2026-2027/selenium/src/main/java/resources/guess-number.html";
    private WebDriver webDriver;

    @BeforeEach
    public void init() {
        webDriver = new ChromeDriver();
    }

    @Test
    public void correctNumberGivesSuccess() {
        webDriver.get(webpage + "?target=42");

        WebElement element = webDriver.findElement(By.id("guess"));
        element.sendKeys("42");
        WebElement sendButton = webDriver.findElement(By.id("guess-button"));
        sendButton.click();

        WebElement feedBackElement = webDriver.findElement(By.id("feedback"));

        assertTrue(feedBackElement.getText().startsWith("Esatto!"));
    }

    @Test
    public void wrongNumberDoesntGiveSuccess() {
        webDriver.get(webpage + "?target=42");

        WebElement element = webDriver.findElement(By.id("guess"));
        element.sendKeys("41");
        WebElement sendButton = webDriver.findElement(By.id("guess-button"));
        sendButton.click();

        WebElement feedBackElement = webDriver.findElement(By.id("feedback"));

        assertFalse(feedBackElement.getText().startsWith("Esatto!"));
    }

    @Test
    public void smallerNumberGivesTooSmall() {
        webDriver.get(webpage + "?target=42");

        WebElement element = webDriver.findElement(By.id("guess"));
        element.sendKeys("41");
        WebElement sendButton = webDriver.findElement(By.id("guess-button"));
        sendButton.click();

        WebElement feedBackElement = webDriver.findElement(By.id("feedback"));

        assertTrue(feedBackElement.getText().startsWith("Troppo basso!"));
    }

    @Test
    public void biggerNumberGivesTooBig() {
        webDriver.get(webpage + "?target=42");

        WebElement element = webDriver.findElement(By.id("guess"));
        element.sendKeys("43");
        WebElement sendButton = webDriver.findElement(By.id("guess-button"));
        sendButton.click();

        WebElement feedBackElement = webDriver.findElement(By.id("feedback"));

        assertTrue(feedBackElement.getText().startsWith("Troppo alto!"));
    }
}
