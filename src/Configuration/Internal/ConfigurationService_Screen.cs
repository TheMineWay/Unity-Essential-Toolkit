using EssentialToolkit.Configuration;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    // Screen related utils
    internal partial class ConfigurationService
    {
        /* Return available resolutions.
         * Optionally, filter by aspect ratio (example: GetAvailableScreenResolutions(16f / 9f)) */
        public static Resolution[] GetAvailableScreenResolutions(float[] aspectRatios = null)
        {
            // Use a HashSet to store unique resolutions
            HashSet<Resolution> uniqueResolutions = new(new ResolutionComparer());

            if (aspectRatios != null && aspectRatios.Length > 0)
            {
                // Filter resolutions by aspect ratios
                var filteredResolutions = Screen.resolutions
                                                 .Where(res => aspectRatios.Any(ar => Mathf.Approximately((float)res.width / res.height, ar)));

                foreach (var res in filteredResolutions) uniqueResolutions.Add(res);
            }
            
            if (uniqueResolutions.Count <= 0)
            {
                // Add all resolutions if no resolutions are present
                foreach (var res in Screen.resolutions) uniqueResolutions.Add(res);
            }

            // Return the unique resolutions as an array
            return uniqueResolutions.ToArray();
        }
        public static Resolution[] GetAvailableScreenResolutions(Vector2[] aspectRatios)
        {
            // Convert Vector2 aspect ratios to float array
            return GetAvailableScreenResolutions(aspectRatios.Select(v => v.x / v.y).ToArray());
        }

        public static ManagedDisplay[] GetAvailableDisplays() => (from display in Display.displays select new ManagedDisplay(display)).ToArray();

        public static bool SupportsMultipleDisplays() => Display.displays.Length > 1;
        public static void SetMaxFPS(int? maxFPS = null)
        {
            // Calculate the refresh rate from refreshRateRatio if no maxFPS is specified
            if (!maxFPS.HasValue)
            {
                var refreshRate = Screen.currentResolution.refreshRateRatio;
                maxFPS = Mathf.RoundToInt(refreshRate.numerator / refreshRate.denominator);
            }

            Application.targetFrameRate = maxFPS.Value;
        }
    }

    internal class ResolutionComparer : IEqualityComparer<Resolution>
    {
        public bool Equals(Resolution x, Resolution y) => x.width == y.width && x.height == y.height;
        public int GetHashCode(Resolution obj) => obj.width.GetHashCode() ^ obj.height.GetHashCode();
    }
}