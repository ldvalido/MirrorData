namespace MirrorData.Interface
{
    public interface ISynchronizableSource<TT,TKey> : ISource<TT,TKey>
    {
        void CreateElement(TT element);
        bool UpdateElement(TT element);
    }
}
