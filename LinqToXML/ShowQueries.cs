

namespace LinqToXML
{
    class ShowQueries
    {
        public void ShowAllQueries()
        {
            PrintOnScreen printOnScreen = new PrintOnScreen();
            XMLQueries xmlQuery = new XMLQueries();

            printOnScreen.PrintCondition("\nВиводимо всі запити на екран:\n");

            printOnScreen.PrintCondition("1. Вивести всі дані про керівників:\n");
            printOnScreen.WriteOnScreen(xmlQuery.ProfessorsInfo());

            printOnScreen.PrintCondition("\n2. Список всіх студентів відсортований за середнім балом(порядок спадання) та прізвищем студентів (у алфавітному порядку):\n");
            printOnScreen.WriteOnScreen(xmlQuery.ListOfStudentsOrderByMarkAndSurname());

            printOnScreen.PrintCondition("\n3. ПІБ студентів, середній бал яких більше 95:\n");
            printOnScreen.WriteOnScreen(xmlQuery.ListOfStudentsWithHighMark());

            printOnScreen.PrintCondition("\n4. Список студентів, поділених на групи, у яких вони навчаються:\n");
            printOnScreen.WriteOnScreen(xmlQuery.StudentsGroupByGroups());

            printOnScreen.PrintCondition("\n5. Знайти середній, найбільший та найменший бал серед всіх студентів:\n");
            printOnScreen.WriteOnScreen(xmlQuery.FindMaxMinAverageMarks());

            printOnScreen.PrintCondition("\n6. Порахувати скільки керівників займають кожну з посад:\n");
            printOnScreen.WriteOnScreen(xmlQuery.ProfessorsGroupByPosition());

            printOnScreen.PrintCondition("\n7. Студенти-дипломники та їх керівники:\n");
            printOnScreen.PrintCondition("\n\t\tСТУДЕНТИ\t\t\t\t\tКЕРІВНИКИ\n");
            printOnScreen.WriteOnScreen(xmlQuery.ListOfStudentsWithTheirProfessors());

            printOnScreen.PrintCondition("\n8. Вивести назви всіх груп (без повторів):\n");
            printOnScreen.WriteOnScreen(xmlQuery.ListOfGroupNames());

            printOnScreen.PrintCondition("\n9. Список студентів, керівники яких займають посаду доцента:\n");
            printOnScreen.WriteOnScreen(xmlQuery.FindStudentsWhereProfessorsIsDocent());

            printOnScreen.PrintCondition("\n10. Прізвища керівників, кількість студентів та їх інформація:\n");
            printOnScreen.WriteOnScreen(xmlQuery.ListOfProfessorsWithAmountOfTheirStudentsAndGroups());

            printOnScreen.PrintCondition("\n11. Список студентів та їх вік:\n");
            printOnScreen.WriteOnScreen(xmlQuery.StudentsAndTheirAges());

            printOnScreen.PrintCondition("\n12. Вивести 3 найвищі середні бали:\n");
            printOnScreen.WriteOnScreen(xmlQuery.FindTopThreeMarks());

            printOnScreen.PrintCondition("\n13. Використовуємо операцію Concat для виводу інформації про керівників:\n");
            printOnScreen.WriteOnScreen(xmlQuery.ProfessorsInfoByConcat());

            printOnScreen.PrintCondition("\n14. Перевіряємо чи є серед студентів ті, хто народились 2000 року:\n");
            printOnScreen.WriteOnScreen(xmlQuery.FindYearOfBirth());

            printOnScreen.PrintCondition("\n15. Прізвища керівників, що починаються на літеру 'Д':\n");
            printOnScreen.WriteOnScreen(xmlQuery.FindProfessorsSurname());
        }
    }
}
