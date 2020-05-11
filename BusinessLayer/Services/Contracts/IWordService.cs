
using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;


namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains methods for performing actions with words.
    /// </summary>
    /// <remarks>
    /// This class can get words in different ways, delete them and change their <c>WordStatus</c>.
    /// </remarks>
    public interface IWordService
    {
        /// <summary>
        /// Gets all words.
        /// </summary>
        /// <returns>
        /// Collection of all words.
        /// </returns>
        IEnumerable<WordDTO> GetAll();
        /// <summary>
        /// Get words with certain random name.
        /// </summary>
        /// <returns>Collection of words with the same random name.</returns>
        IEnumerable<WordDTO> GetRandom();
        /// <summary>
        /// Get words with certain name.
        /// </summary>
        /// <param name="name">Word Name.</param>
        /// <returns>Collection of words with certain name.</returns>
        IEnumerable<WordDTO> GetByName(string name);
        /// <summary>
        ///  Deletes word and return true if exists.
        /// </summary>
        /// <param name="id">Word Id</param>
        /// <returns>Returns true if word is successfully deleted.</returns>
        bool TryDelete(long id);
        IEnumerable<WordDTO> GetTopTen();
        IEnumerable<WordDTO> GetLastTenAdded();
        /// <summary>
        /// Approves word and return true if exists and its status is OnModeration.
        /// </summary>
        /// <param name="id">Word Id</param>
        /// <returns>Returns true if word is successfully approved.</returns>        
        bool TryApproveWord(long id);
        bool TryDisapproveWord(long id);
        IEnumerable<WordDTO> GetByTagName(string tag);
    }
}
