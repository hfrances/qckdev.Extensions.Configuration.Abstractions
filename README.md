[![NuGet Version](https://img.shields.io/nuget/v/qckdev.Extensions.Configuration.Abstractions.svg)](https://www.nuget.org/packages/qckdev.Extensions.Configuration.Abstractions)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=qckdev.Extensions.Configuration.Abstractions&metric=alert_status)](https://sonarcloud.io/dashboard?id=qckdev.Extensions.Configuration.Abstractions)
[![Code Coverage](https://sonarcloud.io/api/project_badges/measure?project=qckdev.Extensions.Configuration.Abstractions&metric=coverage)](https://sonarcloud.io/dashboard?id=qckdev.Extensions.Configuration.Abstractions)
![Azure Pipelines Status](https://hfrances.visualstudio.com/qckdev/_apis/build/status/qckdev.Extensions.Configuration.Abstractions?branchName=master)


# qckdev.Extensions.Configuration.Abstractions

Provides some utilities for Microsoft.Extensions.Configuration.Abstractions.

``` cs

    using Microsoft.Extensions.Configuration;
    using qckdev.Extensions.Configuration;

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

## 🤝 Contributing
Issues and pull requests are welcome! See the contribution guidelines (coming soon).

## 📜 License
This project is licensed under the terms of the [MIT License](LICENSE).