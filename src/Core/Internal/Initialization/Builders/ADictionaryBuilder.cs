using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EssentialToolkit.Core
{
    [Serializable]
    public abstract class ADictionaryBuilder<K, V>
    {
        [SerializeField]
        private K key;

        [SerializeField]
        private V value;

        public K GetKey() => key;
        public V GetValue() => value;

        public static Dictionary<K, V> ToDictionary(ADictionaryBuilder<K, V>[] list)
        {
            var dict = new Dictionary<K, V>();

            foreach (var item in list) dict[item.GetKey()] = item.GetValue();

            return dict;
        }

        public static Dictionary<K, V> Merge(ADictionaryBuilder<K, V>[] dbuilder, Dictionary<K, V> other) {
            return other.Concat(ToDictionary(dbuilder)).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}