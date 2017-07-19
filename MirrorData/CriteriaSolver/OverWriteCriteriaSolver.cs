namespace MirrorData.CriteriaSolver
{
    public class OverWriteCriteriaSolver<TT,TS> : IConflictCriteriaSolver<TT,TS>
    {
        #region Implementation of IConflictCriteriaSolver<TT,TS>

        public TS Resolve(TT source, TS target)
        {
            return target;
        }

        #endregion
    }
}
