using System;
using System.Collections;
using System.Collections.Generic;
using MirrorData.Interface;

namespace MirrorData.Implementation
{
    public class Source<TT,TKey> : ISource<TT,TKey>
    {
        #region Private Properties
        private IEnumerable<TT> _data;
        private readonly string _urlCreate;
        #endregion

        #region Public Properties
        public Func<TT, TKey> FncGetKey { get; }

        #endregion

        #region C...tor
        public Source(IEnumerable<TT> source, Func<TT, TKey> fncKey)
        {
            _data = source;
            FncGetKey = fncKey;
        } 
        #endregion

        #region Implementation of ISource<T>
        public void SetSource(IEnumerable<TT> source)
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
            return _data.GetEnumerator();
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
