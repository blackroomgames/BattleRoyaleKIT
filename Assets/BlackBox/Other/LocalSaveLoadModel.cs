using System;
using UnityEngine;

namespace BlackBox
{
    public struct LocalSaveLoadModel : ISaveLoadModel
    {
        public T Load<T>(string name) where T : class
        {
            var json = PlayerPrefs.GetString(name, string.Empty);

            if (!string.IsNullOrEmpty(json))
            {
                return JsonUtility.FromJson<T>(json);
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }

        public void Save<T>(T saveFile, string name) where T : class
        {
            PlayerPrefs.SetString(name, JsonUtility.ToJson(saveFile));
        }
    }
}
