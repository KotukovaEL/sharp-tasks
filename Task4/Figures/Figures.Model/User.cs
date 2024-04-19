using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Model
{
    public class User 
    {
        public string Name { get; set; }

        public List<int> EntityIdList { get; } = new List<int>();

        public User()
        {
        }
    }
}
