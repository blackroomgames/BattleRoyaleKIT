using System;
using UnityEngine;

namespace BlackBox
{
    public static class SaveLoadHandler
    {
        private static ISaveLoadModel Model;

        public static void SetModel<T>()
            where T : struct, ISaveLoadModel
        {
            if (Model == null)
                Model = Activator.CreateInstance<T>();
        }

        public static void Save<T>(T saveFile, string name = "")
            where T : class, IDisposable
        {
            Model.Save<T>(saveFile, string.IsNullOrEmpty(name) ? nameof(T) : name);
        }

        public static T Load<T>(string name = "")
            where T : class, IDisposable
        {
            return Model.Load<T>(string.IsNullOrEmpty(name) ? nameof(T) : name);
        }
    }
}
