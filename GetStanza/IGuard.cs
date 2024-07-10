using System.Threading;
using System.Threading.Tasks;

namespace GetStanza;

public interface IGuard
{
    Task<bool> AllowedAsync(CancellationToken cancellationToken = default);
    bool Allowed(CancellationToken cancellationToken = default);
}
