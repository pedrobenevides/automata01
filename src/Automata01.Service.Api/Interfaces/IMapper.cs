using System.Collections.Generic;

namespace Automata01.Service.Api.Interfaces
{
    public interface IMapper<T> where T : class
    {
        IReadOnlyCollection<T> Trasform(string input);
    }
}