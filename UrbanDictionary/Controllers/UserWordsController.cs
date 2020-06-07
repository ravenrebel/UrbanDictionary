using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.BusinessLayer.Services.Contracts;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.Controllers
{
    [ApiController]
    [Route("api/currentUser"), Authorize]
    public class UserWordsController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;
        private readonly UserManager<User> _userManager;

        public UserWordsController(IServiceWrapper serviceWrapper, UserManager<User> userManager)
        {
            _serviceWrapper = serviceWrapper;
            _userManager = userManager;
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
        public ActionResult<CreateWordFormDTO> Create(CreateWordFormDTO word)
        {
            if (_serviceWrapper.UserWords.TryCreateWord(word)) return Created("", word);
            return BadRequest(word);
        }

        [HttpPut("editWord")]
        public ActionResult<CreateWordFormDTO> Edit(CreateWordFormDTO word)
        {
            if (_serviceWrapper.UserWords.TryEditCreatedWord(word))
            {
                return Ok(word);
            }
            return BadRequest(word);
        }

        [HttpDelete("deleteCreatedWord/{id}")]
        public ActionResult DeleteCreatedWords(long id)
        {
            if (_serviceWrapper.UserWords.TryDeleteCreatedWord(id))
            {
                return Ok(id);
            }
            return NotFound(id);
        }

        [HttpPost("sendToModerator/{id}")]
        public async Task<ActionResult> SendWordToModerator(long id)
        {
            var moderators = await _userManager.GetUsersInRoleAsync("Moderator");
            User moderator = moderators.OrderBy(m => new Guid()).FirstOrDefault();

            if (moderator != null)
                if (_serviceWrapper.UserWords.TryAddToSavedWords(id, moderator))
                {
                    return Ok(id);
                }
            return NotFound(id);
        }
    }
}