using UnityEngine;

public class InputSettings : MonoBehaviour
{
    public static InputSettings Instance;
    [field: SerializeField] public KeyCode AttackButton { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}