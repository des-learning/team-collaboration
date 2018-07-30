using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaAlat
{
    public class SewaAlat
    {
        private const double MASA_SEWA_MINIMUM = 4.0;
        private readonly double[] tarif = { 50_000.0, 60_000.0, 75_000.0 };

        public double HitungBiayaSewa(double masaSewa)
        {
            if (masaSewa <= 0.0) throw new ArgumentException("Masa sewa salah");
            if (masaSewa <= MASA_SEWA_MINIMUM)
            {
                return MASA_SEWA_MINIMUM * tarif[0];
            }
            if (masaSewa <= 8.0)
            {
                return masaSewa * tarif[0];
            }
            if (masaSewa <= 12.0)
            {
                return 8.0 * tarif[0] + (masaSewa - 8.0) * tarif[1];
            } else
            {
                return 8.0 * tarif[0] + 4.0 * tarif[1] + (masaSewa - 12.0) * tarif[2];
            }
        }
    }
}
