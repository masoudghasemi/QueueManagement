using Framework.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model.Concrete
{
    public class CollectionValue<TCollectionElement>: ICollectionValue<TCollectionElement>
    {
        public ICollection<TCollectionElement> Collection { get; set; }

        public long TotalCount { get; set; }

    }
}
