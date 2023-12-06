using Code.Data;

namespace Code.Map
{
    public  interface IItemCreatePoint
    {
        MapItemData Data { get; }
        float Radius { get; }

        void Create();
    }
}
