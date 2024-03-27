using UnityEngine;

public class Bank : Building
{
    private GameSettings _gameSettings;
    private Inventory _inventory;

    public Bank Init(Transform point, Inventory inventory, GameSettings gameSettings)
    {
        base.Init(point);
        _gameSettings = gameSettings;
        _inventory = inventory;
        return this;
    }

    protected override void OnPointTouched()
    {
        _inventory.AddMoney(_gameSettings.AddMoney);
    }
}
