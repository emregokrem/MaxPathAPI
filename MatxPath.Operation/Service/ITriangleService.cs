using System.Threading.Tasks;
using MaxPath.Domain.Entity;
using MaxPath.Domain.Request;

namespace MatxPath.Operation.Service
{
    public interface ITriangleService
    {
        Triangle CalculateTriangle(TriangleRequest request);
    }
}
