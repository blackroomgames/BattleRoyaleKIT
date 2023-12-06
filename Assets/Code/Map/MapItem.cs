using System;
using UnityEngine;

namespace Code.Map
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public sealed class MapItem : MonoBehaviour
    {

        public event Action<MapItem> OnPutUpItem;//TODO add active unit

        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;

            var collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnPutUpItem?.Invoke(this);
        }
    }
}
