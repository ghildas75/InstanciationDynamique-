using InversionControle.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Metier
{
    public class MetierImpl : IMetier
    {
        public IDao Dao { get; set; }

        public MetierImpl(IDao dao)
        {
            Dao = dao;
        }

        public MetierImpl()
        {
        }

        public double Calcul()
        {
            double data = Dao.GetValue();
            return data * 100;
        }
    }
}
