using Android.Content.Res;
using Android.Views;
using Balloons.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Balloons.Android
{
    public class AndroidContentLoader : ContentLoader
    {
        private readonly AssetManager AssetManager;

        public AndroidContentLoader(AssetManager AssetManager)
        {
            this.AssetManager = AssetManager;
        }

        public override Dictionary<string, Texture2D> LoadTextures(ContentManager value)
        {
            var result = new Dictionary<string, Texture2D>();

            var textures = AssetManager.List("Content/Textures");

            foreach (var texture in textures)
            {
                var key = Path.GetFileNameWithoutExtension(texture);
                result.Add(key, value.Load<Texture2D>($"Textures/{key}"));
            }

            return result;
        }
    }

}

