public class RaceThread extends Thread {

	private long time;

	public RaceThread(String nome, long time) {
		this.setName(nome);
		this.time = time;
	}

	@Override
	public void run() {
		for (int i = 0; i < 5; i++) {
			try {
				System.out.println(getName());
				System.out.println("ho percorso " + (i + 1) + "m");
				sleep(time);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
}
