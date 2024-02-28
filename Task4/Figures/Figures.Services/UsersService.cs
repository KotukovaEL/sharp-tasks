using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Figures.Repositories;
using System.Linq;

namespace Figures.Services
{
    public class UsersService
    {
        private readonly Dictionary<string, User> _userMap;
        private readonly string _filePath;
        private readonly TxtDbContext _txtDbContext;

        public UsersService(string filePath, TxtDbContext txtDbContext)
        {
            _filePath = filePath;
            _userMap = new Dictionary<string, User>();
            _txtDbContext = txtDbContext;
            ReadFile();
        }
        public void AddFigure(string name, GeometricEntity geometricEntity)
        {
            var user = GetUser(name);
            _txtDbContext.Add(geometricEntity);
            user.IdGeometricEntities.Add(geometricEntity.Id);
            _txtDbContext.SaveChanges();
            SaveChanges();
        }

        public List<GeometricEntity> ListFigures(string name)
        {
            var idFigures = new List<GeometricEntity>();
            var user = GetUser(name);
            _txtDbContext.SaveChanges();

            foreach (var idEntity in user.IdGeometricEntities)
            {
                var entity = _txtDbContext.GetEntityById(idEntity);
                idFigures.Add(entity);
            }

            return idFigures;//выводить список фигур
        }

        public void DeleteFigures(string name)
        {
            var user = GetUser(name);
            user.IdGeometricEntities.Clear();
            _txtDbContext.SaveChanges();
            SaveChanges();
        }

        public void Authorize(string name)
        {
            _userMap.TryAdd(name, new User(name));
            SaveChanges();
        }

        private User GetUser(string name)
        {
            if (!_userMap.TryGetValue(name, out User user))
            {
                throw new ArgumentException($"User {name} was not found");
            }

            return user;
        }

        private void SaveChanges()
        {
            using var fs = new FileStream(_filePath, FileMode.Create);
            using var stream = new StreamWriter(fs);
            
            foreach (var user in _userMap.Values)
            {
                stream.WriteLine($" Name: {user.Name}");
                stream.WriteLine($" Figures: {string.Join(',', user.IdGeometricEntities)}");
                stream.WriteLine();
            } 
        }

        public void ReadFile() 
        {
            var lines = File.ReadAllLines(_filePath);
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();
                string name = "";
                User? user = null;

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var value = "0";
                    var separator = ":";
                    var separatorIndex = str.IndexOf(separator);
                    var key = str.Substring(0, separatorIndex);

                    if (str.EndsWith(separator))
                    {
                        value = string.Empty;
                        continue;
                    }

                    value = str.Substring(separatorIndex + 1 + separator.Length);
                    map.Add(key, value);
                    continue;
                }

                if (map.Count != 0)
                {
                    var figureIdsStr = "";
                    name = _txtDbContext.GetFieldValue(map, "Name");

                    try
                    {
                        figureIdsStr = _txtDbContext.GetFieldValue(map, "Figures");
                    }
                    catch (Exception ex) 
                    {
                        figureIdsStr = "0";
                    }

                    List<int> entityList = new List<int>();

                    if (figureIdsStr != "0")
                    {
                        entityList = figureIdsStr.Split(",").Select(int.Parse).ToList();
                        user = new User(name);
                        user.IdGeometricEntities.AddRange(entityList);
                    }

                    user = new User(name);
                    user.IdGeometricEntities.AddRange(entityList);

                }

                if (name is not null && user is not null)
                {
                    _userMap.Add(name, user);
                    map.Clear();
                    continue;
                }
            }
        }
    }
}