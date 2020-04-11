using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrbanDictionary.DataAccess.Repositories.Contracts;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<Test> _logger;
        private readonly IRepositoryWrapper _repoWrapper;

        public WordController(ILogger<Test> logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public string Get()
        {
            return "The best dictionary ever";
        }
    }
}
