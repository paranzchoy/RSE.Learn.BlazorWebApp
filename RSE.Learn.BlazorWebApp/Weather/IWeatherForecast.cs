namespace RSE.Learn.BlazorWebApp.Weather;

public interface IWeatherForecast
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}
