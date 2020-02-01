using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Commands
{
    public static class EraUpdate
    {
        public class Command : IRequest<Command>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
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
                var era =
                    await _siganthaContext
                        .Eras
                        .FirstOrDefaultAsync(s => s.Id == command.Id);

                era.Name = command.Name;
                era.Content = command.Content;
                era.Start = command.Start;
                era.End = command.End;
                era.Modified = DateTime.UtcNow;

                await _siganthaContext.SaveChangesAsync();

                return command;
            }
        }
    }
}
