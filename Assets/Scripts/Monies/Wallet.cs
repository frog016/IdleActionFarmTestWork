using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Wallet", fileName = "Wallet")]
public class Wallet : ScriptableObject
{
    [SerializeField] private int _balance;

    public int Balance { get => _balance; set => _balance = value; }
    public event Action<int> BalanceChanged;

    public void AddMoney(int value)
    {
        if (value < 0)
            throw new ArgumentException($"Value ({value}) can't be negative.");

        Balance += value;
        BalanceChanged?.Invoke(Balance);
    }
}
