using UnityEngine;

public class Fleer : Agent
{
    // Fields for Fleerer
    public GameObject target;
    public bool isFleeing = false;
    [SerializeField, Range(0, 1)] float fleeScalar;
    [SerializeField, Range(0, 1)] float boundsStrength = 1f;

    // Calculate the steering force
    protected override Vector3 CalcSteering()
    {
        if (isFleeing)
        {
            return Flee(target) * fleeScalar +
                StayInBoundsForce() * boundsStrength;
        }
        return Vector3.zero;
    }

}