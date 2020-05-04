using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/currentUser")]
    public class UserWordsController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public UserWordsController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet("savedWords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WordDTO>> GetSavedWords()
        {
            var savedWords = _serviceWrapper.UserWords.GetSavedWords();
            if (savedWords != null)
            {
                return Ok(savedWords);
            }
            return NotFound();
        }

        [HttpPost("saveWord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SaveWord(long id)
        {
            if (_serviceWrapper.UserWords.TryAddToSavedWords(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("deleteSavedWord/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSavedWords(long id)
        {
            if (_serviceWrapper.UserWords.TryDeleteSavedWord(id))
            {
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpGet("createdWords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WordDTO>> GetCreatedWords()
        {
            var createdWords = _serviceWrapper.UserWords.GetCreatedWords();
            if (createdWords != null)
            {
                return Ok(createdWords);
            }
            return NotFound();
        }

        [HttpPost("createWord")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<WordDTO> Create(WordDTO wordDto)
        {
            if (_serviceWrapper.UserWords.TryCreateWord(wordDto)) return Created("", wordDto);
            return BadRequest();
        }
    }
}