using Figures.Model;
using Figures.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Figures.Services
{
    public class UsersService
    {
        private readonly Dictionary<string, User> _userMap = new();
        private readonly string _filePath;
        private readonly TxtDbContext _txtDbContext;

        public UsersService(string filePath, TxtDbContext txtDbContext)
        {
            _filePath = filePath;
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

            foreach (var idEntity in user.IdGeometricEntities)
            {
                var entity = _txtDbContext.GetEntityById(idEntity);
                idFigures.Add(entity);
            }

            return idFigures;
        }

        public void DeleteFigures(string name)
        {
            var user = GetUser(name);
            _txtDbContext.DeleteFiguresByIds(user.IdGeometricEntities);
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
            var name = "";
            var entityIdsStr = "";

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    TryGetValue(line, "Name", out name);
                    TryGetValue(line, "Figures", out entityIdsStr);
                    continue;
                }

                var user = new User (name);

                if (entityIdsStr != string.Empty)
                {
                    var entityList = entityIdsStr.Split(",").Select(int.Parse).ToList();
                    user.IdGeometricEntities.AddRange(entityList);
                }

                
                _userMap.Add(name, user);
                name = null;
                entityIdsStr = null;
            }
        }

        private bool TryGetValue(string str, string key, out string value)
        {
            if ()

            var indexKey = str.IndexOf(key);
            value = str.Substring(indexKey + key.Length + 2);
            return true;
        }
    }
}