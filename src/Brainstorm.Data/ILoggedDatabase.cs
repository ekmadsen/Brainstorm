using System.Data;


namespace Brainstorm.Data;


public interface ILoggedDatabase
{
    Task<IDbConnection> OpenConnectionAsync(Guid correlationId);
}

