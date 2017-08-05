using System.Collections.Generic;

namespace MirrorData.Interface
{
    public interface ISource<TT,TS>:IEnumerable<TT>
    {
        void SetSource(IClient<TT,TS> source);
    }
}
