using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Sigantha.Data.Contexts;
using Sigantha.Data.Entities;

namespace Sigantha.Content.Commands
{
    public static class TimelineCreate
    {
        public class Command : IRequest<Result>
        {
            public string Name { get; set; }
            public string Content { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                var timeline = new Timeline
                {
                    Name = command.Name,
                    Content = command.Content,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };

                _siganthaContext.Timelines.Add(timeline);
                await _siganthaContext.SaveChangesAsync();

                return new Result { Id = timeline.Id };
            }
        }
    }
}
