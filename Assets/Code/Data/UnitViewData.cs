using System.Collections.Generic;
using UnityEngine;

using Code.Unit;

namespace Code.Data
{
    [CreateAssetMenu(fileName = nameof(UnitViewData), menuName = "Data/"+ nameof(UnitViewData))]
    public sealed class UnitViewData : ScriptableObject
    {
        [SerializeField] private UnitView[] _enemyView;
        [SerializeField] private UnitView[] _playerView;

        public IReadOnlyList<UnitView> EnemyView => _enemyView;
        public IReadOnlyList<UnitView> PlayerView => _playerView;
    }
}
