using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private Butchery _butcheryPrefab;
    [SerializeField] private Bank _bankPrefab;
    [SerializeField] private List<BuildingSetting> _startButchery;
    [SerializeField] private List<BuildingSetting> _startBank;

    private TigerSpawner _spawner;
    private Inventory _inventory;
    private List<Building> _buildings = new List<Building>();
    private GameSettings _gameSettings;

    public void Init(TigerSpawner tigerSpawner, Inventory inventory, GameSettings gameSettings)
    {
        _inventory = inventory;
        _spawner = tigerSpawner;
        _gameSettings = gameSettings;

        _spawner.TigerSpawned += UpdateSubscribe;
    }

    private void OnDisable()
    {
        _spawner.TigerSpawned -= UpdateSubscribe;
    }

    private void Start()
    {
        foreach (BuildingSetting building in _startButchery)
            SpawnButchery(building.BuildingPoint, building.PathPoint);

        foreach (BuildingSetting building in _startBank)
            SpawnBank(building.BuildingPoint, building.PathPoint);
    }

    public void SpawnButchery(Transform butcheryPoint, Transform pathPoint)
    {
        Building building = Instantiate(_butcheryPrefab, butcheryPoint.position, Quaternion.identity).Init(pathPoint, _inventory, _gameSettings);
        _buildings.Add(building);
        UpdateSubscribe();
    }

    public void SpawnBank(Transform bankPoint, Transform pathPoint)
    {
        Building building = Instantiate(_bankPrefab, bankPoint.position, Quaternion.identity).Init(pathPoint, _inventory, _gameSettings);
        _buildings.Add(building);
        UpdateSubscribe();
    }

    private void UpdateSubscribe()
    {
        TigerMover[] movers = _spawner.Tigers.Select(x => x.TigerMover).ToArray();

        foreach (Building building in _buildings)
        {
            building.UpdateSubscribe(movers);
        }
    }
}

[Serializable]
public class BuildingSetting
{
    [field: SerializeField] public Transform BuildingPoint { get; private set; }
    [field: SerializeField] public Transform PathPoint { get; private set; }
}
