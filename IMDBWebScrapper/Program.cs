using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver =new  OpenQA.Selenium.Chrome.ChromeDriver())
            {
                new IMDB.IMDB(driver).SearchByActorName("Russell Crowe").SaveMoviesDetails() ;
            }
        }
    }
}
