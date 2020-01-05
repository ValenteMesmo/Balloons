﻿using Microsoft.Xna.Framework;

namespace Balloons.Core
{
    public class SpriteSheetAnimation : Behavior
    {
        private readonly SpriteData[] Sprites;
        private readonly GameObject obj;
        private readonly int lastIndex;
        private int currentIndex;
        private int updateCount;
        public SpriteSheetAnimation(GameObject obj, params SpriteData[] Sprites)
        {
            this.lastIndex = Sprites.Length - 1;
            this.Sprites = Sprites;
            this.obj = obj;
        }
        
        public override void Update()
        {
            updateCount++;
            if (updateCount < 5)
                return;

            updateCount = 0;

            obj.Sprites.Clear();
            var sprite = Sprites[currentIndex];
            sprite.targetRectangle = new Rectangle(
               obj.X
               , obj.Y
               , sprite.targetRectangle.Width
               , sprite.targetRectangle.Height);
            obj.Sprites.Add(sprite);

            currentIndex++;
            if (currentIndex > lastIndex)
                currentIndex = 0;
        }
    }

    public class SingleTextureAnimation : Behavior
    {
        private readonly SpriteData Sprite;
        private readonly GameObject obj;

        public SingleTextureAnimation(
            GameObject obj
            , SpriteData SpriteData)
        {
            Sprite = SpriteData;
            obj.Sprites.Add(SpriteData);
            this.obj = obj;
        }

        public override void Update()
        {
            Sprite.targetRectangle = new Rectangle(
                obj.X
                , obj.Y
                , Sprite.targetRectangle.Width
                , Sprite.targetRectangle.Height);
        }
    }
}
