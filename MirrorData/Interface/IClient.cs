using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirrorData.Interface
{
    public interface IClient<TT, out TKey>
    {
        /// <summary>
        /// Lists the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<TT>> ListAsync();

        TKey GetId(TT entity);
    }
}