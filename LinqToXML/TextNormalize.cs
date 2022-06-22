using System.Globalization;

namespace LinqToXML
{
    class TextNormalize
    {
        public string NormalizePosition(string position)
        {
            return position.ToLower();
        }
        public string NormalizePIB(string pib)
        {
            TextInfo textInfo = new CultureInfo("ua-UA").TextInfo;
            return textInfo.ToTitleCase(pib);
        }
        public string NormalizeGroup(string group)
        {
            return group.ToUpper();
        }
    }
}
