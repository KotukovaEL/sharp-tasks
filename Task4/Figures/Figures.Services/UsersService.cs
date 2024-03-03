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
            _txtDbContext.Add(geometricEntity);
            _txtDbContext.SaveChanges();

            var user = GetUser(name);
            user.EntityIdList.Add(geometricEntity.Id);
            SaveChanges();
        }

        public List<GeometricEntity> ListFigures(string name)
        {
            var entities = new List<GeometricEntity>();
            var user = GetUser(name);

            foreach (var id in user.EntityIdList)
            {
                var entity = _txtDbContext.GetEntityById(id);
                entities.Add(entity);
            }

            return entities;
        }

        public void DeleteFigures(string name)
        {
            var user = GetUser(name);
            _txtDbContext.DeleteFiguresByIds(user.EntityIdList);
            user.EntityIdList.Clear();
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
            using var writer = new StreamWriter(fs);

            foreach(var user in _userMap.Values)
            {
                writer.WriteLine($" Name: {user.Name}");
                writer.WriteLine($" Figures: {string.Join(',', user.EntityIdList)}");
                writer.WriteLine();
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

                var user = new User(name);

                if (entityIdsStr != string.Empty)
                {
                    var entityList = entityIdsStr.Split(",").Select(int.Parse).ToList();
                    user.EntityIdList.AddRange(entityList);
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