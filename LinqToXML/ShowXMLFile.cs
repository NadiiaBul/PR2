using System.Xml.Linq;

namespace LinqToXML
{
    class ShowXMLFile
    {
        public void ShowXMLFileOnScreen()
        {
            PrintOnScreen printOnScreen = new PrintOnScreen();
            printOnScreen.PrintCondition("Виводимо XML-файли на екран:\n");

            XDocument loadXMLFile = new LoadXMLFile().LoadXML("professors.xml");
            printOnScreen.PrintCondition(loadXMLFile+"\n");

            loadXMLFile = new LoadXMLFile().LoadXML("students.xml");
            printOnScreen.PrintCondition(loadXMLFile);
        }
    }
}
