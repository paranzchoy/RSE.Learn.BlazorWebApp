var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
    .WithLifetime(ContainerLifetime.Persistent);

var sqlPassword = builder.AddParameter("sql-password", secret: true);

var db = builder.ExecutionContext.IsPublishMode
    ? builder.AddConnectionString("donaidev3-sqldb")
    : builder.AddSqlServer("sql", password: sqlPassword)
        .WithDataVolume()
        .WithLifetime(ContainerLifetime.Persistent)
        .AddDatabase("donaidev3-sqldb");

var keycloak = builder.AddKeycloak("keycloak", 8080)
                      .WithExternalHttpEndpoints()
                      .WithDataVolume()
                      .WithReference(db)                      
                      .WithLifetime(ContainerLifetime.Persistent);

//.WithRealmImport("../realms");

var apiService = builder.AddProject<Projects.DonaideV3_ApiService>("apiservice")
                        .WithExternalHttpEndpoints()
                        .WithReplicas(1)
                        .WithReference(db)
                        .WaitFor(db)
                        .WithReference(keycloak)
                        .WaitFor(keycloak);

builder.AddProject<Projects.DonaideV3_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
