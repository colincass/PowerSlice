﻿using System.Collections.Generic;
using EPiServer.Shell.ContentQuery;

namespace PowerSlice
{
    public interface IContentSlice : IContentQuery, ISortableContentSlice
    {
        int Order { get; }
        IEnumerable<CreateOption> CreateOptions { get; }
    }
}