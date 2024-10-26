using System.Collections;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    public class ConfigurationSceneManager : MonoBehaviour
    {
        internal static ConfigurationSceneManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            StartCoroutine(WaitForInitialization());
        }

        IEnumerator WaitForInitialization()
        {
            yield return new WaitUntil(() => ConfigurationInitializer.Instance != null);

            ApplyConfiguration();
        }

        #region API

        public void ApplyConfiguration()
        {
            var configState = ConfigurationService.ReadConfiguration();
            configState?.Apply();
        }

        #endregion
    }
}