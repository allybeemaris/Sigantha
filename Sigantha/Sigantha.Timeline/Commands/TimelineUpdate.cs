using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Sigantha.Data.Contexts;

namespace Sigantha.Content.Commands
{
    public static class TimelineUpdate
    {
        public class Command : IRequest<Command>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
        }

        public class Handler : IRequestHandler<Command, Command>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<Command> Handle(Command command, CancellationToken cancellationToken)
            {
                var timeline =
                    await _siganthaContext
                        .Timelines
                        .FirstOrDefaultAsync(s => s.Id == command.Id);

                timeline.Name = command.Name;
                timeline.Content = command.Content;
                timeline.Modified = DateTime.UtcNow;

                await _siganthaContext.SaveChangesAsync();

                return command;
            }
        }
    }
}
