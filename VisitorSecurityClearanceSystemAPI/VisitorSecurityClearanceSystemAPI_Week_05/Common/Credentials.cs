namespace VisitorSecurityClearanceSystemAPI_Week_05.Common
{
        public class Credentials
        {
            public static readonly string databaseName = Environment.GetEnvironmentVariable("databaseName");
            public static readonly string containerName = Environment.GetEnvironmentVariable("containerName");
            public static readonly string CosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
            public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
            internal static readonly string VisitorDocumentType;
            public static string UserDocumentType = "user";
        }
    }

