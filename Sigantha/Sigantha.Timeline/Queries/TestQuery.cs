using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Sigantha.Timeline.Queries
{
    public static class TestQuery
    {
        public class Query : IRequest<Temp>
        {

        }

        public class Temp
        {
            public string s => "Hello World";
        }

        public class Handler : IRequestHandler<Query, Temp>
        {
            public async Task<Temp> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Temp();
            }
        }
    }
}
