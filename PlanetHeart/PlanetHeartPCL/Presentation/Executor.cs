using PlanetHeart.Domain;

namespace PlanetHeart.Presentation
{
    public class Executor
    {
        public void Execute(IInteractor interaction)
        {
            interaction.Execute();
        }
    }
}