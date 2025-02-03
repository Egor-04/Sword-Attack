using UnityEngine;

[CreateAssetMenu(menuName = "SO Tools/TrajectoryPattern", fileName = "SwordTrajectoryPattern")]
public class SwordScriptableObject : ScriptableObject
{
    [field: SerializeField] public float ThrowForce { get; private set; } = 5f;

    [field: SerializeField] public float RotationSpeed { get; private set; } = 1763f;

    [field: SerializeField] public float TrajectoryAngle { get; private set; } = 9.90f;

    [field: SerializeField] public float CatchOffset { get; private set; } = 2f;

    [field: SerializeField] public float ReturnSpeed { get; private set; } = 18f;

    [field: SerializeField] public float ReturnDelay { get; private set; } = 2f;
}
