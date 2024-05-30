using ZoneClient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IConfigDataService, ConfigDataService>();
builder.Services.AddHttpClient<IZoneService, ZoneService>(
    async (client)=> {
        client.BaseAddress = new Uri("https://localhost:7124/");
    });
builder.Services.AddHttpClient<IDnsService, DnsService>(
    async (client) => {
        client.BaseAddress = new Uri("https://localhost:7124/");
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Zone/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Zone}/{action=DNSList}/{id?}");

app.Run();
