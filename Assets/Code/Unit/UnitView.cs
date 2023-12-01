using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Unit
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class UnitView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public NavMeshAgent Agent { get; private set; }
        public Animator Animator => _animator;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }
    }
}
