using System;
using System.Linq;
using UnityEngine;

public class TigerMover : MonoBehaviour
{
    private GameSettings _gameSettings;
    private Transform[] _path;
    private Clicker _clicker;
    private int _currentPointIndex = 0;

    public Action<Transform> PointTouched;

    public void Init(Transform[] path, Transform spawnPoint, GameSettings gameSettings, Clicker clicker)
    {
        _gameSettings = gameSettings;
        _path = path;
        _currentPointIndex = Array.IndexOf(_path, spawnPoint);
        _clicker = clicker;
    }

    private void Update()
    {
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        if (_path == null || _path.Length == 0) return;

        Transform targetPoint = _path[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _clicker.AdditionalSpeed * _gameSettings.StartTigerSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            PointTouched?.Invoke(targetPoint);
            _currentPointIndex++;
            if (_currentPointIndex >= _path.Length)
            {
                _currentPointIndex = 0;
            }
        }
    }
}
