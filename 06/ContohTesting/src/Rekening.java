/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author david
 */

public class Rekening {
	private String nasabah;
	private String ktp;
	private int saldo;
	private final static int SALDO_AWAL = 10000000;	
	
	private Rekening(String nasabah, String ktp, int saldoAwal) {
		this.nasabah = nasabah;
		this.ktp = ktp;
		this.saldo = saldoAwal;
	}
	public static Rekening create(String nasabah, String ktp, int saldoAwal) {
		if (!validateNasabah(nasabah) ||
		    !validateKtp(ktp) || !validateSaldoAwal(saldoAwal) ) {
			throw new IllegalArgumentException("Argument salah");
		}
		return new Rekening(nasabah, ktp, saldoAwal);
	}
	
	/**
	 * memvalidasi string, string tidak boleh null dan kosong ("")
	 * @param s - string yang akan divalidasi
	 * @return true jika sitrng tidak null dan tidak kosong (""), false sebaliknya
	 */
	private static boolean validateStringNotEmpty(String s) {
		return (s != null && !s.trim().equals(""));
	}
	
	private static boolean validateNasabah(String nasabah) {
		return validateStringNotEmpty(nasabah);
	}
	
	private static boolean validateKtp(String ktp) {
		return validateStringNotEmpty(ktp);
	}
	
	/**
	 * memvalidasi saldo awal, saldo harus >= SALDO_AWAL
	 * @param saldo - saldo awal
	 * @return true jika saldo valid, false jika tidak
	 */
	private static boolean validateSaldoAwal(int saldo) {
		return saldo >= SALDO_AWAL;
	}

	public String getNasabah() {
		return nasabah;
	}

	public String getKtp() {
		return ktp;
	}

	public int getSaldo() {
		return saldo;
	}
	
	public int setor(int setoran) {
		return 0;
	}
	
	public int tarik(int jumlah) {
		return 0;
	}
	
	public int transfer(int jumlah, Rekening rekTujuan) {
		return 0;
	}
}
