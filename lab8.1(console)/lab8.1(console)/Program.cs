using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab8._1_console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите дату в формате дд.мм.гггг");
                string text = Console.ReadLine();

                MatchCollection matches;
                Regex reg = new Regex(@"[0-3][0-9].[0-1][0-9].[1,2][9,0][0-9][0-9]");     //регулярные выражения - язык поиска подстрок в тексте,
                                                                                            //основанный на использовании метасимволов
                                                                                            //класс regex реализует регулярные выражения
                matches = reg.Matches(text);

                {
                    for (int i = 0; i < matches.Count; i++)     //проход по коллекции совпадений
                    {
                        string[] hhss = matches[i].Value.Split('.');
                        int dd = Convert.ToInt32(hhss[0]);
                        int mm = Convert.ToInt32(hhss[1]);
                        int gg = Convert.ToInt32(hhss[2]);

                        if (dd > 31 || mm > 12 || gg < 1900 && gg > 2010)
                        {
                            text = "Такой даты не существует!";
                        }
                        else
                        {
                            string updDate = DateTime.Parse(matches[i].Value).AddDays(-1).ToShortDateString();
                            text = text.Replace(matches[i].Value, updDate);
                        }
                    }
                    Console.WriteLine("Дата предыдущенго дня {0}", text);
                }

            }
            catch
            {
                Console.WriteLine("Некорректный ввод или такой даты не существует!");
            }

        }
    }
}