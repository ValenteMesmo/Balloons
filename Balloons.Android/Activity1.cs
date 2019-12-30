using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Balloons.Core;
using Microsoft.Xna.Framework;

namespace Balloons.Android
{
    [Activity(
        Label = "Balloons.Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = LaunchMode.Multiple
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges =
            ConfigChanges.Orientation
            | ConfigChanges.Keyboard
            | ConfigChanges.KeyboardHidden
            | ConfigChanges.ScreenSize)]
    public class Activity1 : AndroidGameActivity
    {
        private Game1 game;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            game = new Game1(new AndroidContentLoader(Assets), true);
            SetViewFullScreen();

            game.Run();
        }

        private void SetViewFullScreen()
        {
            var view = (View)game.Services.GetService(typeof(View));

            view.SystemUiVisibility = (StatusBarVisibility)
                (SystemUiFlags.LayoutStable
                | SystemUiFlags.LayoutHideNavigation
                | SystemUiFlags.LayoutFullscreen
                | SystemUiFlags.HideNavigation
                | SystemUiFlags.Fullscreen
                | SystemUiFlags.ImmersiveSticky);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                Window.Attributes.LayoutInDisplayCutoutMode =
                    LayoutInDisplayCutoutMode.ShortEdges;

            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            Window.AddFlags(WindowManagerFlags.Secure);
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            SetContentView(view);
        }
    }
}

