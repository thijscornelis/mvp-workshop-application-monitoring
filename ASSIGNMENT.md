# Solution structure

Up until now, we've been able to use the Aspire Dashboard to collect our OpenTelemetry logging/metrics/traces. In a production environment, we would want a more production ready solution.
We've provided you with a working docker-compose file, which is setup the projects you already know without .NET Aspire. You should be able to run `docker-compose up` from inside of the `.deployement` server.

[Projects API](http://localhost:5001/swagger/index.html)
[Tasks API](http://localhost:6001/swagger/index.html)
[RabbitMQ Management](http://localhost:15672/)
[PgAdmin](http://localhost:32871/browser/)

# Step 01: Forward data to the correct service

We've added an `otel-collector` so that our Open Telemetry is captured. Alongside of that container, we've also added:
  - Loki for logs
  - Tempo for traces
  - Prometheus for metrics

Extend the collector's configuration so that logs, metrics and traces are sent to the correct container.

# Step 02: Combine the data in Grafana

Using the provided [Grafana instance](http://localhost:3000/) (admin:admin), setup the data sources for and combine the data from Loki, Tempo and Prometheus in one dashboard.

Goal:
- The logs, metrics and traces should be visible in Grafana
- The dashboard should be setup in a way that it is easy to see the correlation between the logs, metrics and traces
- The dashboard should visualize the performance of the system
- The dashboard should alert when we have more than 10 projects

# Read more
[A Beginner's Guide to the OpenTelemetry Collector](https://betterstack.com/community/guides/observability/opentelemetry-collector/)