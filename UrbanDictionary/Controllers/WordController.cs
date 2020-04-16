using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using UrbanDictionary.BussinessLayer.DTO;
using UrbanDictionary.BussinessLayer.Services.Contracts;


namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/words")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<WordDTO> _logger;
        private readonly IServiceWrapper _serviceWrapper;

        public WordController(ILogger<WordDTO> logger, IServiceWrapper serviceWrapper)
        {
            _logger = logger;
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public IEnumerable<WordDTO> Get()
        {
            return _serviceWrapper.Word.GetAll();
        }

        [HttpGet("getRandomWord")]
        public WordDTO GetRandom()
        {
            return _serviceWrapper.Word.GetRandom();
        }
    }
}
