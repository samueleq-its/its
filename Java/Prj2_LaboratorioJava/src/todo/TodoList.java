package todo;

import java.util.Scanner;

public class TodoList {

    public static void main(String[] args) {

        creaTodo();
    }

    private static void creaTodo() {
        System.out.printf("Cosa vuoi fare?");
        Scanner in = new Scanner(System.in);
        String daFare = in.nextLine();
        Todo t1 = new Todo(daFare);
        System.out.println(t1);
    }
}
