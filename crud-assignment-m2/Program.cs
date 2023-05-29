using System;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.schemas;
using crud_assignment_m2.services;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using crud_assignment_m2.models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using crud_assignment_m2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://dev-38914505.okta.com/oauth2/default";
    options.Audience = "api://default";
    options.RequireHttpsMetadata = false;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD_API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
            });
});
builder.Services.AddDbContext<PostDBContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-JOJR9QA\\SQLEXPRESS;Initial Catalog=assignment-m2;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IComment, CommentService>();
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddSingleton<IOktaToken, OktaTokenService>();
builder.Services.AddAutoMapper(typeof(PostModel).Assembly);
builder.Services.AddAutoMapper(typeof(CommentModel).Assembly);
//builder.Services.Configure<OktaSettings>(builder.Configuration.GetSection("Okta"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

