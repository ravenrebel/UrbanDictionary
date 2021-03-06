﻿using System;
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
            return Ok(_serviceWrapper.Word.GetByName(name, skipNumber));
        }

        [HttpGet("searchCount/{name}")]
        public ActionResult<long> GetCountByName(string name)
        {
            return _serviceWrapper.Word.GetCountByName(name);
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Moderator")]
        public ActionResult Delete(long id)
        {
            _serviceWrapper.Word.Delete(id);
            return Ok(id);
        }

        [HttpPost("approve/{id}"), Authorize(Roles = "Moderator")]
        public ActionResult Approve(long id)
        {
            if (_serviceWrapper.Word.ApproveWord(id)) return Ok(id);
            return NotFound(id);
        }

        [HttpPost("disapprove/{id}"), Authorize(Roles = "Moderator")]
        public ActionResult Disapprove(long id)
        {
            if (_serviceWrapper.Word.DisapproveWord(id)) return Ok(id);
            return NotFound(id);
        }

        [HttpGet("getByTag/{tag}")]
        public ActionResult<IEnumerable<WordDTO>> GetByTag(string tag)
        {
            return Ok(_serviceWrapper.Word.GetByTagName(tag));
        }

        [HttpPost("like/{id}")]
        public ActionResult Like(long id)
        {
            if (_serviceWrapper.Word.LikeWord(id)) return Ok(id);
            return NotFound(id);
        }

        [HttpPost("dislike/{id}")]
        public ActionResult Dislike(long id)
        {
            if (_serviceWrapper.Word.DislikeWord(id)) return Ok(id);
            return NotFound(id);
        }
    }
}
