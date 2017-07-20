using System;
using System.Linq;
using MirrorData.CriteriaSolver;
using MirrorData.Interface;

namespace MirrorData
{
    /// <summary>
    /// 
    /// </summary>
    public class MirrorData<TT,TS>
    {
        //TODO: Abstract int key for weird elements. At the moment, this approach is enough.
        #region Private Properties        
        /// <summary>
        /// The source
        /// </summary>
        private readonly ISource<TT,int> _source;
        /// <summary>
        /// The target
        /// </summary>
        private readonly ISynchronizableSource<TS,int> _target;
        #endregion

        #region MirrorData        
        /// <summary>
        /// Initializes a new instance of the <see cref="MirrorData"/> class.
        /// </summary>
        public MirrorData(ISource<TT,int> source,ISynchronizableSource<TS,int> target)
        {
            this._source = source;
            this._target = target;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="solver"></param>
        /// <param name="mapperFunc"></param>
        public void Synch(IConflictCriteriaSolver<TT,TS> solver,Func<TT,TS> mapperFunc)
        {
            foreach (var el in _source)
            {
                var keySource = _source.FncGetKey(el);
                var remoteElement = _target.First(targetEl => _target.FncGetKey(targetEl) == keySource);
                if (remoteElement == null)
                {
                    var elementToCreate = mapperFunc(el);
                    _target.CreateElement(elementToCreate);
                }
                else
                {
                    var finalEl = solver.Resolve(el, remoteElement,mapperFunc);
                    _target.UpdateElement(finalEl);
                }
            }
        }
        #endregion
    }
}
