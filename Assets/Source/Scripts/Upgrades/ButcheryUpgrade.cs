using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcheryUpgrade : Upgrader
{
    [SerializeField] private List<BuildingSetting> _positions;

    private BuildingSpawner _spawner;

    public override void Init(GameSettings gameSettings, Inventory inventory)
    {
        base.Init(gameSettings, inventory);
    }

    public void Init(GameSettings gameSettings, Inventory inventory, BuildingSpawner buildingSpawner)
    {
        base.Init(gameSettings, inventory);
        _spawner = buildingSpawner;
    }

    public override void Upgrade()
    {
        Inventory.ReduceMoney(GameSettings.ButcheryUpgradePrices[CurrentLevel]);
        _spawner.SpawnButchery(_positions[CurrentLevel].BuildingPoint, _positions[CurrentLevel].PathPoint);
        CurrentLevel++;
    }

    protected override bool CanBuy()
    {
        if (GameSettings.ButcheryUpgradePrices[CurrentLevel] > Inventory.Money)
            return false;

        return true;
    }

    protected override bool CanUpgraded()
    {
        return GameSettings.ButcheryUpgradePrices.Count != CurrentLevel;
    }

    protected override void UpdatePrice()
    {
        TextPrice.text = GameSettings.ButcheryUpgradePrices[CurrentLevel].ToString();
    }
}
