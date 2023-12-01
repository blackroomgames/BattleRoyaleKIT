using UnityEngine;
//using GamePush;

namespace BlackBox
{
    public struct GamePushSaveLoadModel : ISaveLoadModel
    {
        public T Load<T>(string name) where T : class
        {
            //    GP_Player.Load();
            //    var json = GP_Player.GetString(name);

            //    if (string.IsNullOrEmpty(json))
            //    {
            //        return System.Activator.CreateInstance<T>();
            //    }
            //    else 
            //    {
            //        return JsonUtility.FromJson<T>(GP_Player.GetString(name));
            //    }

            throw new System.Exception();
        }


        public void Save<T>(T saveFile, string name) where T : class
        {
            //GP_Player.Set(name, JsonUtility.ToJson(saveFile));
            //GP_Player.Sync();
        }
    }
}
