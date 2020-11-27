using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace metjelentes
{
    class Adat
    {
        public string Telepules;
        public string Ido;
        public string SzelIranyErosseg;
        public int Homerseklet;
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("1. feladat");
                Console.WriteLine("Beolvasás");
                string eleresiUt = @"tavirathu13.txt";
                if (File.Exists(eleresiUt))
                {
                    string[] sorok = File.ReadAllLines(eleresiUt);
                    int helyesSorokSzama = 0;
                    for (int i = 0; i < sorok.Length; i++)
                    {
                        if (sorok[i].Length > 0)
                        {
                            helyesSorokSzama++; // helyesSorokSzama = helyesSorokSzama + 1;
                        }
                    }
                    Adat[] adatok = new Adat[helyesSorokSzama];
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        adatok[i] = new Adat();
                        string[] sor = sorok[i].Split(' '); // sorok[i] = "SN 2353 01008 20"  =>  { "SN", "2353", "01008", "20" }
                        adatok[i].Telepules = sor[0];
                        adatok[i].Ido = sor[1];
                        adatok[i].SzelIranyErosseg = sor[2];
                        adatok[i].Homerseklet = int.Parse(sor[3]); // convert.toint32
                    }
                    Console.WriteLine("2. feladat");
                    Console.WriteLine("Kérem adja meg a település kódját! (string)");
                    string telepulesKod = Console.ReadLine();
                    telepulesKod = telepulesKod.ToUpper();
                    int utolsoIndex = -1;
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        if (adatok[i].Telepules.Equals(telepulesKod))
                        {
                            utolsoIndex = i;
                        }
                    }
                    if (utolsoIndex == -1)
                    {
                        Console.WriteLine("Nincs a megadott kódnak megfelelő település!");
                    }
                    else
                    {
                        string ora = adatok[utolsoIndex].Ido.Substring(0,2); // 0 és 1 index kell
                        string perc = adatok[utolsoIndex].Ido.Substring(2, 2); // 2 és 3 index kell
                        Console.WriteLine("{0}:{1}", ora, perc);
                    }

                    Console.WriteLine("3. feladat");
                    // minimum keresés
                    int minIndex = 0;
                    int minimum = adatok[minIndex].Homerseklet;
                    for (int i = 1; i < adatok.Length; i++)
                    {
                        if (minimum > adatok[i].Homerseklet)
                        {
                            minIndex = i;
                            minimum = adatok[i].Homerseklet;
                        }
                    }
                    Console.WriteLine("Legkisebb hőmérséklet:");
                    Console.WriteLine("Település: {0}, időpont: {1}, hőmérséklet: {2}", adatok[minIndex].Telepules, adatok[minIndex].Ido, adatok[minIndex].Homerseklet);

                    // maximum keresés
                    int maxIndex = 0;
                    int maximum = adatok[maxIndex].Homerseklet;
                    for (int i = 1; i < adatok.Length; i++)
                    {
                        if (maximum < adatok[i].Homerseklet)
                        {
                            maxIndex = i;
                            maximum = adatok[i].Homerseklet;
                        }
                    }
                    Console.WriteLine("Legnagyobb hőmérséklet:");
                    Console.WriteLine("Település: {0}, időpont: {1}, hőmérséklet: {2}", adatok[maxIndex].Telepules, adatok[maxIndex].Ido, adatok[maxIndex].Homerseklet);

                    Console.WriteLine("4. feladat");
                    string szelcsend = "00000";
                    int db = 0;
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        if (adatok[i].SzelIranyErosseg.Equals(szelcsend))
                        {
                            db++;
                        }
                    }

                    if (db == 0)
                    {
                        Console.WriteLine("Nem volt szélcsend a mérések idején.");
                    }
                    else
                    {
                        int[] szelcsendIndexek = new int[db];
                        int szelcsendIndex = 0;
                        for (int i = 0; i < adatok.Length; i++)
                        {
                            if (adatok[i].SzelIranyErosseg.Equals(szelcsend))
                            {
                                szelcsendIndexek[szelcsendIndex] = i;
                                szelcsendIndex++;
                            }
                        }
                        for (int i = 0; i < szelcsendIndexek.Length; i++)
                        {
                            // k = szelcsendIndexek[i] = 1, 5, 6, 10, stb.
                            // adatok[k]
                            Console.WriteLine("Település: {0}, időpont: {1}", adatok[szelcsendIndexek[i]].Telepules, adatok[szelcsendIndexek[i]].Ido);
                        }
                    }
                    
                    Console.WriteLine("5. feladat");
                    List<string> varosok = new List<string>();
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        if (!varosok.Contains(adatok[i].Telepules))
                        {
                            varosok.Add(adatok[i].Telepules);
                        }
                    }
                    List<List<int>> homersekletek = new List<List<int>>();
                    List<List<string>> orak = new List<List<string>>();
                    for (int i = 0; i < adatok.Length; i++)
                    {
                        for (int j = 0; j < varosok.Count; j++)
                        {
                            homersekletek.Add(new List<int>());
                            orak.Add(new List<string>());
                            if (adatok[i].Telepules.Equals(varosok[j]))
                            {
                                homersekletek[j].Add(adatok[i].Homerseklet);
                                orak[j].Add(adatok[i].Ido.Substring(0,2));
                            }
                        }
                    }
                    for (int i = 0; i < varosok.Count; i++)
                    {
                        int homersekletOsszeg = 0;
                        int joOrak = 0;
                        if (orak[i].Contains("01") && orak[i].Contains("07") && orak[i].Contains("13") && orak[i].Contains("19"))
                        {
                            for (int j = 0; j < homersekletek[i].Count; j++)
                            {
                                if (orak[i][j].Equals("01") || orak[i][j].Equals("07") || orak[i][j].Equals("13") || orak[i][j].Equals("19"))
                                {
                                    homersekletOsszeg += homersekletek[i][j];
                                    joOrak++;
                                }
                            }
                        }

                        int min = 99999;
                        int max = -99999;
                        for (int j = 0; j < homersekletek[i].Count; j++)
                        {
                            if (min > homersekletek[i][j])
                            {
                                min = homersekletek[i][j];
                            }
                            if (max < homersekletek[i][j])
                            {
                                max = homersekletek[i][j];
                            }
                        }

                        if (joOrak != 0)
                        {
                            Console.WriteLine("{0} Középhőmérséklet: {1}; Ingadozás: {2}",varosok[i],homersekletOsszeg/joOrak,max-min);
                        }
                        else
                        {
                            Console.WriteLine("{0} Középhőmérséklet: {1}; Ingadozás: {2}", varosok[i], "NA", max - min);
                        }

                    }
                    Console.WriteLine("6. feladat");
                    for (int i = 0; i < varosok.Count; i++)
                    {
                        string fajlNev = varosok[i];
                        StreamWriter kimenet = new StreamWriter(fajlNev + ".txt");
                        Console.WriteLine(fajlNev + ": ");
                        for (int j = 0; j < adatok.Length; j++)
                        {
                            if (adatok[j].Telepules.Equals(varosok[i]))
                            {
                                int hashSzam = int.Parse(adatok[j].SzelIranyErosseg.Substring(3, 2));
                                Console.Write(hashSzam + " ");
                                kimenet.Write(adatok[j].Ido + " ");
                                Console.Write(adatok[j].Ido + " ");
                                for (int k = 0; k < hashSzam; k++)
                                {
                                    kimenet.Write("#");
                                }
                                kimenet.WriteLine();
                                Console.WriteLine();
                            }
                        }
                        kimenet.Close();
                    }
                   

                }
                else
                {
                    Console.WriteLine("A fájl nem létezik, a program kilép.");
                }
            }
            {
                /*
                string[] szovegek = { "aas", "asdgs", "asfsdfgh" };
                string[] szovegek2 = new string[4];
                List<string> stringLista = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    //stringLista.Add("" + i);
                    stringLista.Add(i.ToString());
                }
                for (int i = 0; i < stringLista.Count; i++)
                {
                    Console.WriteLine(stringLista[i]);
                }

                List<List<int>> matrix = new List<List<int>>();
                for (int i = 0; i < 10; i++)
                {
                    matrix.Add(new List<int>());
                    for (int j = 0; j < 10; j++)
                    {
                        //matrix[i][j] = (i + 1) * (j + 1);
                        matrix[i].Add((i + 1) * (j + 1));
                    }
                }
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Count; j++)
                    {
                        Console.Write(matrix[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
                */
            }
            
        }
    }
}
