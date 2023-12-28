using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING.DB.Repos
{
    public class SaldoManager
    {
        public static int GetSaldo()
        {
            List<Nasabah> koleksiNasabah = Nasabah.GetAllWithUsername(login.LoggedUsername);

            int saldo = 0;
            foreach (var nasabah in koleksiNasabah)
            {
                saldo = nasabah.Saldo;
            }

            return saldo;
        }
    }
}
