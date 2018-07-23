/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author david
 */
public class AritmatikaTest {
	private Aritmatika instance;
	public AritmatikaTest() {
		instance = new Aritmatika();
	}
	
	@BeforeClass
	public static void setUpClass() {
		
	}
	
	@AfterClass
	public static void tearDownClass() {
	}
	
	@Before
	public void setUp() {
	}
	
	@After
	public void tearDown() {
	}

	/**
	 * Test of tambah method, of class Aritmatika.
	 */
	@Test
	public void testTambah() {
		System.out.println("tambah");
		/*int angka1 = 5;
		int angka2 = 2;		
		int expResult = 7;
		int result = instance.tambah(angka1, angka2);
		assertEquals(expResult, result);*/
		assertEquals(7, instance.tambah(5, 2));
	}

	/**
	 * Test of kurang method, of class Aritmatika.
	 */
	@Test
	public void testKurang() {
		System.out.println("kurang");
		int angka1 = 10;
		int angka2 = 3;		
		int expResult = 7;
		int result = instance.kurang(angka1, angka2);
		assertEquals(expResult, result);
	}

	/**
	 * Test of kali method, of class Aritmatika.
	 */
	@Test
	public void testKali() {
		System.out.println("kali");
		int angka1 = 3;
		int angka2 = 4;
		int expResult = 12;
		int result = instance.kali(angka1, angka2);
		assertEquals(expResult, result);
	}

	/**
	 * Test of bagi method, of class Aritmatika.
	 */
	@Test
	public void testBagi() {
		System.out.println("bagi");
		int angka1 = 5;
		int angka2 = 2;
		double expResult = 2.5;
		double result = instance.bagi(angka1, angka2);
		assertEquals(expResult, result, 0.0);		
	}
	
	@Test
	public void testTambahNegatif() {
		System.out.println("Tambah negatif");
		int angka1 = 7;
		int angka2 = -3;
		int expResult = 4;
		int result = instance.tambah(angka1, angka2);
		assertEquals(expResult, result);
	}
	
	@Test
	public void testPangkat() {
		System.out.println("pangkat");
		int angka1 = 3;
		int angka2 = 3;
		int expResult = 27;
		int result = instance.pangkat(angka1, angka2);
		assertEquals(expResult, result);		
	}
	
	@Test(expected = ArithmeticException.class)
	public void testBagiNol() {
		instance.bagi(10, 0);
	}
	
}
