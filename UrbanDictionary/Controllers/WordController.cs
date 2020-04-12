using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using UrbanDictionary.BussinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<Word> _logger;
        private readonly IServiceWrapper _serviceWrapper;

        public WordController(ILogger<Word> logger, IServiceWrapper serviceWrapper)
        {
            _logger = logger;
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IEnumerable<Word> Get()
        {
            return _serviceWrapper.Word.GetAll();
        }
    }
}
