package curriculum;

public class EsercizioCurriculum {

	public static void main(String[] args) {
		Curriculum cv = new Curriculum("Umberto Eco");
		Curriculum.Job j1 = cv.addJob("Insegnante", 1980);
		Curriculum.Job j2 = cv.addJob("Scrittore", 1990);
		Curriculum.Job j3 = cv.addJob("Linguista", 2000);
		System.out.println(j2 .next()) ;
		System.out.println(j3 .next()) ;

	}

}
