using System;
using System.Collections.Generic;
using MirrorData.Interface;
using RestSharp;

namespace MirrorData.Implementation
{
    public class SynchronizableSource<TT, TKey> : Source<TT, TKey>, ISynchronizableSource<TT, TKey>
    {
        #region Private Propeerties

        private readonly string _creationUrl;
        #endregion

        #region C...tor
        public SynchronizableSource(IEnumerable<TT> source, string creationUrl, Func<TT, TKey> fncKey) : base(source, fncKey)
        {
            _creationUrl = creationUrl;
        }
        #endregion

        #region Implementation of ISynchronizableSource<TT,TKey>

        public void CreateElement(TT element)
        {
            var url = new RestClient();
            var request = new RestRequest(this._creationUrl);
            request.AddBody(element);
            request.Method = Method.POST;
            url.Execute(request);
        }

        public void UpdateElement(TT element)
        {
            var url = new RestClient();
            var request = new RestRequest(this._creationUrl);
            request.AddBody(element);
            request.Method = Method.PATCH;
            url.Execute(request);
        }

        public void DeleteElement(TT element)
        {
            var url = new RestClient();
            var request = new RestRequest(this._creationUrl);
            request.AddBody(element);
            request.Method = Method.DELETE;
            url.Execute(request);
        }

        #endregion
    }
}
