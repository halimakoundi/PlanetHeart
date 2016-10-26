namespace PlanetHeartPCL.Presentation
{
    public interface INavigator
    {
        void NavigateTo(Screen screen);
    }

    public enum Screen
    {
        Reward
    }
}
