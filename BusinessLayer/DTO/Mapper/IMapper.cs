
using System.Collections.Generic;
using System.Linq;

namespace UrbanDictionary.BusinessLayer.DTO.Mapper
{
    public interface IMapper<TEntity, TDTO>
    {
        TDTO MapToDTO(TEntity entity);
        TEntity MapToEntity(TDTO dto);

        IEnumerable<TEntity> MapToEntity(IEnumerable<TDTO> dtos)
        {
            if (dtos != null) return dtos.Select(d => MapToEntity(d));
            else return null;
        }

        IEnumerable<TDTO> MapToDTO(IEnumerable<TEntity> entities)
        {
            if (entities != null) return entities.Select(e => MapToDTO(e));
            else return null;
        }
    }
}
