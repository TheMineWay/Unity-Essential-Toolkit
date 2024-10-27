using System;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    [Serializable]
    public class Resolution
    {
        [SerializeField]
        public int width { get; private set; }

        [SerializeField]
        public int height { get; private set; }

        public Resolution(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}