using System;
using System.Collections.Generic;
using System.Text;
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.BussinessLayer.Services
{
    public class TagService : ITagService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public TagService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
    }
}
