using System.Net;
using MirrorData.Interface;
using RestSharp;

namespace MirrorData.Implementation
{
    public class SynchronizableSource<TT,TS> : Source<TT,TS>, ISynchronizableSource<TT,TS>
    {
        #region Private Propeerties

        private readonly string _creationUrl;
        #endregion

        #region C...tor
        public SynchronizableSource(IClient<TT,TS> source, string creationUrl) : base(source)
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
