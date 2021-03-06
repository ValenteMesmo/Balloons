﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonogameFacade
{
    public class DesktopContetLoader : ContentLoader
    {
        public override Dictionary<string, Texture2D> LoadTextures(ContentManager contentManager)
        {
            var result = new Dictionary<string, Texture2D>();

            var files = Directory.GetFiles("Content/Textures");
            foreach (var file in files)
            {
                var key = Path.GetFileNameWithoutExtension(file);
                var path = $"Textures/{key}";
                result.Add(key, contentManager.Load<Texture2D>(path));
            }

            return result;
        }
    }
}
