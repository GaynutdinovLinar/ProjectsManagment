using Integration.Command.General;
using Projects.Service.Objects;
using System.Reflection;
using CommandIntegrated = Integration.Command.General.Command;

namespace Integration.Command.Service
{
    public static class Extenstion
    {
        public static async void Start(this ProjectCommand command)
        {
            var startingDll = Directory.GetFiles(command.FileStoragePath).FirstOrDefault(x => Path.GetFileName(x) == command.StrartingDll);

            if (startingDll == null)
                throw new Exception($"Не удалось найти запускаемое dll в папке команды с dlls \"{command.FileStoragePath}\"");

            var assembly = Assembly.LoadFrom(startingDll);

            var type = assembly.GetTypes().Where(t => t.IsDefined(typeof(CommandAttribute)) && t.IsSubclassOf(typeof(CommandIntegrated))).FirstOrDefault();
            if (type is null)
                throw new Exception($"В dll - \"{startingDll}\" не найден класс наследуемый от {nameof(CommandIntegrated)} и с атрибутом {nameof(CommandAttribute)}");

            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor is null)
                throw new Exception($"В dll - \"{startingDll}\" класс {type.Name} не имеет конструктор без параметров");

            var integratedCommand = constructor.Invoke(null) as CommandIntegrated;
            integratedCommand.Project = command.Project;

            await Task.Run(() => integratedCommand.Start());
        }
    }
}
