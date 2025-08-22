using Atea.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPaymentGateway, PayPalGateway>();

builder.Services.AddScoped<IPaymentGateway, StripeGateway>();

builder.Services.AddSingleton<OrderService>();

builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
