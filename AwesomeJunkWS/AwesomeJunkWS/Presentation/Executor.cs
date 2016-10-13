using AwesomeJunkWS.Domain;

namespace AwesomeJunkWS.Presentation
{
    public class Executor
    {
        public void Execute(IInteractor interaction)
        {
            interaction.Execute();
        }
    }
}