using System;

public class Inventory
{
    public Action<int> MeatChanged;
    public Action<int> MoneyChanged;

    public int Meat { get; private set; }
    public int Money { get; private set; }

    public void AddMeat(int addition)
    {
        if (addition > 0)
        {
            Meat += addition;
            MeatChanged?.Invoke(Meat);
        }
    }

    public void AddMoney(int addition)
    {
        if (addition > 0)
        {
            Money += addition;
            MoneyChanged?.Invoke(Money);
        }
    }

    public void ReduceMoney(int reducion)
    {
        Money -= reducion;
        MoneyChanged?.Invoke(Money);
    }

    public void ReduceMeat(int reduction)
    {
        Meat -= reduction;
        MeatChanged?.Invoke(Meat);
    }
}
