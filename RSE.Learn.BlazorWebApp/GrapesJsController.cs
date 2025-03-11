using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;

namespace RSE.Learn.BlazorWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrapesJsController : ControllerBase
{
    [HttpGet("template")]
    public IActionResult GetTemplate()
    {
        // Hard-coded template data as requested
        var template = new
        {
            Html = "<div class=\"panel\"><h1>Hello GrapesJS</h1><div>This is sample content loaded from the server</div></div>",
            Css = ".panel { padding: 10px; border-radius: 5px; border: 1px solid #ddd; margin-bottom: 10px; } h1 { color: #4285f4; }",
            Components = JsonSerializer.Serialize(new
            {
                type = "wrapper",
                components = new object[]
                {
                    new {
                        type = "heading",
                        content = "Hello GrapesJS",
                        tagName = "h1"
                    },
                    new {
                        type = "text",
                        content = "This is sample content loaded from the server"
                    }
                }
            }),
            Style = JsonSerializer.Serialize(new object[]
            {
                new {
                    selectors = new string[] { ".panel" },
                    style = new Dictionary<string, string> {
                        { "padding", "10px" },
                        { "border-radius", "5px" },
                        { "border", "1px solid #ddd" },
                        { "margin-bottom", "10px" }
                    }
                },
                new {
                    selectors = new string[] { "h1" },
                    style = new Dictionary<string, string> {
                        { "color", "#4285f4" }
                    }
                }
            })
        };

        return Ok(template);
    }
}