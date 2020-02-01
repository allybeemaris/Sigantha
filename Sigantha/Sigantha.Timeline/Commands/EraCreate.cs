using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Sigantha.Data.Contexts;
using Sigantha.Data.Entities;

namespace Sigantha.Content.Commands
{
    public static class EraCreate
    {
        public class Command : IRequest<Result>
        {
            public Guid TimelineId { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
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
                var era = new Era
                {
                    Name = command.Name,
                    Content = command.Content,
                    Start = command.Start,
                    End = command.End,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };

                _siganthaContext.Eras.Add(era);
                await _siganthaContext.SaveChangesAsync();

                return new Result { Id = era.Id };
            }
        }
    }
}
