using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;


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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> Get()
        {
            return Ok(_serviceWrapper.Word.GetAll());
        }

        [HttpGet("topTen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetTopTen()
        {
            return Ok(_serviceWrapper.Word.GetTopTen());
        }

        [HttpGet("lastTen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetLastTenAdded()
        {
            return Ok(_serviceWrapper.Word.GetLastTenAdded());
        }

        [HttpGet("randomWord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetRandom()
        {
            return Ok(_serviceWrapper.Word.GetRandom());
        }
        
        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetByName(string name)
        {
            IEnumerable<WordDTO> words = _serviceWrapper.Word.GetByName(name);
            return Ok(words);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<WordDTO> Create(WordDTO wordDto)
        {
            if (_serviceWrapper.Word.TryCreate(wordDto)) return Created("", wordDto);
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            if (_serviceWrapper.Word.TryDelete(id)) return Ok(id);
            return NotFound(id);
        }
    }
}
