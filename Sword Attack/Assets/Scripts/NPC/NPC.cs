using TMPro;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] private int _healthPoints = 100;
    [SerializeField] private TMP_Text _textHealth;

    public virtual void GetDamage(int damageValue)
    {
        _healthPoints -= damageValue;
        UpdateValue();
    }

    private void UpdateValue()
    {
        _textHealth.text = _healthPoints.ToString();
    }
}
