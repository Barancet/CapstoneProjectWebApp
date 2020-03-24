namespace CapstoneProject.Models
{
    public interface ICapstoneDatabaseSettings
    {
        string CapstoneCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}