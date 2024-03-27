using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private TigerSpawner _tigerSpawner;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private Clicker _clicker;
    [SerializeField] private BuildingSpawner _buildingSpawner;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private BankUpgrade _bankUpgrade;
    [SerializeField] private ButcheryUpgrade _butcheryUpgrade;
    [SerializeField] private TigerUpgrader _tigerUpgrade;

    private void Awake()
    {
        Inventory inventory = new Inventory();

        _bankUpgrade.Init(_settings, inventory, _buildingSpawner);
        _tigerUpgrade.Init(_settings, inventory, _tigerSpawner);
        _butcheryUpgrade.Init(_settings, inventory, _buildingSpawner);
        _inventoryView.Init(inventory);
        _tigerSpawner.Init(_settings, _clicker);
        _clicker.Init(_settings);
        _buildingSpawner.Init(_tigerSpawner, inventory, _settings);
    }

    private void Start()
    {
        _tigerSpawner.Spawn();
    }
}
