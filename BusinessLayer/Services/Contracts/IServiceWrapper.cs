using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanDictionary.BusinessLayer.Services.Contracts
{
    public interface IServiceWrapper
    {
        IWordService Word { get; }
        IUserService User { get; }
        ITagService Tag { get; }
    }
}
