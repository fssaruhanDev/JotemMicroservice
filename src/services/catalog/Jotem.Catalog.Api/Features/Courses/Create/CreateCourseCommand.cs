﻿using Jotem.Shared.Interfaces;

namespace Jotem.Catalog.Api.Features.Courses.Create
{
    public record CreateCourseCommand(
        string Name,
        string Description,
        decimal Price,
        string? ImageUrl,
        Guid CategoryId) : IRequestByServiceResult<Guid>;
}