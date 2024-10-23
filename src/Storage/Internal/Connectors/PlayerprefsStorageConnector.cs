using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Storage
{
    public class PlayerprefsStorageConnector : AStorageConnector {
        public PlayerprefsStorageConnector(string serviceName) : base(serviceName) { }
        private string GetPathName() => "__UET-stg-s_" + serviceName + "__" + GetSlot();
        private Dictionary<string, string> InternalRead()
        {
            var name = GetPathName();
            if (PlayerPrefs.HasKey(name))
            {
                var data = PlayerPrefs.GetString(name);
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            }
            else return new();
        }

        private void InternalWrite(string key, string value) {
            var data = InternalRead();
            data[key] = value;

            PlayerPrefs.SetString(GetPathName(), JsonConvert.SerializeObject(data));
        }

        private void InternalDelete(string key)
        {
            var data = InternalRead();
            data.Remove(key);

            PlayerPrefs.SetString(GetPathName(), JsonConvert.SerializeObject(data));
        }

        #region IO

        // Write
        public override void Write(string key, string value) => InternalWrite(key, value);

        // Read
        public override string ReadString(string key) => HasKey(key) ? InternalRead()[key] : null;

        // Clear
        public override void Clear(string key) => InternalDelete(key);

        // Metadata
        public override bool HasKey(string key) => InternalRead().ContainsKey(key);

        #endregion

        #region Migrations

        public override void Import(string value)
        {
            JToken.Parse(value); // Check if `value` is a valid JSON
            PlayerPrefs.SetString(GetPathName(), value);
        }

        public override string Export() => PlayerPrefs.GetString(GetPathName());

        #endregion
    }
}