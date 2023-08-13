namespace HA.Api.Dtos;

public class GetCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class CreateCategoryDto
{
    public string Name { get; set; }
}
