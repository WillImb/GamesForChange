using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISnake : MonoBehaviour
{
    NavMeshAgent m_Agent;
    

    public float xExtent;
    public float zExtent;

    
    public Transform animalArea;

    
    

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        
    }
        // Update is called once per frame
    void Update()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, Vector3.down, out rayHit, 100f))
        {
           
            Vector3 up = rayHit.normal;
            Vector3 right = GetComponent<Animal>().head.right;
            Vector3 forward = Vector3.Cross(right, up);

           
            transform.rotation = Quaternion.LookRotation(forward, up);
        }

        if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                return;

            m_Agent.destination = GetNewDest();
        
        
    }


    Vector3 GetNewDest()
    {
        Vector3 newPos = new Vector3(Random.Range(animalArea.position.x - xExtent, animalArea.position.x + xExtent), animalArea.position.y, 
            Random.Range(animalArea.position.z - zExtent, animalArea.position.z + zExtent));

        RaycastHit rayHit;
        if (Physics.Raycast(newPos, Vector3.down, out rayHit, 100f))
        {
            newPos = rayHit.point;
            
        }

        NavMeshHit hit;
        
        if(!NavMesh.SamplePosition(newPos, out hit, .6f, NavMesh.AllAreas))
        {
            Debug.Log("There is no Place at " + newPos);
            return transform.position;
            
        }

        return newPos;
    }

    
}
