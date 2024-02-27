namespace TinyGarage.Web.ApiRoutes
{ 
    public static class User
    {
        public static readonly string GetCurrentUserInfo = "/api/user/current";
        public static readonly string Logout = "/api/user/logout";
        public static readonly string Token = "/token";
    }

    public static class Car
    {
        public static readonly string Create = "/api/car/create";
        public static readonly string Delete = "/api/car/delete/{0}";
        public static readonly string GetAll = "/api/car/all";
        public static readonly string GetById = "/api/car/{0}";
        public static readonly string Edit = "/api/car/update";
    }

    public static class Model
    {
        public static readonly string Create = "/api/model/create";
        public static readonly string Delete = "/api/model/delete/{0}";
        public static readonly string GetAll = "/api/model/all";
        public static readonly string GetById = "/api/model/{0}";
        public static readonly string Edit = "/api/model/update";
    }

    public static class Manufacturer
    {
        public static readonly string Create = "/api/manufacturer/create";
        public static readonly string Delete = "/api/manufacturer/delete/{0}";
        public static readonly string GetAll = "/api/manufacturer/all";
        public static readonly string GetById = "/api/manufacturer/{0}";
        public static readonly string Edit = "/api/manufacturer/update";
    }

    public static class Collection
    {
        public static readonly string Create = "/api/collection/create";
        public static readonly string Delete = "/api/collection/delete/{0}";
        public static readonly string GetAll = "/api/collection/all";
        public static readonly string GetById = "/api/collection/{0}";
        public static readonly string Edit = "/api/collection/update";
    }

    public static class Garage
    {
        public static readonly string Create = "/api/garage/create";
        public static readonly string Delete = "/api/garage/delete/{0}";
        public static readonly string GetAll = "/api/garage/all";
        public static readonly string GetById = "/api/garage/{0}";
        public static readonly string Edit = "/api/garage/update";
    }
}
