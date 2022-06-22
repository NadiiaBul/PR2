using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXML
{
    class XMLQueries
    {
        readonly XDocument xDocPr = XDocument.Load("professors.xml");
        readonly XDocument xDocSt = XDocument.Load("students.xml");
        public IEnumerable<XElement> ProfessorsInfo()
        {
            var professorsInfo = from professor in xDocPr.Descendants("professor") select professor;
            return professorsInfo;
        }
        public IEnumerable<XElement> ListOfStudentsOrderByMarkAndSurname()
        {
            var listOfStudentsOrderByMarkAndSurname = xDocSt.Descendants("student").Select(st => st)
                .OrderByDescending(s => decimal.Parse(s.Element("mark").Value))
                .ThenBy(s => s.Element("surname").Value);
            return listOfStudentsOrderByMarkAndSurname;
        }
        public IEnumerable<XElement> ListOfStudentsWithHighMark()
        {
            var listOfStudentsWithHighMark = from st in xDocSt.Descendants("student")
                                             where decimal.Parse(st.Element("mark").Value) > 95
                                             orderby decimal.Parse(st.Element("mark").Value) descending
                                             select st;
            return listOfStudentsWithHighMark;
        }
        public Dictionary<string, List<XElement>> StudentsGroupByGroups()
        {
            var studentsGroupByGroups = from st in xDocSt.Descendants("student")
                                        group st by st.Element("group").Value into newGroup
                                        orderby newGroup.Key
                                        select newGroup;
            return studentsGroupByGroups.ToDictionary(x => x.Key, x => x.ToList());
        }
        public IEnumerable<decimal> FindMaxMinAverageMarks()
        {
            var findMaxMinAverageMarks = xDocSt.Descendants("student")
                .Select(s => decimal.Parse(s.Element("mark").Value));
            yield return findMaxMinAverageMarks.Average();
            yield return findMaxMinAverageMarks.Max();
            yield return findMaxMinAverageMarks.Min();
        }
        public Dictionary<string, List<XElement>> ProfessorsGroupByPosition()
        {
            var professorsGroupByPosition = from pr in xDocPr.Descendants("professor")
                                            group pr by pr.Element("position").Value into newGroupPosition
                                            select newGroupPosition;

            return professorsGroupByPosition.ToDictionary(x => x.Key, x => x.ToList());
        }
        public IEnumerable<InitialsStudetsWithInitialsProffesor> ListOfStudentsWithTheirProfessors()
        {
            var listOfStudentsWithTheirProfessors = from st in xDocSt.Descendants("student")
                                                    join pr in xDocPr.Descendants("professor") on st.Element("professorID").Value 
                                                        equals pr.Element("id").Value
                                                    select new InitialsStudetsWithInitialsProffesor
                                                    {
                                                        StudentSurname = st.Element("surname").Value
                                                    ,
                                                        StudentName = st.Element("name").Value
                                                    ,
                                                        StudentPatronymic = st.Element("patronymic").Value
                                                    ,
                                                        ProfessorSurname = pr.Element("surname").Value
                                                    ,
                                                        ProfessorName = pr.Element("name").Value
                                                    ,
                                                        ProfessorPatronymic = pr.Element("patronymic").Value
                                                    };

            return listOfStudentsWithTheirProfessors;
        }
        public IEnumerable<string> ListOfGroupNames()
        {
            var listOfGroupNames = xDocSt.Descendants("student")
                .Select(gr => gr.Element("group").Value)
                .OrderBy(g => g).Distinct();
            return listOfGroupNames;
        }
        public IEnumerable<XElement> FindStudentsWhereProfessorsIsDocent()
        {
            var findStudentsWhereProfessorsIsDocent = from st in xDocSt.Descendants("student")
                                                      join pr in xDocPr.Descendants("professor") 
                                                        on st.Element("professorID").Value 
                                                        equals pr.Element("id").Value
                                                      where pr.Element("position").Value.Contains("доцент")
                                                      select st;
            return findStudentsWhereProfessorsIsDocent;
        }
        public Dictionary<string, List<XElement>> ListOfProfessorsWithAmountOfTheirStudentsAndGroups()
        {
            var listOfProfessorsWithAmountOfTheirStudentsAndGroups = from st in xDocSt.Descendants("student")
                                                                     join pr in xDocPr.Descendants("professor") on st.Element("professorID").Value equals pr.Element("id").Value
                                                                     group st by pr.Element("surname").Value into prGroup
                                                                     select prGroup;
            return listOfProfessorsWithAmountOfTheirStudentsAndGroups.ToDictionary(x => x.Key, x => x.ToList());
        }
        public IEnumerable<StudentsWithTheirAges> StudentsAndTheirAges()
        {
            var studentsAndTheirAges = from age in xDocSt.Descendants("student")
                                       select new StudentsWithTheirAges
                                       {
                                           StudentSurname = age.Element("surname").Value
                                       ,
                                           StudentName = age.Element("name").Value
                                       ,
                                           Age = DateTime.Now.Year - DateTime.Parse(age.Element("birthday").Value).Year
                                       };

            return studentsAndTheirAges;
        }
        public IEnumerable<decimal> FindTopThreeMarks()
        {
            var topThreeMarks = xDocSt.Descendants("student")
                .Select(mark => decimal.Parse(mark.Element("mark").Value))
                .OrderByDescending(m => m)
                .Take(3);
            return topThreeMarks;
        }
        public IEnumerable<XElement> ProfessorsInfoByConcat()
        {
            var professorsInfoByConcat = xDocPr.Descendants("professor")
                .Take(3)
                .Concat(xDocPr.Descendants("professor")
                .Skip(3));
            return professorsInfoByConcat;
        }
        public IEnumerable<FindYearOfBirthday> FindYearOfBirth()
        {
            var findYearOfBirth = xDocSt.Descendants("student").Select(Surname => Surname.Element("surname").Value);
            foreach (var st in findYearOfBirth)
            {
                var findYear = xDocSt.Descendants("student")
                    .Where(year => DateTime.Parse(year.Element("birthday").Value).Year is 2000)
                    .Select(sN => sN.Element("surname").Value)
                    .Contains(st);
                yield return new FindYearOfBirthday { StudentSurname = st, IsYear2000 = findYear };
            }
        }
        public IEnumerable<XElement> FindProfessorsSurname()
        {
            var findProfessorsSurname = xDocPr.Descendants("professor")
                .Where(profSurName => profSurName.Element("surname").Value
                .StartsWith("Д"));
            return findProfessorsSurname;
        }
    }
}
