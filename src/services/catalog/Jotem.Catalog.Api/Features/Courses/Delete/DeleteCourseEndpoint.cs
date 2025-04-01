﻿using Jotem.Catalog.Api.Features.Courses.GetById;
using Jotem.Shared.Interfaces;
using Jotem.Shared.ServiceResults;

namespace Jotem.Catalog.Api.Features.Courses.Delete
{
    public record DeleteCourseCommand(Guid Id) : IRequestByServiceResult;


    public class DeleteCourseHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FindAsync([request.Id], cancellationToken: cancellationToken);
            if (hasCourse == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.Courses.Remove(hasCourse);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success();
        }
    }

    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}",
                    async (IMediator mediator, Guid id) =>
                        (await mediator.Send(new DeleteCourseCommand(id))).ToResult())
                .WithName("DeleteCourse")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}