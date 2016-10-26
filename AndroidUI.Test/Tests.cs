using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace AndroidUI.Test
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
                app = ConfigureApp
                .Android
                .ApkFile($"../../PlanetHeart.Droid/bin/Debug/PlanetHeart.Droid.apk")
                .StartApp();
        }

    }
}

