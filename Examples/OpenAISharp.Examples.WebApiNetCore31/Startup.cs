using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenAISharp.Client;
using OpenAISharp.Completion;
using OpenAISharp.Edit;
using OpenAISharp.Embedding;
using OpenAISharp.File;
using OpenAISharp.FineTune;
using OpenAISharp.Image;
using OpenAISharp.Model;
using OpenAISharp.Moderation;
using System;

namespace OpenAISharp.Examples.WebApiNetCore31
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OpenAISharp Test API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Ryan Tunis",
                        Email = "ryan@codemonarchs.com",
                    },
                });
            });

            // Add OpenAISharp Dependencies and Configuration
            var apiKey = Configuration["OpenAI:ApiKey"];
            var organizationId = Configuration["OpenAI:OrganizationId"];

            services.AddHttpClient<IOpenAIClient, OpenAIClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.openai.com");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                if (!string.IsNullOrWhiteSpace(organizationId))
                    client.DefaultRequestHeaders.Add("OpenAI-Organization", organizationId);
            });

            services.AddTransient<ICompletionService, CompletionService>();
            services.AddTransient<IEditService, EditService>();
            services.AddTransient<IEmbeddingService, EmbeddingService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFineTuneService, FineTuneService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IModerationService, ModerationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenAISharp Test API");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
