using InversionControle.DAO;
using Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionControle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //instanciation statique
            /*DaoImpl daoImpl = new DaoImpl();
            MetierImpl metierImpl = new MetierImpl(daoImpl);
            Console.WriteLine(metierImpl.Calcul());
            //
            MetierImpl metier = new MetierImpl();
            metier.Dao = daoImpl;
            Console.WriteLine("________________");
            Console.WriteLine(metierImpl.Calcul());*/
            Console.WriteLine("INSTANCIATION DYNMAIQUE ");
            //instanciation dynamique utilisation lire line par line
            String[] data = File.ReadAllLines("config.txt");
            String daoClassName1 = data[0];
            String MetierClassName1 = data[1];
           /* StreamReader streamReader = new StreamReader("config.txt");
            String daoClassName = streamReader.ReadLine();
            String MetierClassName = streamReader.ReadLine();
            Console.WriteLine("CASS NAME DAO "+daoClassName);
            Console.WriteLine("CASS NAME Metier "+ MetierClassName);*/
            //instancier dynmaquement les class objet type equivant de Class en java
            Type typeDao = Type.GetType(daoClassName1);
            Console.WriteLine("type dao "+typeDao);
            IDao dao = (IDao)Activator.CreateInstance(typeDao);
            Type typeMetier = Type.GetType(MetierClassName1);
            IMetier metierDynamic = (IMetier)Activator.CreateInstance(typeMetier,dao);
            Console.WriteLine("resultat avec instanciaition dynmaique" + metierDynamic.Calcul());
            // creation du conainer
            //var services = new ServiceCollection();
            //ajout des instances au container
            //services.addSingelto<IDao, DaoImpl>()
            //services.addSingelto<IMetier,MetierImpl>()
            //Recuperer une instance ISERVICEPRODIVDER

            //IServiceProvider provider=services.BuildServiceProvider()
            //recuperation de l'objet qui implemente l'interface
            //IMetier metier=provider.getServic<IMetier>()
            //console.WriteLine(metier.calcul()

            Console.ReadKey();
        }
    }
}
