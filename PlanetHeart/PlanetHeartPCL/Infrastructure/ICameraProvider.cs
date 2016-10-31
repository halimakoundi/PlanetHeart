using System.Threading.Tasks;

namespace PlanetHeartPCL.Infrastructure
{
    public interface ICameraProvider
    {
        Task<CameraResult> TakePictureAsync();
    }
}