namespace DesignPatternSamples.StructuralPatterns.Proxy
{
    public interface IStorage
    {
        void GetFile(string key);
        void CloseFile(string key);
        void DeleteFile(string key);
    }
}
