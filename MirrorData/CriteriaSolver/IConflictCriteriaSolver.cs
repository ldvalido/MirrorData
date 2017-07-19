namespace MirrorData.CriteriaSolver
{
    public interface IConflictCriteriaSolver<TT,TS>
    {
        TS Resolve(TT source, TS target);
    }
}
