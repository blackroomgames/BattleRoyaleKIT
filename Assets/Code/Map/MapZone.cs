using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using Code.Other;

namespace Code.Map
{
    public sealed class MapZone : MonoBehaviour
    {
        [Header("Start Zone Settings")]
        [SerializeField] private Transform[] _pivotPoints;
        private int _selectedPivotIndex;

        [Header("View Zone Settings")]
        [SerializeField] private Transform _gameCanvas;
        [SerializeField] private Image _viewZone;
        [SerializeField] private float _startViewZoneSize;
        [SerializeField] private float _finishViewZoneSize;
        [SerializeField] private float _speed;

        [Header("Test")]
        [SerializeField] private bool _isRun;

        private void Start()
        {
            _selectedPivotIndex = Random.Range(default, _pivotPoints.Length);
            _gameCanvas.position = _pivotPoints[_selectedPivotIndex].position;
            _viewZone.pixelsPerUnitMultiplier = _startViewZoneSize;
        }

        private void LateUpdate()
        {
            if (_isRun)
            {
                _viewZone.pixelsPerUnitMultiplier -= _speed * Time.deltaTime;
                _isRun = _viewZone.pixelsPerUnitMultiplier > _finishViewZoneSize;
            }
        }
    }
}