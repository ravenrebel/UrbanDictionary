using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IServiceWrapper
    {
        IWordService Word { get; }
        IUserWordsService UserWords { get; }
        ITagService Tag { get; }
        IUserService User { get; }
    }
}
