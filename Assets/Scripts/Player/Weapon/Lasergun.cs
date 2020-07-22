using System;
using System.Collections;
using UnityEngine;

public class Lasergun : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private AudioClip _shotAudio;
    [SerializeField] private Gun[] _guns;
    [SerializeField] private float _fireRate = 0.2f;
    [SerializeField] private float _restoringRate = 0.5f;
    [SerializeField] private float _restoringDelay = 1.0f;    
    [SerializeField] private int _maxEnergy = 15;
    private int _currentEnergy;
    private int _gunIndex;
    private Coroutine _shooting;
    private Coroutine _restoring;
    public event Action<int, int> EnergyChanged;

    public bool CanShoot => _currentEnergy > 0;
    public bool IsEnergyFull => _currentEnergy == _maxEnergy;

    private void Start()
    {
        _currentEnergy = _maxEnergy;
        StartRestore();
        EnergyChanged?.Invoke(_currentEnergy, _maxEnergy);
    }

    public void StartShooting()
    {
        _shooting = StartCoroutine(Shooting());
        StopRestore();
    }

    public void StopShooting()
    {
        StopCoroutine(_shooting);
        StartRestore();        
    }

    private IEnumerator Shooting()
    {
        while (CanShoot)
        {
            _guns[_gunIndex].Shoot(_shotPrefab, _shotAudio);
            _currentEnergy--;
            IncreaseCanonIndex();
            EnergyChanged?.Invoke(_currentEnergy, _maxEnergy);

            yield return new WaitForSeconds(_fireRate);
        }
    }

    private void IncreaseCanonIndex()
    {
        _gunIndex++;
        if (_gunIndex >= _guns.Length)
        {
            _gunIndex = 0;
        }
    }
        
    private void StartRestore()
    {
        _restoring = StartCoroutine(Restoring());
    }

    private void StopRestore()
    {
        StopCoroutine(_restoring);     
    }

    private IEnumerator Restoring()
    {        
        yield return new WaitForSeconds(_restoringDelay);

        while (_currentEnergy < _maxEnergy)
        {
            _currentEnergy++;
            EnergyChanged?.Invoke(_currentEnergy, _maxEnergy);
            yield return new WaitForSeconds(_restoringRate);
        }        
    }
}