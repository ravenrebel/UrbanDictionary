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
    public class WordsController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public WordsController(IServiceWrapper serviceWrapper)
        {
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

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            if (_serviceWrapper.Word.TryDelete(id)) return Ok(id);
            return NotFound(id);
        }

        [HttpPut("approve/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Approve(long id)
        {
            if (_serviceWrapper.Word.TryApproveWord(id)) return Ok(id);
            return BadRequest(id);
        }

        [HttpPut("disapprove/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Disapprove(long id)
        {
            if (_serviceWrapper.Word.TryDisapproveWord(id)) return Ok(id);
            return BadRequest(id);
        }

        [HttpGet("getByTag/{tag}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> GetByTag(string tag)
        {
            IEnumerable<WordDTO> words = _serviceWrapper.Word.GetByTagName(tag);
            return Ok(words);
        }
    }
}
