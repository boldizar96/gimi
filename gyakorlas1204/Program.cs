using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlas1204
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add meg N méretét!");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Add meg M méretét!");
            int M = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------");
            List<int> nTomb = new List<int>();
            List<int> mTomb = new List<int>();
            Random r = new Random();
            Console.WriteLine("nTomb rendezetlenül:");
            for (int i = 0; i < N; i++)
            {
                nTomb.Add(r.Next(1, 100));
                Console.Write(nTomb[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine("mTomb rendezetlenül:");
            for (int i = 0; i < M; i++)
            {
                mTomb.Add(r.Next(-50,20));
                Console.Write(mTomb[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine("nTomb rendezetten:");
            nTomb.Sort();
            nTomb.Reverse();
            for (int i = 0; i < nTomb.Count; i++) // N-ig is mehetnénk
            {
                Console.Write(nTomb[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            // egyszerű cserés rendezés
            int seged;
            for (int i = 0; i < mTomb.Count-1; i++)
            {
                for (int j = i+1; j < mTomb.Count; j++)
                {
                    if (mTomb[i] > mTomb[j])
                    {
                        seged = mTomb[i];
                        mTomb[i] = mTomb[j];
                        mTomb[j] = seged;
                    }
                }
            }
            Console.WriteLine("mTomb rendezetten:");
            for (int i = 0; i < mTomb.Count; i++)
            {
                Console.Write(mTomb[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine("Add meg a keresett számot!");
            int X = int.Parse(Console.ReadLine());
            bool benneVan = false;
            for (int i = 0; i < nTomb.Count; i++)
            {
                if (nTomb[i] == X) // nTomb[i].Equals(X)
                {
                    benneVan = true;
                }
            }
            if (benneVan)
            {
                Console.WriteLine("{0} benne van az nTomb-ben.",X);
            }
            else
            {
                Console.WriteLine("{0} nincs benne az nTomb-ben.", X);
            }
        }
    }
}
