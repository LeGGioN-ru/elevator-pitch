using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerUpgrader : Upgrader
{
    private TigerSpawner _spawner;


    public override void Init(GameSettings gameSettings, Inventory inventory)
    {
        base.Init(gameSettings, inventory);
    }

    public void Init(GameSettings gameSettings, Inventory inventory, TigerSpawner tigerSpawner)
    {
        base.Init(gameSettings, inventory);
        _spawner = tigerSpawner;
    }

    public override void Upgrade()
    {
        Inventory.ReduceMoney(GameSettings.TigersUpgradePrices[CurrentLevel]);
        _spawner.Spawn();
        CurrentLevel++;
    }

    protected override bool CanBuy()
    {
        if (GameSettings.TigersUpgradePrices[CurrentLevel] > Inventory.Money)
            return false;

        return true;
    }

    protected override bool CanUpgraded()
    {
        return GameSettings.TigersUpgradePrices.Count != CurrentLevel;
    }

    protected override void UpdatePrice()
    {
        TextPrice.text = GameSettings.TigersUpgradePrices[CurrentLevel].ToString();
    }
}
