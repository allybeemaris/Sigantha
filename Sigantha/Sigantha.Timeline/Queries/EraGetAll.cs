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
    public static class EraGetAll
    {
        public class Query : IRequest<List<Result>>
        {
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

        public class Handler : IRequestHandler<Query, List<Result>>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<List<Result>> Handle(Query query, CancellationToken cancellationToken)
            {
                var eras =
                    await _siganthaContext
                        .Eras
                        .ToListAsync();

                return eras
                    .Select(s => new Result
                    {
                        Id = s.Id,
                        TimelineId = s.TimelineId,
                        Name = s.Name,
                        Content = s.Content,
                        Start = s.Start,
                        End = s.End
                    })
                    .ToList();
            }
        }
    }
}
