using HA.Api.Endpoints.Categories.CreateCategory;
using HA.Api.Endpoints.Categories.GetCategories;
using HA.Api.Endpoints.Categories.GetCategoryById;

namespace HA.Api.Endpoints.Categories;

/// <summary>
/// Конечные точки категорий.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Конечные точки категорий.
    /// </summary>
    public static WebApplication MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(EndpointConsts.BaseUrl + "categories").WithTags("Конечные точки категорий.");

        group.MapGetCategoriesEndpoint();
        group.MapCreateCategoryEndpoint();
        group.MapGetCategoryByIdEndpoint();
        return app;
    }
}
