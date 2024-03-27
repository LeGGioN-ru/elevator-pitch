using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings/Create", order = 1)]
public class GameSettings : ScriptableObject
{
    [field: SerializeField] public float StartTigerSpeed { get; private set; }
    [field: SerializeField] public float AddClickSpeed { get; private set; }
    [field: SerializeField] public float DurationAddSpeed { get; private set; }
    [field:SerializeField] public int AddMeat {  get; private set; }
    [field:SerializeField] public int AddMoney {  get; private set; }   
    [SerializeField] private List<int> _bankUpgradePrices;
    [SerializeField] private List<int> _tigersUpgradePrices;
    [SerializeField] private List<int> _butcheryUpgradePrices;

    public IReadOnlyList<int> BankUpgradePrices => _bankUpgradePrices;
    public IReadOnlyList<int> TigersUpgradePrices => _tigersUpgradePrices;
    public IReadOnlyList<int> ButcheryUpgradePrices => _butcheryUpgradePrices;
}
