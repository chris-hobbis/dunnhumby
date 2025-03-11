using Dunnhumby.WebAPI.Data;

namespace Dunnhumby.WebAPI.Services;

public class BaseService
{
    protected ProductsDbContext Db;

    public BaseService()
    {
    }

    public BaseService(ProductsDbContext db)
    {
        Db = db;
    }
}