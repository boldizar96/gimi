using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FajlBeolvasas
{
    class Sorozat
    {
        public string datum;
        public string cim;
        public string epizodSzam;
        public int hossz;
        public int megnezve;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string eleresiUt = @"lista.txt";
            if (File.Exists(eleresiUt))
            {
                Console.WriteLine("A fájl létezik, be lehet olvasni.");
                string[] adatok = File.ReadAllLines(eleresiUt);
                Sorozat[] sorozatok = new Sorozat[adatok.Length/5];
                for (int i = 0; i < sorozatok.Length; i++)
                {
                    sorozatok[i] = new Sorozat();
                    //Console.WriteLine(sorozatok[i]);
                }
                for (int i = 0; i < adatok.Length; i+=5)
                {
                    //Console.WriteLine(adatok[i]);
                    sorozatok[i / 5].datum = adatok[i];
                    sorozatok[i / 5].cim = adatok[i+1];
                    sorozatok[i / 5].epizodSzam = adatok[i+2];
                    sorozatok[i / 5].hossz = int.Parse(adatok[i+3]);
                    sorozatok[i / 5].megnezve = int.Parse(adatok[i+4]);
                }
                for (int i = 0; i < sorozatok.Length; i++)
                {
                    Console.WriteLine(sorozatok[i].cim);
                }
            }
            else
            {
                Console.WriteLine("A fájl nem létezik, a program kilép.");
            }
        }
    }
}
