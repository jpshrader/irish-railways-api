using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace irish_railways_api.EntryPoint {
	public class Startup {
		private const string CORS_POLICY = "CorsPolicy";

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public static void ConfigureServices(IServiceCollection services) {
			services.AddControllers();

			services.AddCors(o => o.AddPolicy(CORS_POLICY, builder => {
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo {
					Version = "v1",
					Title = "Irish Railways Api",
					Description = "REST Api for pulling various pieces of information from the Irish Realtime Railway Api"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			var isDev = env.IsDevelopment();
			if (isDev) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors(CORS_POLICY);
			app.UseAuthorization();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
			app.UseStaticFiles();

			var swaggerUrlPrefix = isDev ? string.Empty : "/railways-api";
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.RoutePrefix = "swagger";
				c.SwaggerEndpoint($"{swaggerUrlPrefix}/swagger/v1/swagger.json", "Irish Railways Api");
			});

			var cacheConfig = Configuration.GetSection("Caching");
			ApiRequestStoreSession.IsEnabled = cacheConfig.GetValue<bool>(nameof(ApiRequestStoreSession.IsEnabled));
			ApiRequestStoreSession.RetentionPolicy = cacheConfig.GetValue<int>(nameof(ApiRequestStoreSession.RetentionPolicy));
		}
	}
}
