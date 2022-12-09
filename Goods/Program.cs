using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Repository.Implement;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Goods.Goods_BLL;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_BLL.Service.Implement;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DAL.UnitOfWork.Implement;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services sử dụng DataOnly và TimeOnly
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add Server Googole khi sử dụng FE
//builder.Services.AddRazorPages();
// Add chú thích cho biến khi chạy lên (Docs API)
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
    // Bảo mật thông tin trong Swagger
    setupAction.AddSecurityDefinition("GoodsBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this API"
    });
    // Xác thực trong Swagger
    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "GoodsBearerAuth"
            } }, new List<string>() }
    });
});
// Add services sử dụng DataOnly và TimeOnly
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = new OpenApiString("10:10:05")
    });
});

// Add database SQL Server (chuỗi kết nối)
builder.Services.AddDbContext<MyDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:Database"]));

// Add Service User Repository
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
// Add Service Items Repository
builder.Services.AddScoped<IItemsInfoRepository, ItemsInfoRepository>();
// Add Service Carts Repository
builder.Services.AddScoped<ICartsInfoRepository, CartsInfoRepository>();
// Add Service Reviews Repository
builder.Services.AddScoped<IReviewsInfoRepository, ReviewsInfoRepository>();
// Add Service Orders Repository
builder.Services.AddScoped<IOrdersInfoRepository, OrdersInfoRepository>();
// Add Service OrderDetails Repository
builder.Services.AddScoped<IOrderDetailsInfoRepository, OrderDetailsInfoRepository>();
// Add Service Unit Of Work
builder.Services.AddScoped<IGoodsUnitOfWork, GoodsUnitOfWork>();
// Add Service UserBLL
builder.Services.AddScoped<IUserBLL, UserBLL>();
// Add Service ItemsBLL
builder.Services.AddScoped<IItemsBLL, ItemsBLL>();
// Add Service ProductViewBLL
builder.Services.AddScoped<ICartsBLL, CartsBLL>();
// Add Service ReviewsBLL
builder.Services.AddScoped<IReviewsBLL, ReviewsBLL>();
// Add Service OrdersBLL
builder.Services.AddScoped<IOrdersBLL, OrdersBLL>();
// Add Service OrderDetailsBLL
builder.Services.AddScoped<IOrderDetailsBLL, OrderDetailsBLL>();
// Thêm sử dụng AutoMap
object value = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Access Token
builder.Services.AddAuthentication("Bearer").AddJwtBearer("AccessToken", options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForkey"]))
    };
});
// Add version
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});
// Add Firebase
// firebase auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("firebase" , opt =>
{
    opt.Authority = builder.Configuration["Jwt:Firebase:ValidIssuer"];
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Firebase:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:Firebase:ValidAudience"]
    };
});

// Add Server cho Google
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle("google", options =>
    {
        options.ClientId = builder.Configuration["Authentications:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentications:Google:ClientSecret"];
        options.SaveTokens = true;
    });
// Ủy quyền
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder().AddAuthenticationSchemes("AccessToken", "firebase", "google").
    RequireAuthenticatedUser().Build();

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
