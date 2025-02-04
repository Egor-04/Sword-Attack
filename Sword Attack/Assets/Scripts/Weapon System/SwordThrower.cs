using UnityEngine;

public class SwordThrower : MonoBehaviour
{
    [SerializeField] private Sword _swordPrefab;
    [SerializeField] private SwordScriptableObject _swordPattern;
    private Vector2 _throwDirection;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputSettings.Instance.AttackButton))
        {
            ThrowSword();
        }
    }

    private void ThrowSword()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _throwDirection = (mousePosition - (Vector2)transform.position).normalized;
        _swordPrefab.SetParameters(_swordPattern.SwordSize);
        _swordPrefab.Throw(transform, _throwDirection, _swordPattern);
    }
}