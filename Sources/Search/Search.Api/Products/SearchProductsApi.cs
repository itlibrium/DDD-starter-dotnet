namespace MyCompany.ECommerce.Search.Products;

public static class SearchProductsApi
{
    public static void MapSearchProductsApi(this WebApplication app)
    {
        app.MapGet("search/products", GetProducts);
    }

    private static Task<string> GetProducts(ProductRepository repository) => Task.FromResult("test");
}