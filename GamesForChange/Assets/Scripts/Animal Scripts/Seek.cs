using UnityEngine;

public class Seeker : Agent
{
    // Fields for Seeker
    public GameObject target;
    public bool isSeeking = false;
    [SerializeField, Range(0, 1)] float seekScalar = 1f;
    [SerializeField, Range(0, 1)] float boundsStrength = 1f;

    // Calculate the steering force
    protected override Vector3 CalcSteering()
    {
        if (isSeeking)
        {
            return Seek(target) * seekScalar +
                StayInBoundsForce() * boundsStrength;
        }
        return Vector3.zero;
    }

}