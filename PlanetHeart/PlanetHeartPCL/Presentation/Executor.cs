using System.Threading;
using System.Threading.Tasks;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class Executor
    {
        public void Execute(IInteractor interaction)
        {
            Task.Factory.StartNew(interaction.Execute, 
                                    CancellationToken.None, 
                                    TaskCreationOptions.DenyChildAttach, 
                                    TaskScheduler.Default);
        }
    }
}