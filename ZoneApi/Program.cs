using ZoneApi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
