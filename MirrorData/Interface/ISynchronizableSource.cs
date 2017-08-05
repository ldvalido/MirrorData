namespace MirrorData.Interface
{
    public interface ISynchronizableSource<TT,TS> : ISource<TT,TS>
    {
        void CreateElement(TT element);
        bool UpdateElement(TT element);
    }
}
