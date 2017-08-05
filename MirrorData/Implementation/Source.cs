using System.Collections;
using System.Collections.Generic;
using MirrorData.Interface;

namespace MirrorData.Implementation
{
    public class Source<TT,TS> : ISource<TT,TS>
    {
        #region Private Properties
        private IClient<TT, TS> _data;
        #endregion

        #region C...tor
        public Source(IClient<TT,TS> source)
        {
            _data = source;
        } 
        #endregion

        #region Implementation of ISource<T>
        public void SetSource(IClient<TT, TS> source)
        {
            _data = source;
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<TT> GetEnumerator()
        {
            return _data.ListAsync().Result.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
