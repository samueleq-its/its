package curriculum;

import java.util.ArrayList;
import java.util.List;

public class Curriculum {

	private String nome;
	private List<Job> lavori = new ArrayList<Curriculum.Job>();

	public Curriculum(String nome) {
		super();
		this.nome = nome;
	}

	public Job addJob(String nomeLavoro, int data) {
		Job j = new Job(this, nomeLavoro, data);
		lavori.add(j);
		return j;
	}

	public class Job {

		private Curriculum cv;
		private String nomeLavoro;
		private int data;

		public Job(Curriculum cv, String nomeLavoro, int data) {
			this.cv = cv;
			this.nomeLavoro = nomeLavoro;
			this.data = data;
		}

		public String getNomeLavoro() {
			return nomeLavoro;
		}

		public int getData() {
			return data;
		}

		public Job next() {
			try {
				int i = lavori.indexOf(this);
				return lavori.get(i + 1);
			} catch (Exception e) {
				return null;
			}
		}
		
		@Override
		public String toString() {
			return this.nomeLavoro + ": " + this.data;
		}
	}
}