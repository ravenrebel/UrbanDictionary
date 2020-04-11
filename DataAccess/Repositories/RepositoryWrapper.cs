using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using UrbanDictionary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace UrbanDictionary.DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository _user;
        private ITagRepository _tag;
        private IWordRepository _word;
        private UrbanDictionaryDBContext _dbContext;

        public RepositoryWrapper(UrbanDictionaryDBContext urbanDictionaryDBContext)
        {
            _dbContext = urbanDictionaryDBContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dbContext);
                }

                return _user;
            }
        }

        public IWordRepository Word
        {
            get
            {
                if (_word == null)
                {
                    _word = new WordRepository(_dbContext);
                }

                return _word;
            }
        }

        public ITagRepository Tag
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagRepository(_dbContext);
                }

                return _tag;
            }
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
