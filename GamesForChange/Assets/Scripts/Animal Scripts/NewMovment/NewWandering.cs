using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWandering : MonoBehaviour
{
    //For Deer and pheseants
    public Rigidbody rb;
    public float acc;
    public Vector3 velo;
    public int maxSpeed;
    public float minRange;

    public int halfExt;
    public Transform animalArea;
    public Transform target;


    private void Start()
    {
        target.position = GetNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(rb.position, target.position) < minRange)
        {
            target.position = GetNewTarget();
        }
        else
        {
            velo += (target.position - rb.position).normalized * acc * Time.deltaTime;    
        }
        
        if(velo.magnitude > maxSpeed)
        {
            velo = velo.normalized * maxSpeed;
        }

        rb.position += velo * Time.deltaTime;
    }


    Vector3 GetNewTarget()
    {

        Vector3 newLoc = new Vector3(Random.Range(animalArea.position.x - halfExt,
            animalArea.position.x + halfExt), animalArea.position.y,
            Random.Range(animalArea.position.z - halfExt, animalArea.position.z + halfExt));

        return newLoc;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rb.position, rb.position + velo);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + (target.position - rb.position).normalized * acc);
        
    }
}
