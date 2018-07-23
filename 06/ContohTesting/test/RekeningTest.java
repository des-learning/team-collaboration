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
public class RekeningTest {
	
	public RekeningTest() {
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

	@Test
	public void testRekeningBaru() {
		Rekening baru = Rekening.create("budi", "0001", 12000000);
		assertEquals("budi", baru.getNasabah());
		assertEquals("0001", baru.getKtp());
		assertEquals(12000000, baru.getSaldo());
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruEmptyNasabah() {		
		Rekening.create("", "0001", 12000000);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruNullNasabah() {
		Rekening.create(null, "0001", 12000000);
	}

	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruEmptyKtp() {
		Rekening.create("budi", "", 12000000);
	}	
	
	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruNullKtp() {
		Rekening.create("budi", null, 12000000);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruSaldoAwalNol() {
		Rekening.create("budi", "0001", 0);
	}

	@Test(expected = IllegalArgumentException.class)
	public void testRekeningBaruSaldoAwalMinus() {
		Rekening.create("budi", "0001", -1);
	}
	
	@Test
	public void testSetorUang() {
		// saldo awal 10 juta
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		// setor 1 juta
		baru.setor(1000000);
		// saldo akhir seharusnya 11 juta
		assertEquals(11000000, baru.getSaldo());
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testSetorUangMinus() {		
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.setor(-1000000);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void  testSetorUangNol() {
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.setor(0);
	}
	
	@Test
	public void testTarikUang() {
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.tarik(1000000);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTarikNol() {	
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.tarik(0);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTarikMinus() {	
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.tarik(-1000000);
	}
	
	@Test
	public void testTarikSebanyakSaldo() {	
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.tarik(10000000);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTarikMelebihiSaldo() {	
		Rekening baru = Rekening.create("budi", "0001", 10000000);
		baru.tarik(10000001);
		assertEquals(0, baru.getSaldo());
	}
	
	@Test
	public void testTransfer() {        
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = 1000000;
            int saldoAkhirRek1 = 9000000;
            int saldoAkhirRek2 = 11000000;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);
	    
	    rek1.transfer(transferan, rek2);
	    assertEquals(saldoAkhirRek1, rek1.getSaldo());
            assertEquals(saldoAkhirRek2, rek2.getSaldo());
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTransferKeRekeningYangSama() {
		int saldoAwal = 10000000;
		int transferan = 1000000;
		Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
		
		rek1.transfer(transferan, rek1);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTransferNol() {        
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = 0;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);
	    
	    rek1.transfer(transferan, rek2);
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTransferMinus() {        
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = -1;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);
	    
	    rek1.transfer(transferan, rek2);
	}	
	
	@Test
	public void testTransferSebanyakSaldo() {        
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = saldoAwal;
            int saldoAkhirRek1 = 0;
            int saldoAkhirRek2 = saldoAwal + transferan;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);
	    
	    rek1.transfer(transferan, rek2);
	    assertEquals(saldoAkhirRek1, rek1.getSaldo());
            assertEquals(saldoAkhirRek2, rek2.getSaldo());
	}
	
	@Test(expected = IllegalArgumentException.class)
	public void testTransferMelebihiSaldo() {        
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = saldoAwal + 1;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);
	    
	    rek1.transfer(transferan, rek2);
	}
}
