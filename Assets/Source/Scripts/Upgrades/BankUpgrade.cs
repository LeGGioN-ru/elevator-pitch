using System.Collections.Generic;
using UnityEngine;

public class BankUpgrade : Upgrader
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
        Inventory.ReduceMeat(GameSettings.BankUpgradePrices[CurrentLevel]);
        _spawner.SpawnBank(_positions[CurrentLevel].BuildingPoint, _positions[CurrentLevel].PathPoint);
        CurrentLevel++;
    }

    protected override bool CanBuy()
    {
        if (GameSettings.BankUpgradePrices[CurrentLevel] > Inventory.Meat)
            return false;

        return true;
    }

    protected override bool CanUpgraded()
    {
        return GameSettings.BankUpgradePrices.Count != CurrentLevel;
    }

    protected override void UpdatePrice()
    {
        TextPrice.text = GameSettings.BankUpgradePrices[CurrentLevel].ToString();
    }
}
