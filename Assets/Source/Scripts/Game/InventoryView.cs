using TMPro;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private TMP_Text _meat;
    [SerializeField] private TMP_Text _money;

    private Inventory _inventory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;

        _inventory.MeatChanged += OnMeatChanged;
        _inventory.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _inventory.MeatChanged -= OnMeatChanged;
        _inventory.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMeatChanged(int meat)
    {
        _meat.text = meat.ToString();
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
