using System;
using System.Collections.Generic;
using UnityEngine;

public class TigerSpawner : MonoBehaviour
{
    [SerializeField] private Tiger _tiger;
    [SerializeField] private Transform _roadParent;

    public Action TigerSpawned;

    private Transform[] _path;
    private GameSettings _gameSettings;
    private Clicker _clicker;
    private List<Tiger> _tigers = new List<Tiger>();

    public IReadOnlyList<Tiger> Tigers=> _tigers;

    private void Awake()
    {
        _path = _roadParent.GetComponentsInChildren<Transform>();
    }

    public void Init(GameSettings gameSettings, Clicker clicker)
    {
        _gameSettings = gameSettings;
        _clicker = clicker;
    }

    public void Spawn()
    {
        Transform spawnPoint = _path.RandomElement();
        Tiger tiger = Instantiate(_tiger, spawnPoint.position, Quaternion.identity).Init(_path, spawnPoint, _gameSettings, _clicker);
        _tigers.Add(tiger);
        TigerSpawned?.Invoke();
    }
}
