using JetBrains.Annotations;

namespace MyCompany.ECommerce.Search.Products;

[UsedImplicitly]
internal class ProductElasticRepository : ProductRepository
{
    private readonly SearchDb _db;
    
    public ProductElasticRepository(SearchDb db) => _db = db;
}