using System;

namespace LinqToXML
{
    class ControlMenu
    {
        public void Menu(ref ListsContainer listsContainer)
        {
            while (true)
            {
                Console.WriteLine("Оберіть дію - натисніть:\n1. щоб скористатися лістами за замовчуванням;\n2. ввести дані з клавіатури.");
                try
                {
                    int choice = 0;
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                return;
                            }
                        case 2:
                            {
                                EnterInformation enterInformation = new EnterInformation();
                                listsContainer = enterInformation.EnterDataFromConsole(listsContainer);
                                return;
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
