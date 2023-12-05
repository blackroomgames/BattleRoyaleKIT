using System;
using System.Collections.Generic;
using UnityEngine;

using Code.Map;

using Random = UnityEngine.Random;

namespace Code.Data
{
    [CreateAssetMenu(fileName = nameof(MapItemData), menuName = "Data/"+nameof(MapItemData))]
    public sealed class MapItemData : ScriptableObject
    {
        [SerializeField] private List<Setting> _setting;
        public float MaxItemChance
        {
            get
            {
                var result = 0f;

                _setting.ForEach(x =>
                {
                    if (x.createChance > result)
                    {
                        result = x.createChance;
                    }
                });

                return result + 10;
            }
        }

        public bool TryGetObject(out MapItem itemPrefab, float currentChance = 0)
        {
            if(currentChance == 0)
            {
                itemPrefab = _setting[Random.Range(default, _setting.Count)].itemPrefab;
            }
            else
            {
                Setting currentSetting = default;

                _setting.ForEach(x =>
                {
                    if (currentChance >= x.createChance)
                    {
                        if(currentSetting.createChance == 0)
                        {
                            currentSetting = x;
                        }
                        else if (x.createChance == currentSetting.createChance)
                        {
                            currentSetting = Random.value <= 0.5f ? x : currentSetting;
                        }
                        else if (x.createChance > currentSetting.createChance)
                        {
                            currentSetting = x;
                        }
                    }
                });

                itemPrefab = currentSetting.itemPrefab;
            }

            return itemPrefab != null;
        }

        [Serializable]
        private struct Setting
        {
            public MapItem itemPrefab;
            public float createChance;
        }
    }
}
