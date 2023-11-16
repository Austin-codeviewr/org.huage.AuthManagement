using org.huage.AuthManagement.Api.Consul;
using org.huage.AuthManagement.Api.Extension;
using org.huage.AuthManagement.BizManager.MapProfile;
using org.huage.AuthManagement.BizManager.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureMysql(builder.Configuration);
builder.Services.ConfigureRedis(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AuthMapProfile).Assembly);
builder.Services.AddTransient<IRedisManager, RedisManager>();
builder.Services.AddScoped<ConsulBalancer>();
//装配consul配置信息
builder.Services.Configure<ConsulOption>(builder.Configuration.GetSection("ConsulOption"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//微服务的注册
app.UseConsulRegistry(app.Lifetime);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/api/health", () =>
{
    global::System.Console.WriteLine("Ok");
    return new
    {
        Message = "Ok"
    };
});

app.UseCors("AnyPolicy");
app.MapControllers();

app.Run();