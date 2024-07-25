using UnityEngine;

namespace EssentialToolkit.Core
{
    public abstract class AInitializer : MonoBehaviour
    {
        [SerializeField]
        [Header("Initialization mode")]
        private InitializeOn _initializeOn = InitializeOn.AWAKE;

        private void Awake()
        {
            if (_initializeOn != InitializeOn.AWAKE) Initialize();
        }

        private void Start()
        {
            if (_initializeOn != InitializeOn.START) Initialize();
        }

        public abstract void Initialize();
    }

    public enum InitializeOn
    {
        START,
        AWAKE,
        NO_AUTO_INITIALIZATION
    }
}
