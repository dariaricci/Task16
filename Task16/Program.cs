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

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            Товар[] t = new Товар[5];
            string jsonString="";
            for (int i = 0; i < 5; i++)
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    
                };
                Товар товар = new Товар(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToDouble(Console.ReadLine()));
                t[i] = товар;
                jsonString += JsonSerializer.Serialize(t[i], options)+ "\r\n";
              
            }
            string path = "D:/Даша/Автоматизация BIM/Task16/Task16/Products.json";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(jsonString);
            sw.Close();
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
