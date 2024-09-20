using Projects.Management.Contracts;
using Projects.Management.Design;
using Projects.Management.Domain;

namespace Projects.Management;

internal class ProjectManagementFacade(ICanStoreProject store, ICanFindProject finder, ICanPublishProjectDeleted publisher) : IProjectManagementFacade
{
    public async Task<Project> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Name);
        await store.AddAsync(project, cancellationToken).ConfigureAwait(false);
        return project;
    }

    public Task<Project?> FindProjectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return finder.FindByIdAsync(id, cancellationToken);
    }

    public async Task DeleteProjectAsync(Guid id, CancellationToken cancellationToken)
    {
        var project = await finder.FindByIdAsync(id, cancellationToken).ConfigureAwait(false);
        if(project is null)
        {
            return;
        }
        await store.DeleteAsync(project, cancellationToken).ConfigureAwait(false);
        await publisher.PublishAsync(project.Id, cancellationToken).ConfigureAwait(false);
    }
}