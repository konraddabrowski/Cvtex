namespace Cvtex.Infrastructure.EF
{
    public class SqlSettings
    {
        public string DatabaseName { get; set; }
        public string AssemblyName { get; set; }
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }
    }
}