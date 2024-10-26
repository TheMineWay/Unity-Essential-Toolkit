using EssentialToolkit.Configuation;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Configuration
{
    public class ManagedDisplay
    {
        public Display Display { internal set; get; }

        internal ManagedDisplay(Display display)
        {
            Display = display;
        }

        /// <summary>
        /// Activates this display to show the game output.
        /// </summary>
        public void Pick()
        {
            var isActiveDisplay = IsActive();

            if (!isActiveDisplay)
            {
                Camera.main.targetDisplay = GetIndex();
            }
        }

        /// <summary>
        /// Returns true if this display is currently displaying the game.
        /// </summary>
        public bool IsActive() => Display.active;

        /// <summary>
        /// Returns the index of this display in the available displays.
        /// </summary>
        public int GetIndex()
        {
            var index = System.Array.IndexOf(ConfigurationService.GetAvailableDisplays(), Display);

            return index == -1 ? 0 : index;
        }

        /// <summary>
        /// Returns the name of this display
        /// </summary>
        public string GetName() => $"#{GetIndex() + 1}: {Display.systemWidth}x{Display.systemHeight}";

        /// <summary>
        /// Returns available screen resolutions for this display, optionally filtering by aspect ratio.
        /// </summary>
        /// <param name="aspectRatio">Optional aspect ratio to filter resolutions.</param>
        public List<Vector2> GetAvailableResolutions(float? aspectRatio = null)
        {
            List<Vector2> resolutions = new List<Vector2>();

            foreach (var res in Screen.resolutions)
            {
                // Filter by aspect ratio if provided
                if (aspectRatio.HasValue && !Mathf.Approximately((float)res.width / res.height, aspectRatio.Value))
                    continue;

                resolutions.Add(new Vector2(res.width, res.height));
            }

            return resolutions;
        }

        /// <summary>
        /// Returns the refresh rate (FPS) of this display.
        /// </summary>
        public int GetRefreshRate()
        {
            var refreshRateRatio = Screen.currentResolution.refreshRateRatio;
            return Mathf.RoundToInt(refreshRateRatio.numerator / refreshRateRatio.denominator);
        }
    }
}
