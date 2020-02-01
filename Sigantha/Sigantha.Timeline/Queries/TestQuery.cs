using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Sigantha.Data.Contexts;
using Sigantha.Data.Entities;

namespace Sigantha.Content.Queries
{
    public static class TestQuery
    {
        public class Query : IRequest<Temp>
        {

        }

        public class Temp
        {
            public Timeline Test { get; set; }
        }

        public class Handler : IRequestHandler<Query, Temp>
        {
            private readonly SiganthaContext _siganthaContext;

            public Handler(SiganthaContext siganthaContext)
            {
                _siganthaContext = siganthaContext;
            }

            public async Task<Temp> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Temp { Test = await _siganthaContext.Timelines.FirstOrDefaultAsync() };
            }
        }
    }
}
