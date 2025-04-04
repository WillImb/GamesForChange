using UnityEngine;

public class Wander : Agent
{
    // Fields for wander behavior
    public bool isWandering;
    [SerializeField] private float wanderRadius = 5f;
    [SerializeField] private float wanderDistance = 5f;
    [SerializeField] private float wanderJitter = 5f;

    private Vector3 wanderTarget;  // The current target position for wandering

    // Calculate the steering force for wandering
    protected override Vector3 CalcSteering()
    {
        if (isWandering)
        {
            return Wander(this.gameObject, wanderRadius, wanderDistance, wanderJitter);
        }
        return Vector3.zero;
    }
}
