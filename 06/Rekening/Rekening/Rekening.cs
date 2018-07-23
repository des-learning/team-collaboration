using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekening
{
    public class Rekening
    {
        private const int SALDO_MINIMUM = 10000000;

        public string Nasabah { get; }

        public string Ktp { get; }

        public int Saldo { get; private set; }

        private Rekening(string nasabah, string ktp, int saldoAwal)
        {
            this.Nasabah = nasabah;
            this.Ktp = ktp;
            this.Saldo = saldoAwal;
        }

        public static Rekening create(string nasabah, string ktp, int saldoAwal)
        {
            if (!validateNasabah(nasabah) || !validateKtp(ktp) || !validateSaldoAwal(saldoAwal))
                throw new ArgumentException("Data rekening salah");
            return new Rekening(nasabah, ktp, saldoAwal);
        }

        private static bool validateNotEmptyAndNullString(string str)
        {
            return str != null && str.Trim() != "";
        }

        private static bool validateNasabah(string nasabah)
        {
            return validateNotEmptyAndNullString(nasabah);
        }

        private static bool validateKtp(string ktp)
        {
            return validateNotEmptyAndNullString(ktp);
        }

        private static bool validateSaldoAwal(int saldo)
        {
            return saldo >= SALDO_MINIMUM;
        }

        public int setor(int setoran)
        {
            this.Saldo += setoran;
            return this.Saldo;
        }

        public int tarik(int tarikan)
        {
            return 0;
        }

        public int transfer(int tranferan, Rekening dstRekening)
        {
            return 0;
        }
    }
}
