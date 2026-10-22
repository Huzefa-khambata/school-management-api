using HSMS.API.Database;
using HSMS.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HSMS.API.Database;
using HSMS.API.Repository;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing from configuration.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

ConnectionHelper.ConnectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? string.Empty;

builder.Services.AddScoped<IDatabaseManager, DatabaseManager>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<TeacherRepository>();
builder.Services.AddScoped<ClassSectionRepository>();
builder.Services.AddScoped<SubjectRepository>();
builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<ExaminationRepository>();
builder.Services.AddScoped<FeeRepository>();
builder.Services.AddScoped<TimetableRepository>();
builder.Services.AddScoped<NoticeRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.Run();