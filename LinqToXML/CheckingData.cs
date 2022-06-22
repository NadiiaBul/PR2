
namespace LinqToXML
{
    class CheckingData
    {
        public bool CheckIDNumber(ListsContainer listsContainer, uint ID)
        {
            foreach (var x in listsContainer.Students)
            {
                if(x.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckGroup(ListsContainer listsContainer, string group)
        {
            foreach(var x in listsContainer.Groups)
            {
                if (x.Equals(group))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckID(ListsContainer listsContainer, uint ID)
        {
            foreach (var x in listsContainer.Professors)
            {
                if (x.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckMark(decimal mark)
        {
            if (mark > 100 || mark <= 0)
            {
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckIsStudentsListsEmpty(ListsContainer listsContainer)
        {
            return listsContainer.Students.Count == 0;
        }
    }
}
