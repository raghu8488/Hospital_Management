using HospitalManagement.Web;
using HospitalManagement.Web.Contracts;
using HospitalManagement.Web.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IPatient, HttpPatientRepository>();
builder.Services.AddScoped<IProgressNotes, HttpProgressNotesRepository>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058/api/") });

await builder.Build().RunAsync();
