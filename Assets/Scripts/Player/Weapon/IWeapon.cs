using System;

interface IWeapon
{
    event Action<int, int> EnergyChanged;
    bool CanShoot { get; }
    void StartShooting();
    void StopShooting();
}