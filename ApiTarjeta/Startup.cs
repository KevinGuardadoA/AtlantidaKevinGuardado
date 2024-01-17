using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiTarjeta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            /////////
            //services.AddAuthorization(options =>
            //options.DefaultPolicy =
            //new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            //    //estos valores los obtenemos de nuestro appsettings
            //    var issuer = Configuration["AuthenticationSettings:Issuer"];
            //    var audience = Configuration["AuthenticationSettings:Audience"];
            //    var signinKey = Configuration["AuthenticationSettings:SigningKey"];
            ////autenticacion
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.Audience = audience;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = issuer,
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signinKey))
            //    };
            //});
                /////////

                    services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opciones=> opciones.TokenValidationParameters = new TokenValidationParameters
            //    {
            //       ValidateIssuer=false,
            //       ValidateAudience=false,
            //       ValidateLifetime=true,
            //       ValidateIssuerSigningKey=true,
            //       IssuerSigningKey= new SymmetricSecurityKey(
            //           Encoding.UTF8.GetBytes(configuration["llavejwt"])),
            //       ClockSkew
            //    });

            //services.AddIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores< ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            //services.AddAuthorization(JwtBearerDefaults.AuthenticationScheme).AddJwtBerer();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
           
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            //Configurando la aplicación para JWT
            app.UseAuthentication();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
