# Solution structure

The solution is setup to develop and maintain a distributed system using [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview).
To startup the system, make sure to have `ProjectManagement.AppHost` as the startup project.

The solution folders `01. Projects` and `02. Tasks` contain the two services that together are the distributed system.

Each service uses a `hexagonal architecture`. The main goal is that our core project remains technology agnostic, contains the business logic 
and defines functionality that will be provided by our ports and adapters. 

# Step 01: Add OpenTelemetry for Logs to the solution

In this step, we will start using OpenTelemetry to expose logs.

Goal:
- Make sure that the log messages are published using OpenTelemetry.
- The log messages should be visible in the .NET Aspire dashboard.

# Step 02: Add OpenTelemetry for Metrics to the solution

In this step, we will start using OpenTelemetry to expose metrics. 
Make sure that, in development, you can see all the metrics.

Goal:
- Make sure that metrics are published using OpenTelemetry.
- The metrics should be visible in the .NET Aspire dashboard.
- Add .NET Runtime metrics
- Add ASP.NET Core metrics

# Step 03: Add custom Metrics to the solution

In this step, we will will be adding our own, custom, metrics.
Make sure that the code you write is easily (re)usable.

Goal:
- Add a metric that shows the number of active Units of Work.
- Add a metric that shows the number of Units of Work that have been completed.
- Add a metric that shows the number of projects that have exist.