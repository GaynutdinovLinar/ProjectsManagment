namespace Projects.Service
{
    public class DllCommands
    {
        private readonly string _directorySave = Path.Combine(Environment.CurrentDirectory, "DllCommands");

        public DllCommands()
        {
            if (!Directory.Exists(_directorySave))
                Directory.CreateDirectory(_directorySave);
        }

        public string[] Dlls => Directory.GetFiles(_directorySave);

        public void AddDll(string dll)
        {
            if (Dlls.Contains(dll))
                throw new Exception($"Dll с названием {dll} уже содержится в папке {_directorySave}");

            File.Create(Path.Combine(_directorySave,dll));
        }

        public static DllCommands GetDllCommands() => new DllCommands();
    }
}
