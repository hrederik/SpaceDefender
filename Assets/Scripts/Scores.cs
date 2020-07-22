using System;
using UnityEngine;

public class Scores : MonoBehaviour
{
    [SerializeField] private int _amount;
    public event Action<int> ValueChanged;

    public int Amount => _amount;

    public void Increase(int amount)
    {
        _amount += amount;
        ValueChanged?.Invoke(_amount);
    }
}