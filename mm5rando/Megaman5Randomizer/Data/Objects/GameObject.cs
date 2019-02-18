using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class GameObject
    {
        public int ObjectId;
        public string Name;

        public GameObject(int objectId, string name) {
            this.ObjectId = objectId;
            this.Name = name;
        }
    }
}
