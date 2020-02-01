using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Commands
{
    public static class TimelineDelete
    {
        public class Command : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
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
                var timeline =
                    await _siganthaContext
                        .Timelines
                        .FirstOrDefaultAsync(s => s.Id == command.Id);

                _siganthaContext.Timelines.Remove(timeline);
                await _siganthaContext.SaveChangesAsync();

                return new Result
                {
                    Id = timeline.Id,
                    Name = timeline.Name,
                    Content = timeline.Content
                };
            }
        }
    }
}
