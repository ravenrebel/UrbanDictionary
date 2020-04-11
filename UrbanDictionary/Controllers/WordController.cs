using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using UrbanDictionary.DataAccess.Entities;
using UrbanDictionary.DataAccess.Repositories.Contracts;
using System.IO;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<Word> _logger;
        private readonly IRepositoryWrapper _repoWrapper;

        public WordController(ILogger<Word> logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<Word> Get()
        {
            return _repoWrapper.Word.FindAll().ToList();
        }
    }
}
