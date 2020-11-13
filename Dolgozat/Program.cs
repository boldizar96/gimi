using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("1.feladat");
            //string nevem = "Boldizsár";
            //int jegy = 5;
            //Console.WriteLine("{0} programja vagyok, {1}-t szeretnék kapni.", nevem, jegy);
            //Console.WriteLine(nevem + " programja vagyok, " + jegy +"-t szeretnék kapni.");

            //Console.WriteLine("2. feladat");
            //Console.WriteLine("Hogy hívnak?");
            //string nev = Console.ReadLine();
            //Console.WriteLine("Hány éves vagy?");
            //int kor = int.Parse(Console.ReadLine());
            //if ((2020-kor) >= 2000)
            //{
            //    Console.WriteLine("{0} {1}-ban/ben született, ez a 21. évszázadban volt.", nev, (2020 - kor));
            //}
            //else
            //{
            //    Console.WriteLine("{0} {1}-ban/ben született, ez a 20. évszázadban volt.", nev, (2020 - kor));
            //}

            //Console.WriteLine("3.feladat");
            //for (int i = 1; i < 30; i = i + 3)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("4.feladat");
            //Console.WriteLine("Adj meg 5 számot!");
            //int[] szamok = new int[5];
            //int osszeg = 0;
            //for (int i = 0; i < szamok.Length; i++)
            //{
            //    szamok[i] = int.Parse(Console.ReadLine());

            //}
            //for (int i = 0; i < szamok.Length; i++)
            //{
            //    osszeg = osszeg + szamok[i];
            //}
            //Console.WriteLine(osszeg);


            Console.WriteLine("5.feladat");
            string[] diakok = { "Zsolt", "Csabi", "Tamás", "Ádám", "Luca", "Cintia", "Szandra", "Peti", "Zalán" };
            double[] jegyek = new double[diakok.Length];
            for (int i = 0; i < jegyek.Length; i++)
            {
                Console.WriteLine(diakok[i] + " hányast kapjon?");
                jegyek[i] = double.Parse(Console.ReadLine());
            }
            double osszeg = 0.0;
            for (int i = 0; i < jegyek.Length; i++)
            {
                Console.WriteLine(diakok[i] + " " + jegyek[i] + " kapott.");
                osszeg = osszeg + jegyek[i];
            }
            Console.WriteLine("Átlag: {0}", (osszeg/jegyek.Length));

        }
    }
}
