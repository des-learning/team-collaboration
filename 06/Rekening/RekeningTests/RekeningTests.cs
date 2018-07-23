using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rekening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekening.Tests
{
    [TestClass()]
    public class RekeningTests
    {
        [TestMethod()]
        public void createTest()
        {
            // Test buat rekening baru dnegan data valid
            string nasabah = "budi";
            string ktp = "0001";
            int saldoAwal = 10000000;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);

            Assert.AreEqual(nasabah, rek.Nasabah);
            Assert.AreEqual(ktp, rek.Ktp);
            Assert.AreEqual(saldoAwal, rek.Saldo);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createEmptyNasabahTest()
        {
            // Test buat rekening baru dnegan data nasabah kosong
            string nasabah = "";
            string ktp = "0001";
            int saldoAwal = 10000000;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createNullNasabahTest()
        {
            // Test buat rekening baru dnegan data nasabah null
            string nasabah = null;
            string ktp = "0001";
            int saldoAwal = 10000000;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createEmptyKtpTest()
        {
            // Test buat rekening baru dnegan data ktp kosong
            string nasabah = "budi";
            string ktp = "";
            int saldoAwal = 10000000;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createNullKtpTest()
        {
            // Test buat rekening baru dnegan data ktp null
            string nasabah = "budi";
            string ktp = null;
            int saldoAwal = 10000000;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createSaldoAwalNolTest()
        {
            // Test buat rekening baru dnegan data saldoAwal 0
            string nasabah = "budi";
            string ktp = "0001";
            int saldoAwal = 0;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void createSaldoAwalMinusTest()
        {
            // Test buat rekening baru dnegan data saldoAwal minus
            string nasabah = "budi";
            string ktp = "0001";
            int saldoAwal = -1;
            Rekening rek = Rekening.create(nasabah, ktp, saldoAwal);
        }

        [TestMethod()]
        public void setorTest()
        {
            //Test setor ke rekening
            int saldoAwal = 10000000;
            int setoran = 1000000;
            int saldoAkhir = 11000000;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.setor(setoran);
            Assert.AreEqual(saldoAkhir, rek.Saldo);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void setorNolTest()
        {
            //Test setor ke rekening dengan jumlah setoran 0
            int saldoAwal = 10000000;
            int setoran = 0;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.setor(setoran);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void setorMinusTest()
        {
            //Test setor ke rekening dengan jumlah setoran Minus
            int saldoAwal = 10000000;
            int setoran = -1;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.setor(setoran);
        }

        [TestMethod()]
        public void tarikTest()
        {
            // test tarikan dari rekening
            int saldoAwal = 10000000;
            int tarikan = 1000000;
            int saldoAkhir = 9000000;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.tarik(tarikan);
            Assert.AreEqual(saldoAkhir, rek.Saldo);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void tarikNolTest()
        {
            // test tarikan dari rekening sejumlah 0
            int saldoAwal = 10000000;
            int tarikan = 0;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.tarik(tarikan);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void tarikMinusTest()
        {
            // test tarikan dari rekening dengan jumlah tarikan minus
            int saldoAwal = 10000000;
            int tarikan = -1;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.tarik(tarikan);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void tarikSebanyakSaldoTest()
        {
            // test tarikan dari rekening dengan jumlah tarikan sebesar saldo tersedia
            int saldoAwal = 10000000;
            int tarikan = saldoAwal;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.tarik(tarikan);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void tarikMelebihiSaldoTest()
        {
            // test tarikan dari rekening dengan jumlah tarikan lebih besar dari saldo tersedia
            int saldoAwal = 10000000;
            int tarikan = 10000001;
            Rekening rek = Rekening.create("budi", "0001", saldoAwal);

            rek.tarik(tarikan);
        }

        [TestMethod()]
        public void transferTest()
        {
            // test transfer antar rekening
            int saldoAwal = 10000000;
            int transferan = 1000000;
            int saldoAkhirRek1 = 9000000;
            int saldoAkhirRek2 = 11000000;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);

            rek1.transfer(transferan, rek2);
            Assert.AreEqual(saldoAkhirRek1, rek1.Saldo);
            Assert.AreEqual(saldoAkhirRek2, rek2.Saldo);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void transferKeRekeningYangSamaTest()
        {
            // test transfer antar rekening yang sama
            int saldoAwal = 10000000;
            int transferan = 1000000;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);

            rek1.transfer(transferan, rek1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void transferNolTest()
        {
            // test transfer antar rekening dengan jumlah transfer 0
            int saldoAwal = 10000000;
            int transferan = 0;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);

            rek1.transfer(transferan, rek2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void transferMinusTest()
        {
            // test transfer antar rekening dengan jumlah transfer Minus
            int saldoAwal = 10000000;
            int transferan = -1;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);

            rek1.transfer(transferan, rek2);
        }

        [TestMethod()]
        public void transferSebanyakSaldoTersediaTest()
        {
            // test transfer antar rekening dengan jumlah transfer sebanyak saldo tersedia
            int saldoAwal = 10000000;
            int transferan = saldoAwal;
            int saldoAkhirRek1 = 0;
            int saldoAkhirRek2 = 20000000;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);

            rek1.transfer(transferan, rek2);
            Assert.AreEqual(saldoAkhirRek1, rek1.Saldo);
            Assert.AreEqual(saldoAkhirRek2, rek2.Saldo);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void transferMelebihiSaldoTersediaTest()
        {
            // test transfer antar rekening dengan jumlah transfer melebihi saldo tersedia
            int saldoAwal = 10000000;
            int transferan = saldoAwal + 1;
            Rekening rek1 = Rekening.create("budi", "0001", saldoAwal);
            Rekening rek2 = Rekening.create("agus", "0002", saldoAwal);

            rek1.transfer(transferan, rek2);
        }
    }
}