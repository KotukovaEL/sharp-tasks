using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Interface
{
    public interface IUsersWriter
    {
        void SaveChanges(Dictionary<string, User> entitiesMap);
    }
}
