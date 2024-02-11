using Figures.Model;
using Figures.Services;
using System;
using System.Collections.Generic;

namespace Users
{
    public class User 
    {
        private readonly string _name;

        public List<GeometricEntity> Figures{ get; }

        public User(string name)
        {
            _name = name;
        }

    }
}
