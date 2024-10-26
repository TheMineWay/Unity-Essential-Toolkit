using EssentialToolkit.Core;

namespace EssentialToolkit.Configuation
{
    public partial class ConfigurationInitializer : AInitializer
    {
        internal static ConfigurationInitializer Instance { get; private set; } = null;
        public override void Initialize()
        {
            Instance = this;

            InitializeScreen();
        }
    }
}