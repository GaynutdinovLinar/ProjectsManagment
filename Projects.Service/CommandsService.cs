using Projects.Service.Attributes;
using System.Reflection;

namespace Projects.Service
{
    public class CommandsService
    {
        public CommandsService()
        {
            AllCommands = GetAllCommands().ToList();
        }

        public List<Type> AllCommands { get; init; }

        public T? CreateCommand<T>()
            where T : class, new()
        {
            var type = AllCommands.Find(x => x == typeof(T));

            if (type is null)
                return null;

            return new T();
        }

        private IEnumerable<Type> GetAllCommands()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (Attribute.IsDefined(type, typeof(ProjectCommandAttribute)))
                    yield return type;
            }
        }
    }
}
