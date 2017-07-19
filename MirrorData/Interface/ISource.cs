using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirrorData.Interface
{
    public interface ISource<TT,TKey>:IEnumerable<TT>
    {
        void SetSource(IEnumerable<TT> source);
        Func<TT, TKey> FncGetKey { get; }
    }
}
