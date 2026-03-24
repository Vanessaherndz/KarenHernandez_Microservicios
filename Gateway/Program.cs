var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "products",
                ClusterId = "productCluster",
                Match = new() { Path = "/api/products/{**catch-all}" }
            },
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "customers",
                ClusterId = "customerCluster",
                Match = new() { Path = "/api/customers/{**catch-all}" }
            },
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "orders",
                ClusterId = "orderCluster",
                Match = new() { Path = "/api/orders/{**catch-all}" }
            }
        },
        new[]
        {
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "productCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new() { Address = "http://productservice:8080/" } }
                }
            },
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "customerCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new() { Address = "http://customerservice:8080/" } }
                }
            },
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "orderCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new() { Address = "http://orderservice:8080/" } }
                }
            }
        });

var app = builder.Build();

app.MapReverseProxy();

app.Run();
