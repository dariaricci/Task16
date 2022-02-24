using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Часть_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:/Даша/Автоматизация BIM/Task16/Task16/Products.json";
            double Max = 0;
            string expensiveProduct = "";
            
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 5; i++)
            {
                
                Товар товар = JsonSerializer.Deserialize<Товар>(sr.ReadLine());
                if (товар.ЦенаТовара > Max)
                {
                    Max = товар.ЦенаТовара;
                    expensiveProduct = товар.НазваниеТовара;

                }

            }
            Console.WriteLine("Самый дорогой товар={0}", expensiveProduct);
            Console.ReadKey();
        }

            public class Товар
        {
            [JsonPropertyName("Код товара")]
            public int КодТовара { get; set; }
            [JsonPropertyName("Название товара")]
            public string НазваниеТовара { get; set; }
            [JsonPropertyName("Цена товара")]
            public double ЦенаТовара { get; set; }

            public Товар(int КодТовара, string НазваниеТовара, double ЦенаТовара)
            {
                this.КодТовара = КодТовара;
                this.НазваниеТовара = НазваниеТовара;
                this.ЦенаТовара = ЦенаТовара;

            }
        }
    }
}
