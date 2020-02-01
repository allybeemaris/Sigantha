using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Commands
{
    public static class EraDelete
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
            public string Start { get; set; }
            public string End { get; set; }
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
                var era =
                    await _siganthaContext
                        .Eras
                        .FirstOrDefaultAsync(s => s.Id == command.Id);

                _siganthaContext.Eras.Remove(era);
                await _siganthaContext.SaveChangesAsync();

                return new Result
                {
                    Id = era.Id,
                    Name = era.Name,
                    Content = era.Content,
                    Start = era.Start,
                    End = era.End
                };
            }
        }
    }
}
