using UnityEngine;
using UnityEngine.UI;

public class IngamePanel : MonoBehaviour
{
    [Header("Вооружение")]
    [SerializeField] private Armament _armament;
    [SerializeField] private Text _gunEnergyIndicator;

    [Space]
    [Header("Скорость")]
    [SerializeField] private ShipEngine _shipEngine;
    [SerializeField] private Slider _speedController;

    [Space]
    [Header("Космическая станция")]
    [SerializeField] private SpaceStation _spaceStation;
    [SerializeField] private Image _healthBar; // TODO: Сделать через слайдер
    [SerializeField] private Text _healthText;

    [Space]
    [Header("Очки")]
    [SerializeField] private Scores _scores;
    [SerializeField] private Text _scoresText;

    private void Start()
    {
        SetStartsliderValue();
    }

    private void OnEnable()
    {
        _armament.EnergyChanged += UpdateGunEnergyUI;
        _speedController.onValueChanged.AddListener(_shipEngine.OnSpeedChanged);
        _spaceStation.HealthChanged += UpdateSpaceStationUI;
        _scores.ValueChanged += UpdateScoresUI;
    }

    private void OnDisable()
    {
        _armament.EnergyChanged -= UpdateGunEnergyUI;
        _speedController.onValueChanged.RemoveListener(_shipEngine.OnSpeedChanged);
        _spaceStation.HealthChanged -= UpdateSpaceStationUI;
        _scores.ValueChanged -= UpdateScoresUI;
    }

    public void UpdateGunEnergyUI(int current, int max)
    {
        _gunEnergyIndicator.text = $"{current}/{max}";
    }

    public void UpdateSpaceStationUI(float current, float max)
    {
        _healthBar.fillAmount = current / max;        
        _healthText.text = $"{Mathf.Round(current / max * 100)}%";        
    }

    public void UpdateScoresUI(int scores)
    {
        _scoresText.text = $"Score: {scores}";
    }

    private void SetStartsliderValue()
    {
        _speedController.value = _shipEngine.Speed / _shipEngine.MaxSpeed;
    }
}