using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;

namespace Sigantha.Content.Queries
{
    public static class TimelineGetall
    {
        public class Query : IRequest<List<Result>>
        {
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Result>>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<List<Result>> Handle(Query query, CancellationToken cancellationToken)
            {
                var timelines =
                    await _siganthaContext
                        .Timelines
                        .ToListAsync();

                return timelines
                    .Select(s => new Result
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Content = s.Content
                    })
                    .ToList();
            }
        }
    }
}
