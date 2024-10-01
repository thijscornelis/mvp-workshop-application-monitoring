using Projects.Management.Contracts;

namespace Projects.Management.RestApi.Contracts;

public record CreateProjectRequestDto(string Name, string Owner)
{
    public static implicit operator CreateProjectRequest(CreateProjectRequestDto dto)
    {
        return new CreateProjectRequest(dto.Name, dto.Owner);
    }
}