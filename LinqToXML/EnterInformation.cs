using System;
using System.Linq;

namespace LinqToXML
{
    class EnterInformation
    {
        private readonly CheckingData _checkingData = new CheckingData();
        private readonly CheckingEntering _checkEntering = new CheckingEntering();
        private readonly TextNormalize _textNormalize = new TextNormalize();

        private void EnterProfessorData(ListsContainer listsContainer)
        {
            string choice = "1";
            while (choice.Equals("1"))
            {
                try
                {
                    Console.WriteLine("Введіть дані про керівника:\nID Прізвище Ім'я По батькові Посада");
                    string data = Console.ReadLine();
                    string[] dataContainer = data.Split(' ');
                    if (dataContainer.Length == 5 && !_checkingData.CheckID(listsContainer, uint.Parse(dataContainer[0]))) 
                    {
                       listsContainer.Professors.Add(new Professor { ID = uint.Parse(dataContainer[0]), Surname = _textNormalize.NormalizePIB(dataContainer[1]), Name = _textNormalize.NormalizePIB(dataContainer[2]), Patronymic = _textNormalize.NormalizePIB(dataContainer[3]) });
                       EnterPosition(listsContainer, _textNormalize.NormalizePosition(dataContainer[4]), listsContainer.Professors.Last().ID);
                    }
                    else
                    {
                        throw new ArgumentException("Не правильно введені дані!");
                    }

                    choice = _checkEntering.CheckEntering();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void EnterStudentData(ListsContainer listsContainer)
        {
            string choice = "1";
            while (choice.Equals("1"))
            {
                try
                {
                    Console.WriteLine("Введіть дані про студента:\nID  Прізвище Ім'я  По батькові  Середній бал  Дата народження  Група  ID керівника");
                    string data = Console.ReadLine();
                    string[] dataContainer = data.Split(' ');
                    if (dataContainer.Length == 8 && _checkingData.CheckID(listsContainer, uint.Parse(dataContainer[7])) && !_checkingData.CheckIDNumber(listsContainer, uint.Parse(dataContainer[0])) && !_checkingData.CheckMark(decimal.Parse(dataContainer[4])))
                    {
                       listsContainer.Students.Add(new Student { ID = uint.Parse(dataContainer[0]), Surname = _textNormalize.NormalizePIB(dataContainer[1]), Name = _textNormalize.NormalizePIB(dataContainer[2]), Patronymic = _textNormalize.NormalizePIB(dataContainer[3]), Mark = decimal.Parse(dataContainer[4]), Birthday = DateTime.Parse(dataContainer[5]), IDGroup = EnterGroup(listsContainer, _textNormalize.NormalizeGroup(dataContainer[6])), ProfessorID = uint.Parse(dataContainer[7])});
                    }
                    else
                    {
                        throw new ArgumentException("Не правильно введені дані!");
                    }
                    choice = _checkEntering.CheckEntering();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void ClearLists(ListsContainer listsContainer)
        {
            listsContainer.Professors.Clear();
            listsContainer.Students.Clear();
            listsContainer.Connections.Clear();
            listsContainer.Groups.Clear();
        }
        public ListsContainer EnterDataFromConsole(ListsContainer listsContainer)
        {
            ClearLists(listsContainer);
            EnterProfessorData(listsContainer);
            EnterStudentData(listsContainer);
            return listsContainer;
        }
        private void EnterPosition(ListsContainer listsContainer, string positions, uint professorID)
        {
            string[] positionArray = positions.Split(',');
            int connectionCount = listsContainer.Connections.Count;
            foreach (var x in positionArray)
            {
                foreach (var y in listsContainer.Positions)
                {
                    if (y.Position.Equals(x))
                    {
                        listsContainer.Connections.Add(new ConnectionsManyToMany { IDProfessor = professorID, IDPosition = y.IDPosition });
                        break;
                    }
                }
                if (connectionCount == listsContainer.Connections.Count)
                {
                    listsContainer.Professors.RemoveAt(listsContainer.Professors.Count-1);
                    throw new ArgumentException("Немає такої посади.");
                }
                connectionCount = listsContainer.Connections.Count;
            }
        }
        private uint EnterGroup(ListsContainer listsContainer, string group)
        {
            if(!_checkingData.CheckGroup(listsContainer, group))
            {
                listsContainer.Groups.Add(new Groups { IDGroup = uint.Parse(listsContainer.Groups.Count.ToString()) + 1, Group = group });
                return listsContainer.Groups.Last().IDGroup;
            }
            else
            {
                return listsContainer.Groups.Where(x => x.Group.Equals(group)).Select(x => x.IDGroup).First();
            }
        }
    }
}
