
using System.Collections.Generic;
using System.Linq;

namespace UrbanDictionary.BusinessLayer.DTO.Mapper
{
    /// <summary>
    /// Contains methods that convert entities to data transfer object and vise versa.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDTO">Data transfer object</typeparam>
    public interface IMapper<TEntity, TDTO>
    {
        /// <summary>
        /// Converts entity to data transfer object.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        TDTO MapToDTO(TEntity entity);
        /// <summary>
        /// Converts data transfer object to certain entity.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TEntity MapToEntity(TDTO dto);

        /// <summary>
        /// Converts the collection of data transfer objects to collection of entities.
        /// </summary>
        /// <param name="dtos">Collection of data transfer objects.</param>
        /// <returns></returns>
        IEnumerable<TEntity> MapToEntity(IEnumerable<TDTO> dtos)
        {
            if (dtos != null) return dtos.Select(d => MapToEntity(d));
            else return null;
        }

        /// <summary>
        /// Converts the collection of entities to collection of data transfer objects.
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <returns></returns>
        IEnumerable<TDTO> MapToDTO(IEnumerable<TEntity> entities)
        {
            if (entities != null) return entities.Select(e => MapToDTO(e));
            else return null;
        }
    }
}
