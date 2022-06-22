using System;
using System.Text;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ListsContainer listsContainer = new ListsContainer();

            ControlMenu controlMenu = new ControlMenu();
            controlMenu.Menu(ref listsContainer);

            XMLFile xmlFile = new XMLFile { ListsContainer = listsContainer};
            xmlFile.CreateXML();

            ShowXMLFile showXMLFile = new ShowXMLFile();
            showXMLFile.ShowXMLFileOnScreen();

            ShowQueries showQueries = new ShowQueries();
            showQueries.ShowAllQueries();
            
            Console.ReadLine();
        }
    }
}
