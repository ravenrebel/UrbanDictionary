﻿
using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.DataAccess.Entities;


namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains methods for performing actions with <see cref="Word"/>s.
    /// </summary>
    /// <remarks>
    /// This class can get words in different ways, delete them and change their .
    /// </remarks>
    public interface IWordService
    {
        /// <summary>
        /// Gets all words.
        /// </summary>
        /// <returns>
        /// Collection of all <see cref="WordDTO"/>s.
        /// </returns>
        IEnumerable<WordDTO> GetAll();
        /// <summary>
        /// Gets words with certain random name.
        /// </summary>
        /// <returns>Collection of <see cref="WordDTO"/>s with the same random name.</returns>
        IEnumerable<WordDTO> GetRandom();
        /// <summary>
        /// Gets <see cref="WordDTO"/>s with certain name on certain page.
        /// </summary>
        /// <param name="name"><see cref="Word.Name"/>.</param>
        /// <param name="skipNumber">Number of skipped words</param>
        /// <returns>Collection of words with certain name.</returns>
        IEnumerable<WordDTO> GetByName(string name, int skipNumber);
        /// <summary>
        /// Return count of words with certain name on certain page.
        /// </summary>
        /// <param name="name"><see cref="Word.Name"/></param>
        /// <returns>Count of searched words.</returns>
        long GetCountByName(string name);
        /// <summary>
        ///  Deletes word and return true if exists.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        void Delete(long id);
        /// <summary>
        /// Gets top 10 words with the greatest <see cref="Word.LikesCount"/> and the smallest <see cref="Word.DislikesCount"/>. 
        /// </summary>
        /// <returns><see cref="WordDTO"/> collection</returns>
        IEnumerable<WordDTO> GetTopTen();
        /// <summary>
        /// Gets last 10 words added to database. 
        /// </summary>
        /// <returns><see cref="WordDTO"/> collection</returns>
        IEnumerable<WordDTO> GetLastTenAdded();
        /// <summary>
        /// Approves <see cref="Word"/> and return true if exists and its status is <see cref="WordStatus.OnModeration"/>.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        /// <returns>Returns true if word is successfully approved.</returns>        
        bool ApproveWord(long id);
        /// <summary>
        /// Disapproves <see cref="Word"/> and return true if exists and its status is <see cref="WordStatus.OnModeration"/>.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        /// <returns>Returns true if <see cref="Word"/> is successfully disapproved.</returns>        
        bool DisapproveWord(long id);
        /// <summary>
        ///  Gets words by certain <see cref="Tag.Name"/>.
        /// </summary>
        /// <param name="tag"><see cref="TagDTO.Name"/></param>
        /// <returns><see cref="WordDTO"/> collection</returns>
        IEnumerable<WordDTO> GetByTagName(string tag);
        /// <summary>
        /// Likes a certain <see cref="Word"/> return true if exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if <see cref="Word"/> is successfully liked.</returns>
        bool LikeWord(long id);
        /// <summary>
        /// Dislikes a certain <see cref="Word"/> return true if exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if <see cref="Word"/> is successfully disliked.</returns>
        bool DislikeWord(long id);
    }
}
