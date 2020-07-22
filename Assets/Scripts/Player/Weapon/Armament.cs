using System;
using UnityEngine;

public class Armament : MonoBehaviour
{
    [SerializeField] private Lasergun _lasergun;
    private IWeapon _weapon;
    public event Action<int, int> EnergyChanged;

    private void Awake()
    {
        SetLasergun();
    }

    public void StartShooting()
    {
        if (_weapon.CanShoot)
        {
            _weapon.StartShooting();
        }
    }

    public void StopShooting()
    {
        _weapon.StopShooting();
    }

    public void SetLasergun()
    {
        _weapon = _lasergun;
        _weapon.EnergyChanged += EnergyChanged;
    }
}