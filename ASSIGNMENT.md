# Solution structure

The solution is setup to develop and maintain a distributed system using [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview).
To startup the system, make sure to have `ProjectManagement.AppHost` as the startup project.

The solution folders `01. Projects` and `02. Tasks` contain the two services that together are the distributed system.

Each service uses a `hexagonal architecture`. The main goal is that our core project remains technology agnostic, contains the business logic 
and defines functionality that will be provided by our ports and adapters. 

# Step 01: Add OpenTelemetry for Traces to the solution

In this step, we will start using OpenTelemetry to expose traces.

Goal:
- Make sure that the traces are published using OpenTelemetry.
- The traces should be visible in the .NET Aspire dashboard, logs should be linked.

# Step 02: Update the solution to include distributed tracing

The solution is now setup to use OpenTelemetry for traces. In this step, we will add distributed tracing to the solution.
Our Projects API will publish a ProjectDeleted event when a project is deleted. The Tasks API will listen to this event and remove all tasks that are created for the project.

Goal:
- The trace should be visible in the .NET Aspire dashboard, logs should be linked.
- The trace should show the ProjectDeleted event as a span
- The trace should show the Database interaction as a span

# Step 03: Add custom spans

We want to be able to track the individual processing time for a task deletion. To do this, we will add a custom span for each task that is deleted.

Goal:
- A Custom Span is visible for each Task that is deleted. The Span should contain the Id's of the Project and Task that are deleted.