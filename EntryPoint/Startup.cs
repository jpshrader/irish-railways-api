using irish_railways_api.Common.Access;
using irish_railways_api.Controllers.Trains.Models;
using irish_railways_api.Endpoints.StationDetails.Adapters;
using irish_railways_api.Endpoints.StationDetails.Data;
using irish_railways_api.Endpoints.StationDetails.Models;
using irish_railways_api.Endpoints.StationDetails.Services;
using irish_railways_api.Endpoints.Stations.Adapters;
using irish_railways_api.Endpoints.Stations.Data;
using irish_railways_api.Endpoints.Stations.Services;
using irish_railways_api.Endpoints.TrainMovements.Adapters;
using irish_railways_api.Endpoints.TrainMovements.Data;
using irish_railways_api.Endpoints.TrainMovements.Models;
using irish_railways_api.Endpoints.TrainMovements.Services;
using irish_railways_api.Endpoints.Trains.Adapters;
using irish_railways_api.Endpoints.Trains.Services;
using irish_railways_api.Models;
using irish_railways_api.Trains.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

		public static void ConfigureServices(IServiceCollection services) {
			services.AddControllers();
			services.AddCors(o => o.AddPolicy(CORS_POLICY, builder => {
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

			services.AddApiVersioning(config =>
			{
				config.DefaultApiVersion = new ApiVersion(1, 0);
				config.AssumeDefaultVersionWhenUnspecified = true;
				config.ReportApiVersions = true;
			});

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo {
					Version = "v1",
					Title = "Irish Railways Api",
					Description = "REST Api for pulling various pieces of information from the Irish Realtime Railway Api"
				});
			});

			services.AddSingleton<IStationDetailsService, StationDetailsService>()
				.AddSingleton<IStationDetailsRetriever, StationDetailsRetriever>()
				.AddSingleton<IStationDetailsAdapter, StationDetailsAdapter>()
				.AddSingleton<IApiAccess<StationDetail>, ApiAccess<StationDetail>>()

				.AddSingleton<IStationsService, StationsService>()
				.AddSingleton<IStationRetriever, StationRetriever>()
				.AddSingleton<IStationAdapter, StationAdapter>()
				.AddSingleton<IApiAccess<Station>, ApiAccess<Station>>()

				.AddSingleton<ITrainMovementService, TrainMovementService>()
				.AddSingleton<ITrainMovementRetriever, TrainMovementRetriever>()
				.AddSingleton<ITrainMovementAdapter, TrainMovementAdapter>()
				.AddSingleton<IApiAccess<TrainMovement>, ApiAccess<TrainMovement>>()

				.AddSingleton<ITrainsService, TrainsService>()
				.AddSingleton<ITrainsRetriever, TrainsRetriever>()
				.AddSingleton<ITrainAdapter, TrainAdapter>()
				.AddSingleton<IApiAccess<Train>, ApiAccess<Train>>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			var isDev = env.IsDevelopment();
			if (isDev)
				app.UseDeveloperExceptionPage();

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
