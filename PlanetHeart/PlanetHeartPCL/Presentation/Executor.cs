using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class Executor
    {
        public void Execute(IInteractor interaction)
        {
            interaction.Execute();
        }
    }
}