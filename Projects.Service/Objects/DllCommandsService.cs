namespace Projects.Service.Objects
{
    public class DllCommandsService
    {
        private readonly string _directorySave = Path.Combine(Environment.CurrentDirectory, "DllCommands");

        public static DllCommandsService GetDllService() => new DllCommandsService();

        private DllCommandsService()
        {
            if (!Directory.Exists(_directorySave))
                Directory.CreateDirectory(_directorySave);
        }

        public string[] CommandDirectories => Directory.GetDirectories(_directorySave);

        public string[] AddDlls(string nameDirectory, params string[] dlls)
        {
            var commandDirectory = Path.Combine(_directorySave, nameDirectory);

            if (!CommandDirectories.Contains(commandDirectory))
                Directory.CreateDirectory(commandDirectory);

            var newDllPaths = new string[dlls.Length];

            for (int i = 0; i < newDllPaths.Length; i++)
            {
                var newDllPath = Path.Combine(commandDirectory, Path.GetFileName(dlls[i]));
                newDllPaths[i] = newDllPath;

                File.Copy(dlls[i], newDllPath);
            }

            return newDllPaths;
        }

        public void DeleteDlls(string nameDirectory)
        {
            var commandDirectory = Path.Combine(_directorySave, nameDirectory);
            Directory.Delete(commandDirectory);
        }
    }
}
