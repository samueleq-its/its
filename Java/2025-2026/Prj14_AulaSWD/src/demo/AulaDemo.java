package demo;

import controller.AulaController;
import repos.StudenteRepo;
import repos.StudenteRepoImp;

public class AulaDemo {
	public static void main(String[] args) {
		AulaController ctrl = new AulaController();
		
//		ctrl.faiAppello();
//		
//		ctrl.writeFile("documenti/assenti.txt", ctrl.getAssenti());
//		ctrl.writeFile("documenti/presenti.txt", ctrl.getPresenti());
		
		System.out.println(ctrl.interrogaStudente());
	}
}
