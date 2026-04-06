var builder = WebApplicationBuilder.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();
app.MapHub<CodeHub>("/hub/code");

app.Run();

public class CodeHub : Hub
{
    public async Task ExecuteCode(string code, string language)
    {
        await Clients.Group("session").SendAsync("ExecutionStarted");
        // Execution logic will go here
    }
}
