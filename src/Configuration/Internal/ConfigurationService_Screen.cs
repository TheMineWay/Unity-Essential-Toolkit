using EssentialToolkit.Configuration;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    // Screen related utils
    public partial class ConfigurationService
    {
        /* Return available resolutions.
         * Optionally, filter by aspect ratio (example: GetAvailableScreenResolutions(16f / 9f)) */
        public static Resolution[] GetAvailableScreenResolutions(float? aspectRatio = null)
        {
            // Use a HashSet to store unique resolutions
            HashSet<Resolution> uniqueResolutions = new(new ResolutionComparer());

            if (aspectRatio.HasValue)
            {
                // Filter resolutions by aspect ratio (width / height)
                var filteredResolutions = Screen.resolutions
                                                 .Where(res => Mathf.Approximately((float)res.width / res.height, aspectRatio.Value));

                foreach (var res in filteredResolutions) uniqueResolutions.Add(res);
            }
            else
            {
                // Add all resolutions if no aspect ratio is provided
                foreach (var res in Screen.resolutions) uniqueResolutions.Add(res);
            }

            // Return the unique resolutions as an array
            return uniqueResolutions.ToArray();
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