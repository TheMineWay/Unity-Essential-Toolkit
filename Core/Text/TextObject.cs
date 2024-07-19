using UnityEngine;
using TMPro;

namespace EssentialToolkit
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextObject : MonoBehaviour
    {
        private TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        #region Text access

        public void SetText(string text) => textMeshPro.text = text;
        public string GetText() => textMeshPro.text;

        #endregion
    }
}
