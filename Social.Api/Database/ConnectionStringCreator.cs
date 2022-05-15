namespace Social.Api.Database;

public static class ConnectionStringCreator
{
    public static string BuildConnectionString(string server, string db, string user, string password)
    {
        return $"Server={server};Database={db};User Id={user};Password={password};Integrated Security=false;MultipleActiveResultSets=false;";
    }
}