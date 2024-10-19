using MassTransit;
using Microsoft.Extensions.Logging;
using Projects.Management.Events;
using Tasks.Management.Design;

namespace Tasks.Management.RabbitMq;

public class DeleteTasksRelatedToProjectOnProjectDeleted(ILogger<DeleteTasksRelatedToProjectOnProjectDeleted> logger, ITaskManagementFacade facade) : IConsumer<ProjectDeleted>
{
    public async Task Consume(ConsumeContext<ProjectDeleted> context)
    {
        logger.LogInformation("Processing {EventName} {@Value}", nameof(ProjectDeleted), context.Message);
        await facade.DeleteTasksForProjectAsync(new(context.Message.ProjectId), context.CancellationToken);
        logger.LogInformation("Successfully processed {EventName}", nameof(ProjectDeleted));
    }
}