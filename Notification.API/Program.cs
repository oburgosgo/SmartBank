using Azure.Identity;
using Notification.API.Interfaces;
using Notification.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<INotificationSender, NotificationSender>();
builder.Services.AddScoped<ISmsSender,SmsSender>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddHttpClient<ISendGridClient, SendGridClient>(client =>
{
    client.BaseAddress = new Uri("https://api.sendgrid.com/v3/");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddAzureKeyVault(

    new Uri(builder.Configuration["Azure:KeyVaultUrl"]),
    new DefaultAzureCredential()
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
