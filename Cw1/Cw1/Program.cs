using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl");
            //ThreadPool() task - kiedys tam bedzie wynik - await mowi ze poczekaj az tam sie znajdzie cos - do main dodajemy async Task - wymagane do await
            if(result.IsSuccessStatusCode) //2xx
            {
                string html = await result.Content.ReadAsStringAsync(); //Bo result moze byc duzy i serwer bedzie dzielil i wysylal pakietami
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);
                foreach(var m in matches)
                {
                    Console.WriteLine(m);
                }
            }


            Console.WriteLine("Hello World!");
        }
    }
}
