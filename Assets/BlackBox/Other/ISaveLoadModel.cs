namespace BlackBox
{
    public interface ISaveLoadModel
    {
        void Save<T>(T saveFile, string name) where T : class;
        T Load<T>(string name) where T : class;
    }
}
