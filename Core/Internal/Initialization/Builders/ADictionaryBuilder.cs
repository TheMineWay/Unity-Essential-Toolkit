using System;
using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Core
{
    [Serializable]
    public abstract class ADictionaryBuilder<T>
    {
        [SerializeField]
        private string key;

        [SerializeField]
        private T value;

        public string GetKey() => key;
        public T GetValue() => value;

        public static Dictionary<string, T> ToDictionary(ADictionaryBuilder<T>[] list)
        {
            var dict = new Dictionary<string, T>();

            foreach (var item in list) dict[item.GetKey()] = item.GetValue();

            return dict;
        }
    }
}