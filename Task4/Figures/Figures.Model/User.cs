using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Model
{
    public class User 
    {
        public string Name { get; }

        public List<int> EntityIdList { get; }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name must not empty.");
            }

            Name = name;
            EntityIdList = new List<int>();
        }
    }
}
