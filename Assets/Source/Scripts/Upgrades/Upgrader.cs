using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] protected Button UpgradeButton;
    [SerializeField] protected TMP_Text TextPrice;
    [SerializeField] protected TMP_Text ButtonText;

    protected int CurrentLevel;
    protected GameSettings GameSettings;
    protected Inventory Inventory;

    public virtual void Init(GameSettings gameSettings, Inventory inventory)
    {
        Inventory = inventory;
        GameSettings = gameSettings;

        UpgradeButton.onClick.AddListener(TryUpgrade);
    }

    private void OnDisable()
    {
        UpgradeButton.onClick.RemoveListener(TryUpgrade);
    }

    protected virtual void Update()
    {
        if (CanUpgraded() == false)
        {
            TextPrice.text = "MAX";
            UpgradeButton.interactable = true;
            return;
        }
        
        TryUpdatePrice();
        UpgradeButton.interactable = CanBuy();
    }

    private void TryUpgrade()
    {
        if(CanUpgraded())
            Upgrade();
    }

    private void TryUpdatePrice()
    {
        if (CanUpgraded())
            UpdatePrice();
    }

    protected abstract bool CanBuy();
    protected abstract void UpdatePrice();
    protected abstract bool CanUpgraded();
    public abstract void Upgrade();
}

