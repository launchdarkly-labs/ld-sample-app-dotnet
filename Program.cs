using System.Diagnostics;
using System.Text;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;
using System.IO;
using DotEnv.Core;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

new EnvLoader().Load(); // Loads the .env file

var reader = new EnvReader();
string clientKey = reader["LD_CLIENT_KEY"];
string filePath = "wwwroot/js/keys.js";
string content = $"const clientKey = \"{clientKey}\";";

File.WriteAllText(filePath, content);

// LdClient client = LDClient.Client;

// string flag = "test-flag";
// var context = Context.Builder("018d6ae1-d3c8-704b-8b12-6a8ce650ef5e")
// .Kind("device")
// .Name("Linux")
// .Build();

// client.FlagTracker.FlagChanged += client.FlagTracker.FlagValueChangeHandler(
//     flag,
//     context,
//     (s, e) =>
//     {
//         Console.WriteLine(
//             "Flag \"{0}\" for context \"{1}\" has changed from {2} to {3}",
//             flag,
//             context.Key,
//             e.OldValue,
//             e.NewValue
//         );
//     }
// );

app.Run();
