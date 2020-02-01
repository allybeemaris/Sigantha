using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Queries
{
    public static class EraGet
    {
        public class Query : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public Guid TimelineId { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                var era =
                    await _siganthaContext
                        .Eras
                        .FirstOrDefaultAsync(s => s.Id == query.Id);

                return new Result
                {
                    Id = era.Id,
                    TimelineId = era.TimelineId,
                    Name = era.Name,
                    Content = era.Content,
                    Start = era.Start,
                    End = era.End
                };
            }
        }
    }
}
