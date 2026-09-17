import java.time.Duration;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Hello, World!");

        Runnable task1 = new Runnable() {
            @Override
            public void run() {
                String threadName = Thread.currentThread().getName();
                System.out.println(threadName + " running");
                try {
                    Thread.sleep(5000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println(threadName + " finished");
            }
        };

        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<?> future = executor.submit(task1);

        future.get();

        executor.shutdown();

        System.out.println("main thread finished");

    }
}
