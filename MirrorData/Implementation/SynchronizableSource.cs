using System;
using System.Collections.Generic;
using System.Net;
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

        public bool UpdateElement(TT element)
        {
            var url = new RestClient(_creationUrl);
            var request = new RestRequest(Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(element);
            var response = url.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
        #endregion
    }
}
