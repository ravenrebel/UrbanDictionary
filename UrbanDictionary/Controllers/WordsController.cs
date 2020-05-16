using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<IEnumerable<WordDTO>> Get()
        {
            return Ok(_serviceWrapper.Word.GetAll());
        }

        [HttpGet("topTen")]
        public ActionResult<IEnumerable<WordDTO>> GetTopTen()
        {
            return Ok(_serviceWrapper.Word.GetTopTen());
        }

        [HttpGet("lastTen")]
        public ActionResult<IEnumerable<WordDTO>> GetLastTenAdded()
        {
            return Ok(_serviceWrapper.Word.GetLastTenAdded());
        }

        [HttpGet("randomWord")]
        public ActionResult<IEnumerable<WordDTO>> GetRandom()
        {
            return Ok(_serviceWrapper.Word.GetRandom());
        }
        
        [HttpGet("search/{name}/{skipNumber}")]
        public ActionResult<IEnumerable<WordDTO>> GetByName(string name, int skipNumber)
        {
            var words = _serviceWrapper.Word.GetByName(name, skipNumber);
            if (words != null)
                return Ok(words);
            else return BadRequest(name);
        }

        [HttpGet("searchCount/{name}")]
        public ActionResult<long> GetCountByName(string name)
        {
            return _serviceWrapper.Word.GetCountByName(name);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(long id)
        {
            if (_serviceWrapper.Word.TryDelete(id)) return Ok(id);
            return NotFound(id);
        }

        [HttpPut("approve/{id}")]
        public ActionResult Approve(long id)
        {
            if (_serviceWrapper.Word.TryApproveWord(id)) return Ok(id);
            return BadRequest(id);
        }

        [HttpPut("disapprove/{id}")]
        public ActionResult Disapprove(long id)
        {
            if (_serviceWrapper.Word.TryDisapproveWord(id)) return Ok(id);
            return BadRequest(id);
        }

        [HttpGet("getByTag/{tag}")]
        public ActionResult<IEnumerable<WordDTO>> GetByTag(string tag)
        {
            return Ok(_serviceWrapper.Word.GetByTagName(tag));
        }
    }
}
