# Solution structure

The solution is setup to develop and maintain a distributed system using [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview).
To startup the system, make sure to have `ProjectManagement.AppHost` as the startup project.

The solution folders `01. Projects` and `02. Tasks` contain the two services that together are the distributed system.

Each service uses a `hexagonal architecture`. The main goal is that our core project remains technology agnostic, contains the business logic 
and defines functionality that will be provided by our ports and adapters. 

# Step 01: Setup OpenTelemetry like you would in an production environment

Up until now, we've been able to use the Aspire Dashboard to collect our OpenTelemetry logging/metrics/traces. In a production environment, we would want a more production ready solution.
Therefore, we will start by setting up an OpenTelemetry Collector to collect the logging/metrics/traces and dump them in the console of the container.
All of our services should run inside docker containers.

Goal:
- Setup a docker compose project file with our Tasks API, Projects API and OpenTelemetry Collector.
- Setup the OpenTelemetry Collector to collect the logging/metrics/traces and dump them in the console of the container.

# Step 02: Add Jaeger, Loki, Prometheus

Now that our OpenTelemetry Collector is setup, we want to add Jaeger, Loki and Prometheus to our setup. This will allow us to visualize our traces, logs and metrics.

Goal:
- The logs should be visible in Loki
- The metrics should be visible in Prometheus
- The traces should be visible in Jaeger

# Step 03: Combine the data in Grafana

Add Grafana to the setup and combine the data from Jaeger, Loki and Prometheus in one dashboard.

Goal:
- The logs, metrics and traces should be visible in Grafana
- The dashboard should be setup in a way that it is easy to see the correlation between the logs, metrics and traces
- The dashboard should visualize the performance of the system
- The dashboard should alert when we have more than 10 projects