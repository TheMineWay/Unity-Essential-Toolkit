using UnityEngine;
using System;
using Newtonsoft.Json;

#if !UNITY_WEBGL && !UNITY_ANDROID && !UNITY_IOS
using System.IO;
#endif

namespace EssentialToolkit.Configuation
{
    internal partial class ConfigurationService {
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
        static readonly string configKey = "$__UET__config";
#else
        static readonly string fileName = Path.Combine(Application.dataPath, "UET_configuration.json");
#endif

        internal static ConfigurationState ReadConfiguration()
        {
            try
            {
                string data;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
                data = PlayerPrefs.GetString(configKey);
                if (string.IsNullOrEmpty(data)) return new();
#else
                data = File.Exists(fileName) ? File.ReadAllText(fileName) : null;
#endif
                return data == null ? new() : JsonConvert.DeserializeObject<ConfigurationState>(data);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            return new();
        }
        internal static void WriteConfiguration(ConfigurationState config)
        {
            try
            {
                var data = JsonConvert.SerializeObject(config);
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
                PlayerPrefs.SetString(configKey, data);
#else
                File.WriteAllText(fileName, data);
#endif
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}