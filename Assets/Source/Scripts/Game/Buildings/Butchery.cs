using UnityEngine;

public class Butchery : Building
{
    private Inventory _inventory;
    private GameSettings _gameSettings;

    public override Building Init(Transform point)
    {
        return base.Init( point);
    }

    public Butchery Init(Transform point, Inventory inventory,GameSettings gameSettings)
    {
        base.Init(point);
        _gameSettings = gameSettings;
        _inventory = inventory;
        return this;
    }

    protected override void OnPointTouched()
    {
        _inventory.AddMeat(_gameSettings.AddMeat);
    }
}
