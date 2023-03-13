using Projects.Service.Objects;

namespace Integration.Command.General
{
    public abstract class Command
    {
        public abstract Project Project { get; set; }

        public abstract void Start();
    }
}
