namespace Projects.Service
{
    public class Project
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        
        public string? ServerName { get; set; }

        public string? DatabaseName { get; set; }
    }
}