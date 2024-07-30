using JetBrains.Annotations;

namespace MyCompany.ECommerce.Search.Products;

[UsedImplicitly]
internal class ProductElasticRepository(SearchDb db) : ProductRepository
{
    private readonly SearchDb _db = db;
}