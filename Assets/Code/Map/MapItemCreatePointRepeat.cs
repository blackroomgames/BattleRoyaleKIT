using UnityEngine;

namespace Code.Map
{
    public sealed class MapItemCreatePointRepeat : MapItemCreatePoint
    {
        [SerializeField] private float _repeatTime;

        private void OnDestroy()
        {
            CancelInvoke(nameof(CreateRepeating));
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(CreateRepeating));
        }

        protected override void ReturnItem(MapItem item)
        {
            base.ReturnItem(item);
            InvokeRepeating(nameof(CreateRepeating), _repeatTime, _repeatTime);
        }

        private void CreateRepeating()
        {
            Create();

            if(item != null)
            {
                CancelInvoke(nameof(CreateRepeating));
            }
        }

#if UNITY_EDITOR
        protected override Color DrawColor => Color.green;
#endif
    }
}
