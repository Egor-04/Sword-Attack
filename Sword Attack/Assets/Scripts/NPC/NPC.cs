using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, IDamagable
{
    [SerializeField] private int _healthPoints = 100;
    [SerializeField] private TMP_Text _textHealth;
    private const int _maxHP = 100;

    public void TakeDamage(int damageValue)
    {
        _healthPoints -= damageValue;
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHP);
        UpdateValue();
    }

    private void UpdateValue()
    {
        _textHealth.text = _healthPoints.ToString();
    }
}
