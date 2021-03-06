﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using Treehouse.AspNetCore.Repositories;
using System.Net.Http;
using static Treehouse.AspNetCore.Models.UserModel;
using Treehouse.AspNetCore.Controllers;

namespace Treehouse.AspNetCore.Services
{
    public class UserService : IUserService
    {
        public bool Rest { get; set; }
        //private readonly IMongoCollection<User> _users;
        private readonly IBaseAuthModel _authModel;
        private readonly IUserRepository _repository;
        private static bool _auth;

        public UserService(IUserDatabaseSettings settings, IUserRepository userRepository, IBaseAuthModel model)
        {
            _authModel = model;
            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);
            //_users = database.GetCollection<User>(settings.UserCollectionName);
            _repository = userRepository;
            
        }

        //public List<User> Get() =>
        //    _users.Find(user => true).ToList();

        public bool GetAuth() => _repository.GetAuth();


        public void SetAuth(bool auth) => _repository.SetAuth(auth);
        public bool Login(LoginUser model) => _repository.Login(model);

        

        public bool Logout()
        {
            return _repository.Logout();
        }

        public UserModel GetProfile()
        {
           return _repository.GetProfile();
        }
    }
}
