﻿

namespace Jotem.Catalog.Api.Features.Courses.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/",
                    async (UpdateCourseCommand command, IMediator mediator) =>
                        (await mediator.Send(command)).ToResult())
                .WithName("UpdateCourse")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();

            return group;
        }
    }
}