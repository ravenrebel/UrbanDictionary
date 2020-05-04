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
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public UsersController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet("savedWords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WordDTO>> GetSavedWords()
        {
            var savedWords = _serviceWrapper.User.GetSavedWords();
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
            if (_serviceWrapper.User.TryAddToSavedWords(id))
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
            if (_serviceWrapper.User.TryDeleteSavedWord(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("createdWords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WordDTO>> GetCreatedWords()
        {
            var createdWords = _serviceWrapper.User.GetCreatedWords();
            if (createdWords != null)
            {
                return Ok(createdWords);
            }
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WordDTO>> Get()
        {
            return Ok(_serviceWrapper.User.GetUsers());
        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            if (_serviceWrapper.User.TryDeleteUser(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}