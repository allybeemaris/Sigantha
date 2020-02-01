using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Queries
{
    public static class TimelineGet
    {
        public class Query : IRequest<Result>
        {
            public Guid Id { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
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
                var timeline =
                    await _siganthaContext
                        .Timelines
                        .FirstOrDefaultAsync(s => s.Id == query.Id);

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
