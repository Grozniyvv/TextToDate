using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TextToDate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Прием даты из текста в формате dd/MM/yyyy, dd:MM:yy, ww.yyyy, ww-yy, использовав одну функцию
            
            var input = "01/21";
            DateTime ParseDate (string input)
            {
                if (Regex.IsMatch(input, @"\d+\W\d+\W\d+"))
                {

                    var date1 = int.Parse(Regex.Match(input, @"(\d+)\W(\d+)\W(\d+)").Groups[1].Value);
                    var date2 = int.Parse(Regex.Match(input, @"(\d+)\W(\d+)\W(\d+)").Groups[2].Value);
                    var date3 = int.Parse(Regex.Match(input, @"(\d+)\W(\d+)\W(\d+)").Groups[3].Value);

                    if (date3 < 1000)
                    {
                        date3 += 2000;
                    }

                    var date = new DateTime(date3, date2, date1);
                    return date;
                }
                else
                {
                    var date1 = int.Parse(Regex.Match(input, @"(\d+)\W(\d+)").Groups[1].Value);
                    var date2 = int.Parse(Regex.Match(input, @"(\d+)\W(\d+)").Groups[2].Value);
                    if (date2 < 1000)
                    {
                        date2 += 2000;
                    }
                    var date = new DateTime(date2, 1, 1);
                    date = date.AddDays((date1 - 2) * 7);

                    for (var i = 0; i <= 6; i++)
                    {
                        date = date.AddDays(1);
                        if (date.DayOfWeek != DayOfWeek.Monday)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    return date;
                }
            }

            Console.WriteLine("input: " + input + "\n" + "output: " + ParseDate(input));

            Console.ReadLine();



        }
    }
}
