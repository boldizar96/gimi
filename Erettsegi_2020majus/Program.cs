using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Erettsegi2020majus
{
    class Adat
    {
        public string Telepules;
        public string Ido;
        public string SzeliranyErosseg;
        public int Homerseklet;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Fájlbeolvasás
            string eleresiUt = @"tavirathu13.txt";
            if (File.Exists(eleresiUt))
            {
                Console.WriteLine("A fáj létezik.");
                Console.WriteLine("Beolvasás...");
                Console.WriteLine("---------------");
                string[] sorok = File.ReadAllLines(eleresiUt);

                // megnézzük mekkora tömbra lesz szüksgéünk az Adat osztályhoz
                int meret = 0;
                for (int i = 0; i < sorok.Length; i++)
                {
                    if (sorok[i].Length > 0)
                    {
                        meret++;
                    }
                }
                // a megszámolt mérettel létrehozzuk a tömböt
                Adat[] adatok = new Adat[meret];
                // belerakjuk az adatok tömbbe a megfelelő adatokat
                for (int i = 0; i < adatok.Length; i++)
                {
                        string[] sor = sorok[i].Split(' ');
                        // sorok[i]: "BP 0000 VRB02 23"
                        // sor[]: { "BP", "0000", "VRB02", "23"}
                        adatok[i] = new Adat();
                        adatok[i].Telepules = sor[0];
                        adatok[i].Ido = sor[1];
                        adatok[i].SzeliranyErosseg = sor[2];
                        adatok[i].Homerseklet = int.Parse(sor[3]);
                                        
                }
                Console.WriteLine("Kérem adja meg egy város kódját!");
                string kod = Console.ReadLine();
                
                // UTOLSÓ MÉRÉS IDŐPONTJA
                // megadunk egy lehetetlen tömbindexet
                int index = -1;
                for (int i = 0; i < adatok.Length; i++)
                {
                    if (kod.Equals(adatok[i].Telepules))
                    {
                        index = i;
                    }
                }

                // ELSŐ MÉRÉS IDŐPONTJA
                // megadunk egy lehetetlen tömbindexet
                int index2 = -1;
                int j = 0;
                while (index2 == -1 && j < adatok.Length)
                {
                    if (kod.Equals(adatok[j].Telepules))
                    {
                        index2 = j;
                    }
                    j++;
                }

                // KIíRATÁS
                if (index == -1)
                {
                    Console.WriteLine("Nincs ilyen település.");
                }
                else
                {
                    string ora2 = adatok[index2].Ido.Substring(0,2);
                    string perc2 = adatok[index2].Ido.Substring(2,2);
                    Console.WriteLine("Első mérés időpontja:");
                    Console.WriteLine("{0}:{1}", ora2, perc2);
                    string ora = adatok[index].Ido.Substring(0, 2);
                    string perc = adatok[index].Ido.Substring(2, 2);
                    Console.WriteLine("Utolsó mérés időpontja:");
                    Console.WriteLine("{0}:{1}",ora,perc);
                }

                Console.WriteLine("---------------------------");


                // LEGMAGASABB ÉS LEGALACSONYABB ÉRTÉKEK
                int legkisebbIndex = 0;
                int legkisebb = adatok[legkisebbIndex].Homerseklet;
                int legnagyobbIndex = 0;
                int legnagyobb = adatok[legnagyobbIndex].Homerseklet;

                // legkisebb keresés
                for (int i = 1; i < adatok.Length; i++)
                {
                    if (legkisebb > adatok[i].Homerseklet)
                    {
                        legkisebb = adatok[i].Homerseklet;
                        legkisebbIndex = i;
                    }
                }
                // legnagyobb keresés
                for (int i = 1; i < adatok.Length; i++)
                {
                    if (legnagyobb < adatok[i].Homerseklet)
                    {
                        legnagyobb = adatok[i].Homerseklet;
                        legnagyobbIndex = i;
                    }
                }
                // kiíratás
                Console.WriteLine("Legalacsonyabb hőmérséklet adatai:");
                Console.WriteLine("Település: {0}, idő: {1}, hőmérséklet: {2}",adatok[legkisebbIndex].Telepules, adatok[legkisebbIndex].Ido, adatok[legkisebbIndex].Homerseklet);
                Console.WriteLine("Legmagasabb hőmérséklet adatai:");
                Console.WriteLine("Település: {0}, idő: {1}, hőmérséklet: {2}", adatok[legnagyobbIndex].Telepules, adatok[legnagyobbIndex].Ido, adatok[legnagyobbIndex].Homerseklet);

                Console.WriteLine("----------------------------");

                //SZÉLCSEND
                // számoljuk meg, hogy egyáltalán mennyi van
                int megszamol = 0;
                string szelcsend = "00000";
                for (int i = 0; i < adatok.Length; i++)
                {
                    if (adatok[i].SzeliranyErosseg.Equals(szelcsend))
                    {
                        megszamol++;
                    }
                }


                if (megszamol == 0)
                {
                    Console.WriteLine("Nem volt szélcsend a mrések idején.");
                }
                else
                {
                    // megkeressük melyik indexen van szélcsend
                    int[] szelcsendIndexek = new int[megszamol];
                    int szi = 0;
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        if (adatok[i].SzeliranyErosseg.Equals(szelcsend))
                        {
                            szelcsendIndexek[szi] = i;
                            szi++;
                        }
                    }
                    // kiírás
                    Console.WriteLine("Szélcsend adatok:");
                    for (int i = 0; i < szelcsendIndexek.Length; i++)
                    {
                        Console.WriteLine("Település: {0}, időpont: {1}",adatok[szelcsendIndexek[i]].Telepules, adatok[szelcsendIndexek[i]].Ido);
                    }
                }
            }
            else
            {
                Console.WriteLine("A fájl nem létezik, a program kilép!");
            }
        }
    }
}
