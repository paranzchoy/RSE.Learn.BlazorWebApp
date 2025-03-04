using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using MudBlazor.Services;
using RSE.Learn.BlazorWebApp.Client.Weather;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddFluentUIComponents();
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddHttpClient<IWeatherForecaster, ClientWeatherForecaster>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

//builder.Services.AddHttpClient("WeatherAPI", client => client.BaseAddress = new Uri("https://localhost:7055/"))
//    .AddHttpMessageHandler(sp =>
//    {
//        var handler = sp.GetRequiredService<AuthorizationMessageHandler>()
//            .ConfigureHandler(authorizedUrls: ["https://localhost:7055"]);

//        return handler;
//    });

//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WeatherAPI"));

//builder.Services.AddOidcAuthentication(options =>
//{
//    // Set Keycloak configuration here
//    options.ProviderOptions.Authority = "https://localhost:8080/realms/DonaideAPIRealm";
//    options.ProviderOptions.ClientId = "donaide-web-client";
//    options.ProviderOptions.ResponseType = "code";
//    options.ProviderOptions.DefaultScopes.Add("donaide_api_scope");

//    // Optional: If you have a redirect URL or specific configurations, you can specify those here
//    options.ProviderOptions.RedirectUri = builder.HostEnvironment.BaseAddress;
//    options.ProviderOptions.PostLogoutRedirectUri = builder.HostEnvironment.BaseAddress;
//});

await builder.Build().RunAsync();
