using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Balloons.Core
{
    public class World
    {
        private List<GameObject> objectsInternalList { get; } = new List<GameObject>();
        public GameObject[] Objects { get; private set; }
        public readonly Dictionary<string, Texture2D> Textures;

        public readonly Camera camera;
        public readonly TouchController TouchInputs;

        public World(Camera camera, Dictionary<string, Texture2D> Textures)
        {
            this.camera = camera;
            TouchInputs = new TouchController(camera);
            this.Textures = Textures;
        }

        public void AddObject(GameObject obj)
        {
            objectsInternalList.Add(obj);
        }

        public void Update()
        {
            TouchInputs.Update();

            Objects = objectsInternalList.ToArray();
            for (var i = 0; i < Objects.Length; i++)
            {
                var obj = Objects[i];

                if (obj.Destroyed)
                    objectsInternalList.Remove(obj);
                else
                    obj.Update();
            }

            camera.Update();
        }
    }
}
