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
            //Html = "<div class=\"panel\"><h1>Hello GrapesJS</h1><div>This is sample content loaded from the server</div></div>",
            Html = @"<div style=""position: absolute; left: 0px; width: 100%; height: 750px; display: flex; flex-wrap: wrap;"">
                        <img data-editable=""true"" src=""https://images.unsplash.com/photo-1442504028989-ab58b5f29a4a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D""
                                style=""justify-content:center; width: 100%; height: 750px; object-fit: cover; position: relative;""
                                class=""rounded-bottom"" />
                        <div style=""position: absolute; top: 0; left: 0; width: 100%; height: 750px; background: rgba(0, 0, 0, 0.5);"">
                            <div style=""position: absolute; top: 0; width: 100%; height: 750px;"">
                                <div class=""container-fluid d-flex flex-column justify-content-center align-items-center h-100"">
                                    <h1 data-editable=""true"" style=""color:white; max-width: 900px; text-align: center;"">
                                        Redefine Your Fundraising: Raise More with the Latest in Auction Software!
                                    </h1>
                                    <div class=""text-center justify-content-center align-items-center"">
                                        <p data-editable=""true"" style=""color:white; font-size:medium; max-width: 1000px;"">Experience the game-changing power of our all-in-one auction platform, coupled with the passionate support of your own fundraising consultant. We're here to help you exceed your fundraising goals with confidence.</p>
                                        <button data-editable=""true"" class=""mt-3 border p-2 pl-4 pr-4"" style=""border-radius:30px; color:white; background-color: #630000;"">Book Demo Now</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class=""align-items-center justify-content-center"">
                        <div style=""position: absolute; left: 0px; width: 100%; height: 600px; display: flex; flex-wrap: wrap;"">

                            <img data-editable=""true"" src=""https://images.unsplash.com/photo-1516321497487-e288fb19713f?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D""
                                 style=""justify-content:center; width: 100%; height: 600px; object-fit: cover; position: relative;""
                                 class=""rounded-bottom"" />

                            <div style=""position: absolute; top: 0; left: 0; width: 100%; height: 600px; background: rgba(99, 0, 0, 0.5);"">
                                <div style=""position: absolute; top: 0; width: 100%; height: 600px;"">

                                    <div class=""container-fluid d-flex flex-column align-items-center justify-content-center h-100"">
                                            <h1 data-editable=""true"" style=""color:white; max-width: 800px; text-align: center;"">
                                                Your Donors are Online.
                                                Your Fundraising Should Be, Too!
                                            </h1>
                                            <div class=""text-center justify-content-center align-items-center"">
                                                <!-- BODY TEXT -->
                                                <p data-editable=""true"" style=""color:white; font-size:medium; max-width: 1000px;"">
                                                    Your donors are online, scrolling on their phones. It's time to meet them where they are, with a fundraising approach that blends cutting-edge technology with a human touch.
                                                    When you embrace digital technology, you make it easy for your donors and supporters to engage and donate anytime, anywhere. Mobile bidding and real-time updates keep them excited and involved, driving higher participation and donations.
                                                    Go digital, boost your fundraising, and stay relevant in the mobile era with WEDO Charity Auctions!
                                                </p>
                                                <!-- ACTION BUTTON -->
                                                <button data-editable=""true"" class=""mt-3 border p-2 pl-4 pr-4"" style=""border-radius:30px; color:white; background-color: #630000;"">
                                                    Purchase Membership
                                                </button>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
",
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