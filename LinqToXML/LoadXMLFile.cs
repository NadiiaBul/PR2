using System.Xml.Linq;

namespace LinqToXML
{
    class LoadXMLFile
    {
        public XDocument LoadXML(string nameFile)
        {
            return XDocument.Load(nameFile);
        }
    }
}
