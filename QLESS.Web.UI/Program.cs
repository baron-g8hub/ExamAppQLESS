using Common.Contracts;
using Common.DataAccess;
using Common.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// NOTE: Should add here the environment variable to be used in CI/CD
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.Dev.json", optional: true);
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddTransient<ITransportCardRepository, TransportCardRepos>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllersWithViews();


// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    //  options.Password.RequiredUniqueChars = 0;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "U0123456789";
});



#region Authorization
AddAuthorizationPolicies();
#endregion

AddScoped();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Q-LESS Transport .NetCore6 Web and API test app by: Ron",
        Description = "Web app, and Api with Swagger UI.",
        //TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("https://example.com/contact")
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "QLESSTransportAPI");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
        options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));
    });
}

void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<ITransportCardRepository, TransportCardRepos>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
