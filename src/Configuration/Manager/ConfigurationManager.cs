using EssentialToolkit.Core;
using System.Collections;
using UnityEngine;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationManager : AInitializer {
        public override void Initialize() => StartCoroutine(WaitForInitialization());

        IEnumerator WaitForInitialization()
        {
            yield return new WaitUntil(() => ConfigurationInitializer.Instance != null);

            InitScreen();
        }
    }
}