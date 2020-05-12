
using System.Collections.Generic;
using UrbanDictionary.BusinessLayer.DTO;
using UrbanDictionary.DataAccess.Entities;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    /// <summary>
    /// Contains methods for performing interaction between words and <see cref="User"/>.
    /// </summary>
    /// <remarks>
    /// This class can get saved and created words, delete words from saved ones and edit created ones.
    /// </remarks>
    public interface IUserWordsService
    {
        /// <summary>
        /// Gets current <see cref="User"/> saved words.
        /// </summary>
        /// <returns>Returns null when operation did not succeed.</returns>
        public IEnumerable<WordDTO> GetSavedWords();
        /// <summary>
        /// Saves the <see cref="Word"/> for current <see cref="User"/> and return true if succeeded.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        public bool TryAddToSavedWords(long id);
        /// <summary>
        /// Saves the <see cref="Word"/> for specific <see cref="User"/> and return true if succeeded.
        /// </summary>
        /// <param name="wordId"><see cref="WordDTO.Id"/></param>
        /// <param name="user"><see cref="User"/> that saves the specific <see cref="Word"/></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        public bool TryAddToSavedWords(long wordId, User user);
        /// <summary>
        /// Saves the <see cref="Word"/> for current <see cref="User"/> and returns true if succeeded.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        public bool TryDeleteSavedWord(long id);
        /// <summary>
        /// Gets current <see cref="User"/> created words.
        /// </summary>
        /// <returns>Returns null when operation did not succeed.</returns>
        public IEnumerable<WordDTO> GetCreatedWords();
        /// <summary>
        /// Creates the new <see cref="Word"/> and make the current <see cref="User"/> its author.,  and returns true if succeeded.
        /// </summary>
        /// <param name="wordDto"></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        bool TryCreateWord(CreateEditFormWordDTO wordDto);
        /// <summary>
        /// Edits <see cref="Word"/> if current <see cref="User"/> is its author and returns true if succeeded.
        /// </summary>
        /// <param name="wordDTO"></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        bool TryEditCreatedWord(CreateEditFormWordDTO wordDTO);
        /// <summary>
        /// Deletes <see cref="Word"/> if current <see cref="User"/> is its author and returns true if succeeded.
        /// </summary>
        /// <param name="id"><see cref="WordDTO.Id"/></param>
        /// <returns>Returns false when operation did not succeed.</returns>
        bool TryDeleteCreatedWord(long id);
    }
}
