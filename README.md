<a href="https://www.nuget.org/packages/qckdev.Extensions.Configuration.Abstractions"><img src="https://img.shields.io/nuget/v/qckdev.Extensions.Configuration.Abstractions.svg" alt="NuGet Version"/></a>
<a href="https://sonarcloud.io/dashboard?id=qckdev.Extensions.Configuration.Abstractions"><img src="https://sonarcloud.io/api/project_badges/measure?project=qckdev.Extensions.Configuration.Abstractions&metric=alert_status" alt="Quality Gate"/></a>
<a href="https://sonarcloud.io/dashboard?id=qckdev.Extensions.Configuration.Abstractions"><img src="https://sonarcloud.io/api/project_badges/measure?project=qckdev.Extensions.Configuration.Abstractions&metric=coverage" alt="Code Coverage"/></a>
<a><img src="https://hfrances.visualstudio.com/qckdev/_apis/build/status/qckdev.Extensions.Configuration.Abstractions?branchName=master" alt="Azure Pipelines Status"/></a>


# qckdev.Extensions.Configuration.Abstractions

Provides some utilities for Microsoft.Extensions.Configuration.Abstractions.

``` cs

    using Microsoft.Extensions.Configuration;
	using qckdev.Extensions.Configuration.Abstractions;

    class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.ApplyEnvironmentVariables();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           (...)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            (...)
        }

    }
    
```
