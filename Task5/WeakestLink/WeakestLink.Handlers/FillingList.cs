using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public class FillingList : IFillingList
    {
        public List<int> FillList(int numberPeople)
        {
            var peopleList = new List<int>(numberPeople);

            for (int i = 1; i <= peopleList.Capacity; i++)
            {
                peopleList.Add(i);
            }

            return peopleList;
        }
    }
}
