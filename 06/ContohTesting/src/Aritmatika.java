/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author david
 */
public class Aritmatika {
	public int tambah(int angka1, int angka2) {
		return angka1 + angka2;
	}	

	public int kurang(int angka1, int angka2) {
		return angka1 - angka2;
	}

	public int kali(int angka1, int angka2) {
		return angka1 * angka2;
	}

	public double bagi(int angka1, int angka2){
		if (angka2 == 0) throw new ArithmeticException("Division by zero");
		return (double) angka1/angka2;		
	}
	
	public int pangkat(int angka1, int angka2) {
		int hasil = 1;
		for (int i = 0; i < angka2; i++) hasil *= angka1;
		return hasil;
	}
}
