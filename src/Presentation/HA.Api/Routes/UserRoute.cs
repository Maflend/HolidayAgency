namespace HA.Api.Routes;

public static class UserRoute
{
    private const string _base = "api/user/";

    public static class OrderRoute
    {
        public const string Base = _base + "orders/";
        public const string GetById = "{id}";
    }

    public static class CategoryRoute
    {
        public const string Base = _base + "categories/";
        public const string GetOrders = "{id}/orders";
    }

    public static class ClientRoute
    {
        public const string Base = _base + "clients/";
        public const string GetById = "{id}";
    }
}
