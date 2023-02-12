using Projects.Service.Commands.Interfaces;

namespace Projects.Service
{
    public class Project
    {
        public Project()
        {
            Commands = new List<IProjectCommand>();
        }

        public string? Name { get; set; }
        
        public string? ServerName { get; set; }

        public string? DatabaseName { get; set; }

        public string? LocalPath { get; set; }

        public List<IProjectCommand> Commands { get; init; }
    }
}