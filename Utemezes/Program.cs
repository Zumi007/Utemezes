using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Utemezes
{
    internal class Program
    {
        class tabor
        {
            public int honapkezd;
            public int napkezd;
            public int honapveg;
            public int napveg;
            public string diakok;
            public string tema;

            public tabor(int honapkezd, int napkezd, int honapveg, int napveg, string diakok, string tema)
            {
                this.honapkezd = honapkezd;
                this.napkezd = napkezd;
                this.honapveg = honapveg;
                this.napveg = napveg;
                this.diakok = diakok;
                this.tema = tema;
            }
        }
        static void Main(string[] args)
        {
            List<tabor> taborok = new List<tabor>();

            StreamReader reader = new StreamReader(@"C:\temp\taborok.txt");

            

            while (!reader.EndOfStream) 
            {
                
                string[] adatok = reader.ReadLine().Split('\t');

                tabor egytabor = new tabor(Convert.ToInt32(adatok[0]), Convert.ToInt32(adatok[1]), Convert.ToInt32(adatok[2]), Convert.ToInt32(adatok[3]), adatok[4], adatok[5]);

                taborok.Add(egytabor);
            }

            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az adatsorok száma:  {taborok.Count}");
            Console.WriteLine($"Az először rögzített tábor témája: {taborok[0].tema}");
            Console.WriteLine($"A utoljára rögzített tábor témája: {taborok.First().tema} ");

            Console.WriteLine($"A utoljára rögzített tábor témája: {taborok[taborok.Count-1].tema} ");
            //Console.WriteLine($"A utoljára rögzített tábor témája: {taborok.Last().tema} ");

            bool zeneinemvolt = true;

            foreach (tabor taborocska in taborok)
            {
                if (taborocska.tema == "zenei")
                {
                    zeneinemvolt = false;
                    Console.WriteLine($"Zenei tábor kezdődik {taborocska.honapkezd} hónapban és {taborocska.napkezd} napján");
                }
            }
            if (zeneinemvolt)
                Console.WriteLine("Nem volt zenei tábor");

            int max = 0; //taborok.Max(item => item.diakok.Length);

            foreach (tabor item in taborok)
            {
                if(item.diakok.Length > max)
                {
                    max = item.diakok.Length;
                }

            }
            foreach (tabor item in taborok)
            {
                if(max == item.diakok.Length)
                {
                    Console.WriteLine($"{item.honapkezd} {item.napkezd} {item.tema}");

                }
            }

            Console.ReadKey();
        }

        static int sorszam(int honap, int nap)
        {
            int _sorszam;
            switch (honap)
            {
                case 6:
                    _sorszam = nap - 15;
                    break;
                case 7:
                    _sorszam = 15 + nap;
                    break;
                case 8:
                    _sorszam = 46 + nap;
                    break;
                default:
                    _sorszam = 1;
                    break;
            }

            return _sorszam;
        }
    }
}
