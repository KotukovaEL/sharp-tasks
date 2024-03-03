using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Common.Interfaces
{
    public interface IUsersRepository
    {
        void SaveChanges();
        User GetUser(string name);
        void TryAdd(string name);
    }
}
