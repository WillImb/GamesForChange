using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFalcon : MonoBehaviour
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

         if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                return;

            m_Agent.destination = GetNewDest();
        
        
    }


    Vector3 GetNewDest()
    {
        Vector3 newPos = new Vector3(Random.Range(animalArea.position.x - xExtent, animalArea.position.x + xExtent), animalArea.position.y, 
            Random.Range(animalArea.position.z - zExtent, animalArea.position.z + zExtent));

        NavMeshHit hit;
        
        if(!NavMesh.SamplePosition(newPos, out hit, .6f, NavMesh.AllAreas))
        {
            Debug.Log("There is no Place at " + newPos);
            return transform.position;
            
        }

        return newPos;
    }

    
}
