using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class Filter
    {
        public IEnumerable<Guid> ItemTypes { get; }

        public Filter(IEnumerable<Guid> itemTypes)
        {
            ItemTypes = itemTypes;
        }
    }
}
