using Projects.Service.Objects.Interfaces;

namespace Projects.Service.Objects
{
    public class ProjectCommand : IFileStorage
    {
        public ProjectCommand()
        {
            CreateFileStorage();
        }

        public Guid Id { get; set; }

        public Project Project { get; set; }

        public string Name { get; set; }

        public string StrartingDll { get; set; }

        public string FileStorageName => $"{Name} - {Id}";

        public string FileStoragePath => Path.Combine(Project.FileStoragePath, FileStorageName);

        //public string[] Dlls
        //{
        //    get
        //    {
        //        var nameDirectory = Id.ToString();
        //        var directory = _dllService.CommandDirectories.FirstOrDefault(x => x == nameDirectory);

        //        if (directory == null)
        //            throw new Exception($"Не удалось найти папку команды с dlls \"{nameDirectory}\"");

        //        return Directory.GetFiles(directory);
        //    }
        //}

        private void CreateFileStorage()
        {
            if (!Directory.Exists(FileStoragePath))
                Directory.CreateDirectory(FileStoragePath);
        }
    }
}
