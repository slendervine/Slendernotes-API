using MongoDB.Driver;

namespace Slendernotes.Infrastructure.Persistence.Settings
{
    public class MongoSettings
    {
        public string? ConnectionString { get; set; } //User e senha esta aqui
        public string? Database { get; set; }

        public MongoSettings()
        {
            ConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTIONSTRING");
            Database = Environment.GetEnvironmentVariable("MONGODB_DATABASE");

            if (ConnectionString == null || Database == null) 
            {
                throw new MongoException("Env variables are null");
            }

        }
    }
}
