package com.samuele;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

public class App {
    public static void main(String[] args) {
        runSelenium();
    }

    private static void runSelenium(int target) {
        WebDriver webDriver = new ChromeDriver();

        String webpage = "file:///c%3A/Users/samuele.querio/Documents/GitHub/its/Java/2026-2027/selenium/src/main/java/resources/guess-number.html";

        if (target != 0) {
            webDriver.get(webpage + "?target=" + target);
        } else {
            webDriver.get(webpage);
        }

        for (int i = 0; i <= 100; i++) {
            getElement(webDriver, String.valueOf(i));

            WebElement feedBackElement = webDriver.findElement(By.id("feedback"));
            if (feedBackElement.getText().startsWith("Esatto!")) {
                System.out.println("numero indovinato: " + i);
                break;
            } else {
                System.out.println("numero errato: " + i);
            }
        }

        webDriver.close();
    }

    private static void runSelenium() {
        runSelenium(0);
    }

    private static void getElement(WebDriver webDriver, String number) {
        WebElement element = webDriver.findElement(By.id("guess"));
        element.sendKeys(number);
        WebElement sendButton = webDriver.findElement(By.id("guess-button"));
        sendButton.click();
    }
}
