using Projects.Service.Objects.Interfaces;

namespace Projects.Service.Objects
{
    public class Project : IFileStorage
    {
        public Project()
        {
            Commands = new List<ProjectCommand>();
            CreateFileStorage();
        }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? ServerName { get; set; }

        public string? DatabaseName { get; set; }

        public List<ProjectCommand> Commands { get; set; }

        public string FileStorageName => $"{Name} - {Id}";

        public string FileStoragePath => Path.Combine(AppContext.BaseDirectory, FileStorageName);

        private void CreateFileStorage()
        {
            if (!Directory.Exists(FileStoragePath))
                Directory.CreateDirectory(FileStoragePath);
        }
    }
}