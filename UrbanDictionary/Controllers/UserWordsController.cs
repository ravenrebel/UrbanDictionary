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
        public ActionResult<IEnumerable<WordDTO>> GetSavedWords()
        {
            var savedWords = _serviceWrapper.UserWords.GetSavedWords();
            if (savedWords != null)
            {
                return Ok(savedWords);
            }
            return NotFound();
        }

        [HttpPost("saveWord/{id}")]
        public ActionResult SaveWord(long id)
        {
            if (_serviceWrapper.UserWords.TryAddToSavedWords(id))
            {
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpDelete("deleteSavedWord/{id}")]
        public ActionResult DeleteSavedWords(long id)
        {
            if (_serviceWrapper.UserWords.TryDeleteSavedWord(id))
            {
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpGet("createdWords")]
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
        public ActionResult<CreateEditFormWordDTO> Create(CreateEditFormWordDTO word)
        {
            if (_serviceWrapper.UserWords.TryCreateWord(word)) return Created("", word);
            return BadRequest(word);
        }

        [HttpPut("editWord")]
        public ActionResult<CreateEditFormWordDTO> Edit(CreateEditFormWordDTO word)
        {
            if (_serviceWrapper.UserWords.TryEditWord(word))
            {
                return Ok(word);
            }
            return BadRequest(word);
        }
    }
}