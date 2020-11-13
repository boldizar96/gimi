using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas
{
    class Negyzet
    {
        private double a;
        public double kerulet()
        {
            double k = 4 * a;
            return k;
        }
        public double terulet()
        {
            double t = a * a; // Math.Pow(a,2);
            return t;
        }
        public void setOldal(double a)
        {
            this.a = a;
        }
        public double getOldal()
        {
            return a;
        }
    }
    class Macska
    {
        public string nev;
        public int szuliEv;
        public string gazda;
        public string[] oltasok;
        public int eletkor()
        {
            return DateTime.Now.Year - this.szuliEv;
        }
    }
    class Program
    {
        static void maximum(int elso, int masodik)
        {
            if (elso > masodik)
            {
                Console.WriteLine("A maximum: " + elso);
            }
            else
            {
                Console.WriteLine("A maximum: " + masodik);
            }
        }
        static int maximum2(int elso, int masodik)
        {
            if (elso>masodik)
            {
                return elso;
            }
            else
            {
                return masodik;
            }
        }
        static int maximum3(int[] tomb)
        {
            //int maxi = tomb[0];
            int index = 0;
            for (int i = 1; i < tomb.Length; i++)
            {
                if (tomb[i] > tomb[index])
                {
                    index = i;
                }
            }
            return index;
            //return maxi;
        }
        static int terulet(int r)
        {
            int t = 0;

            //

            return t;
        }
        static void Main(string[] args)
        {
			//Console.WriteLine("Kérlek adj meg egy egész számot!");
			//int egy = int.Parse(Console.ReadLine());
			//Console.WriteLine("Kérlek adj meg egy másik egész számot!");
			//int ketto = int.Parse(Console.ReadLine());

			////maximum(egy, ketto);
			//int maxi = maximum2(egy, ketto);
			//Console.WriteLine("A maximum: " + maxi);
			//Console.WriteLine("A maximum: {0}", maxi);

			//maximum2(3, 6);

			//int[] szamok = { 22, 456, 23476, 56, 1, 4344, 77, 891 };
			//int maxi = maximum3(szamok);
			//Console.WriteLine("A tömb elemei közül a maximum: {0}", szamok[maxi]);

			//Macska a = new Macska();
			//a.nev = "Cirmi";
			//a.szuliEv = 2010;
			//a.gazda = "Boldizsár";
			//a.oltasok = new string[] { "a", "b", "c" };

			//Console.WriteLine(a.nev);
			//Console.WriteLine(a.eletkor());

			//Negyzet n = new Negyzet();
			//n.setOldal(2);
			//Console.WriteLine("A négyzet oldaának hossza: " + n.getOldal());
			//Console.WriteLine("kerület {0}", n.kerulet()); 
			//Console.WriteLine("terület {0}", n.terulet());            
        }
    }
}
