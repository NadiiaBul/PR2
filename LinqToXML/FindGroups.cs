using System.Linq;

namespace LinqToXML
{
    class FindGroups
    {
        public string Groups(ListsContainer listsContainer, uint IDGroup)
        {
            return listsContainer.Groups.Where(x => x.IDGroup == IDGroup).Select(x => x.Group).FirstOrDefault();
        }
    }
}
