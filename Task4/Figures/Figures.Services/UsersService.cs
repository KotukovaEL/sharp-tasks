using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;

namespace Figures.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGeometricEntitiesRepository _entitiesRepository;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IGeometricEntitiesRepository entitiesRepository, IUsersRepository usersRepository)
        {
            _entitiesRepository = entitiesRepository;
            _usersRepository = usersRepository;
        }

        public void AddFigure(string name, GeometricEntity geometricEntity)
        {
            _entitiesRepository.Add(geometricEntity);
            _usersRepository.AddFigure(name, geometricEntity.Id);            
        }

        public List<GeometricEntity> ListFigures(string name)
        {
            var entities = new List<GeometricEntity>();
            var user = _usersRepository.GetUser(name);

            foreach (var entityId in user.EntityIdList)
            {
                var entity = _entitiesRepository.GetEntityById(entityId);
                entities.Add(entity);
            }

            return entities;
        }

        public void DeleteFigures(string name)
        {
            var user = _usersRepository.GetUser(name);
            _entitiesRepository.DeleteFiguresByIds(user.EntityIdList);
            user.EntityIdList.Clear();
        }

        public void Authorize(string name)
        {
            _usersRepository.TryAdd(name);
        }
    }
}