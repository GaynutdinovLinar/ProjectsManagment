namespace Projects.Service.Objects.Interfaces
{
    public interface IFileStorage
    {
        string FileStorageName { get; }

        string FileStoragePath { get; }
    }
}
