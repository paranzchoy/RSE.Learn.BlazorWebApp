var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithLifetime(ContainerLifetime.Persistent);

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume();

builder.AddProject<Projects.RSE_Learn_BlazorWebApp>("main-app")
    .WithExternalHttpEndpoints()
    .WithReplicas(1)
    //.WithReference(db)
    //.WaitFor(db)
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
