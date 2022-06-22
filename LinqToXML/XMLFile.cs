using System;
using System.Xml;



namespace LinqToXML
{
    class XMLFile
    {
        public ListsContainer ListsContainer { get; set; }
        private delegate void NewFileDelegate(XmlWriter xmlWriter);
        private void CreateNewNode(XmlWriter xmlWriter, string nodeName, string internalText)
        {
            xmlWriter.WriteStartElement(nodeName);
            xmlWriter.WriteString(internalText);
            xmlWriter.WriteEndElement();
        }
        private void CreateNewFile(string nameOfFile, NewFileDelegate newFileDelegate)
        {
            XmlWriter xmlWriter = XmlWriter.Create(nameOfFile);
            xmlWriter.WriteStartDocument();
            newFileDelegate.Invoke(xmlWriter);
            xmlWriter.WriteEndDocument();
            xmlWriter.Dispose();
        }
        private void CreatePersonFields(XmlWriter xmlWriter, Person person)
        {
            CreateNewNode(xmlWriter, "id", person.ID.ToString());
            CreateNewNode(xmlWriter, "surname", person.Surname.ToString());
            CreateNewNode(xmlWriter, "name", person.Name.ToString());
            CreateNewNode(xmlWriter, "patronymic", person.Patronymic.ToString());
        }
        private void CreateStudentFields(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("students");
            foreach (var student in ListsContainer.Students)
            {
                     xmlWriter.WriteStartElement("student");

                     CreatePersonFields(xmlWriter, student);

                     CreateNewNode(xmlWriter, "group", new FindGroups().Groups(ListsContainer, student.IDGroup).ToString());
                     CreateNewNode(xmlWriter, "mark", student.Mark.ToString());
                     CreateNewNode(xmlWriter, "birthday", student.Birthday.ToString());
                     CreateNewNode(xmlWriter, "professorID", student.ProfessorID.ToString());
                     xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        }
        private void CreateProfessorFields(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("professors");
            foreach (var professor in ListsContainer.Professors)
            {
                xmlWriter.WriteStartElement("professor");

                CreatePersonFields(xmlWriter, professor);

                CreateNewNode(xmlWriter, "position", new FindPositions().Positions(ListsContainer, professor.ID).ToString());
                
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        }
        public void CreateXML()
        {
            CheckingData checkingData = new CheckingData();
            if (checkingData.CheckIsStudentsListsEmpty(ListsContainer))
            {
                throw new ArgumentException("Список студентів порожній!");
            }
            CreateNewFile("professors.xml", CreateProfessorFields);
            CreateNewFile("students.xml", CreateStudentFields);
        }  

    }
}
