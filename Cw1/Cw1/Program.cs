using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        

        public static async Task Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("Parametr url nie zostal podany");
            string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            try
            {
                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");

                var list = new List<string>();//nie znamy wymiaru ale kolejnosc ma znaczenie
                var zbior = new HashSet<string>(); //usuwanie dupikaty i kolejnosc nie ma znaczenia
                var slownik = new Dictionary<string,int>();

                //ThreadPool() task - kiedys tam bedzie wynik - await mowi ze poczekaj az tam sie znajdzie cos - do main dodajemy async Task - wymagane do await
                if (result.IsSuccessStatusCode) return;//2xx
                    string html = await result.Content.ReadAsStringAsync(); //Bo result moze byc duzy i serwer bedzie dzielil i wysylal pakietami
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                    var matches = regex.Matches(html);
                    foreach (var m in matches)
                    {
                        Console.WriteLine(m);
                    }
            }
            catch (Exception exc)
            {
                // string blad=string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine($"Wystapil blad {exc.ToString()}"); //ewaluazja stringu
            }
         

            Console.WriteLine("Koniec");
        }
    }
}
