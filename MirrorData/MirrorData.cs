using System;
using System.Linq;
using MirrorData.CriteriaSolver;
using MirrorData.Implementation;
using MirrorData.Interface;

namespace MirrorData
{
    /// <summary>
    /// 
    /// </summary>
    public class MirrorData<TS,TT>
    {
        //TODO: Abstract int key for weird elements. At the moment, this approach is enough.
        #region Private Properties        
        /// <summary>
        /// The source
        /// </summary>
        private readonly IClient<TS, int> _source;
        /// <summary>
        /// The target
        /// </summary>
        private readonly IClient<TT,int> _target;
        /// <summary>
        /// The creation URL
        /// </summary>
        private readonly string _creationUrl;
        #endregion

        #region Public Properties
        public IConflictCriteriaSolver<TS, TT> ConflictCriteriaSolver { get; set; }
        #endregion

        #region MirrorData

        private MirrorData()
        {
            ConflictCriteriaSolver = new OverWriteCriteriaSolver<TS, TT>();
        }         
        /// <summary>
        /// Initializes a new instance of the <see cref="MirrorData"/> class.
        /// </summary>
        public MirrorData(IClient<TS,int> source, IClient<TT,int> target,string creationUrl) :base()
        {
            this._source = source;
            this._target = target;
            this._creationUrl = creationUrl;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapperFunc"></param>
        public void Synch(Func<TS,TT> mapperFunc)
        {
            var src = new Source<TS, int>(_source);
            var dest = new SynchronizableSource<TT,int>(_target,_creationUrl);
            foreach (var el in src)
            {
                var keySource = _source.GetId(el);
                var remoteElement = dest.First(targetEl => _target.GetId(targetEl) == keySource);
                if (remoteElement == null)
                {
                    var elementToCreate = mapperFunc(el);
                    dest.CreateElement(elementToCreate);
                }
                else
                {
                    var finalEl = ConflictCriteriaSolver.Resolve(el, remoteElement, mapperFunc);
                    dest.UpdateElement(finalEl);
                }
            }
        }
        #endregion
    }
}
