using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using MonogameFacade;
using System.Threading.Tasks;

namespace Balloons.Android
{
    [Activity(Label = "Balloons.Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        private AndroidGame game;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            game = new AndroidGame(Assets);
            SetViewFullScreen();
            game.Run();

            game.Objects.Add(new CreateBlock());

            //Task.Factory.StartNew(async () =>
            //{
            //    await Task.Delay(1500);

            //    for (int k = 0; k < 1; k++)
            //        for (int i = 0; i < 100; i++)
            //            for (int j = 0; j < 100; j++)
            //            {
            //                var obj = new Block(game);
            //                obj.Position.X = i * 10;
            //                obj.Position.Y = j * 10;
            //                game.Objects.Add(obj);
            //            }

            //    game.Objects.Add(new FpsDisplay(game));
            //});
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


            Window.AddFlags(WindowManagerFlags.Fullscreen);

            //if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P)
            {
                Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.ShortEdges;
            }

            SetContentView(view);
        }
    }
}

