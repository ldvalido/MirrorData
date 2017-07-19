namespace MirrorData.Interface
{
    public interface ISynchronizableSource<TT,TKey> : ISource<TT,TKey>
    {
        void CreateElement(TT element);
        void UpdateElement(TT element);
        void DeleteElement(TT element);
    }
}
