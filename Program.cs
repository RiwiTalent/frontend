// Espacios de nombres de Microsoft
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

// Espacios de nombres de terceros
using MudBlazor.Services;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;

// Espacios de nombres de la aplicación
using riwitalentfrontend;
using riwitalentfrontend.Services.Implementations;
using riwitalentfrontend.Services.Interfaces;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Agregar componentes raíz
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/riwitalent/") });

// Servicios personalizados
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ICoderService, CoderService>();
builder.Services.AddTransient<CoderService>();

// Configuración del HttpClient para servicios específicos
builder.Services.AddHttpClient<GroupService>(client =>
{
    client.BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/riwitalent/");
});

// Servicios de estado y almacenamiento
builder.Services.AddBlazoredSessionStorage();

// Servicios de interfaz de usuario - MudBlazor
builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();

// Servicios de seguridad y autenticación
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();

// SweetAlert2 para alertas
builder.Services.AddScoped<AlertService>();
builder.Services.AddSweetAlert2();

// Construir y ejecutar la aplicación
await builder.Build().RunAsync();
