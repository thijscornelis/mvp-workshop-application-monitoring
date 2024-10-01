# Solution structure

The solution is setup to develop and maintain a distributed system using [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview).
To startup the system, make sure to have `ProjectManagement.AppHost` as the startup project.

The solution folders `01. Projects` and `02. Tasks` contain the two services that together are the distributed system.

Each service uses a `hexagonal architecture`. The main goal is that our core project remains technology agnostic, contains the business logic 
and defines functionality that will be provided by our ports and adapters. 

# Step 01: Logging using .NET built-in logging framework

In this step, we will implement logging using the .NET built-in logging framework. 
We will use the `Microsoft.Extensions.Logging` package to log messages in our services.

Goal:
- Make sure that the log messages are written to the console.
- Make sure that, by default, log messages are visible as of the Information level.
- Make sure that, by default, log messages in Development are visible as of the Trace level.
- Make sure that the log messages of EntityFramework are visible if their log level is Warning or higher. You can also mute other logs if they are too annoying.
- Show a log for each request received by the projects and tasks API, showing the request duration.
- Write a log when creating a project, containing the request body.

> Do not worry about the fact that structured logs and traces are not visible in the Aspire Dashboard.

# Step 02: Replace the built-in logging framework with Serilog

Replace the built-in logging framework with Serilog. 

Goal:
- Logs are visible in the console, format the logs as text. 
- Logs are visible in a file, format the logs as JSON.
- Log, using Warning level, when the request duration exceeds 500ms
- Create a file for each hour, and keep the logs for 7 days.

# Step 03: Add a sensitive field

Add a sensitive field to the `Project` entity. Make sure that the sensitive field can be provided when creating the entity using the API.

> At this point in time, you should be seeing your sensitive data printed in your logs

Goal:
- Make sure the sensitive field is not logged in the logs.
- Make sure to use structured logging.
- Add a correlation id to the logs.