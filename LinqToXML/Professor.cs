using System.Linq;

namespace LinqToXML
{
    public class Professor : Person
    {
        public override string ToString()
        {
            return $"ID керівника: {ID}\tПрізвище: {Surname}\tІм'я: {Name}\tПо батькові: {Patronymic}\t";
        }
    }
}
