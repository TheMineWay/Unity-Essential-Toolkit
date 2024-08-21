using UnityEngine;

namespace EssentialToolkit.Core
{
    internal class PackageInit
    {
        [RuntimeInitializeOnLoadMethod]
        private static void LogPackageInfo()
        {
#if !UNITY_EDITOR
            Debug.Log("-- UNITY ESSENTIAL TOOLKIT --");

            Debug.Log($"Package version: {PackageInfo.VERSION}");
            Debug.Log($"Github repository URL: {PackageInfo.REPOSITORY_URL}");

            Debug.Log("-- UNITY ESSENTIAL TOOLKIT --");
# endif
        }
    }
}