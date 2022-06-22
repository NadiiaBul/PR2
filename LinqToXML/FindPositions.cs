using System.Linq;

namespace LinqToXML
{
    class FindPositions
    {
        public string Positions(ListsContainer listsContainer, uint ID)
        {
            string positions = "";
            var findPosition = from pos in listsContainer.Positions
                               join con in listsContainer.Connections on pos.IDPosition equals con.IDPosition
                               where con.IDProfessor == ID
                               select pos.Position;
            foreach (var x in findPosition)
            {
                positions += $"{x} ";
            }
            return positions;
        }
    }
}
