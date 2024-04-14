using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class UserDto
    {

        public string Name { get; set; }

        public List<int> EntityIdList { get; set; } = new();

        public UserDto()
        {
        }
    }
}
