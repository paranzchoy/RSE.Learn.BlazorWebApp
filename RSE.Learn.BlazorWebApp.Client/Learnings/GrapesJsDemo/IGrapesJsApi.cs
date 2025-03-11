using Refit;
using System.Threading.Tasks;

namespace RSE.Learn.BlazorWebApp.Client.Learnings.GrapesJsDemo;

public interface IGrapesJsApi
{
    [Get("/api/grapesjs/template")]
    Task<GrapesJsTemplate> GetTemplateAsync();
}

public class GrapesJsTemplate
{
    public string Html { get; set; } = string.Empty;
    public string Css { get; set; } = string.Empty;
    public string Components { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
}