using System;

namespace LinqToXML
{
    class CheckingEntering
    {
        public string CheckEntering()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Щоб завершити ввід даних натисніть 0, продовжити - 1:");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0":
                            {
                                return "0";
                            }
                        case "1":
                            {
                                return "1";
                            }
                        default:
                            throw new ArgumentException("Щось пішло не так...");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
