using System;
using System.Collections.Generic;
using System.Linq;

namespace EssentialToolkit.Dialogs
{
    public class DialogEntry : ARegisterDialogEntry
    {

        public DialogEntry(ARegisterDialogEntry baseProps, string text)
        {
            this.text = text;
            code = baseProps.GetCode();
            speaker = baseProps.GetSpeaker();
            images = baseProps.GetImages();
            locked = baseProps.IsLocked();
        }

        #region Properties
        // Text
        private string text;
        public string GetText() => text;
        public void SetText(string text) => this.text = text;
        #endregion

        #region API

        public bool HasSpeaker() => GetSpeaker() != null;

        #endregion

# region Static API

        public static T[] ParseDialogEntryFromJSON<T>(string json) where T : ARegisterDialogEntry {

            T ProcessEntry(T entry, string code)
            {
                entry.SetCode(code);
                return entry;
            }

            try
            {
                var parsed = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
                return (from entryCode in parsed.Keys select ProcessEntry(parsed[entryCode], entryCode)).ToArray();
            }
            catch (Exception ex)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.LogError($"Error while parsing a JSON file containing dialogs: {ex.Message}");
# endif
                throw ex;
            }
        }

# endregion
    }
}