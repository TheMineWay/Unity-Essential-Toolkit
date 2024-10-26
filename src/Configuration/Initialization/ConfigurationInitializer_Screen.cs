using EssentialToolkit.Core;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    // Screen initializer
    public partial class ConfigurationInitializer : AInitializer
    {
        [SerializeField]
        [Header("Allowed resolution aspect ratios (leave empty to allow all)")]
        internal Vector2[] allowedAspectRatios;

        [SerializeField]
        internal ScreenOrientation orientation = ScreenOrientation.AutoRotation;

        private void InitializeScreen()
        {
            Screen.orientation = orientation;
        }
    }
}