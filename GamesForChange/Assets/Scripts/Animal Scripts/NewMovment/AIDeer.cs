using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDeer : MonoBehaviour
{
    NavMeshAgent m_Agent;
    

    public float xExtent;
    public float zExtent;

    
    public Transform animalArea;

    public int eatTime;
    public int wanderSpeed;
    public int fleeSpeed;


    bool isWandering;

    
    bool isFleeing;
    public int fleeDist;

    public Transform[] fleePoints;
    public Transform player;
    

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        
        isWandering = true;
        m_Agent.destination = GetNewDest();
    }
        // Update is called once per frame
    void Update()
    {
        if (isFleeing)
        {
            if (Vector3.Distance(player.position, transform.position) > fleeDist)
            {
                isFleeing = false;
                m_Agent.destination = GetNewDest();
                isWandering = true;
                return;
            }

                int farthest = 0;
            for (int i = 0; i < fleePoints.Length; i++)
            {
                if(Vector3.Distance(player.position, fleePoints[i].position) > Vector3.Distance(player.position, fleePoints[farthest].position))
                {
                    farthest = i;
                }
            }
            m_Agent.destination = fleePoints[farthest].position;
        }
        else
        {
            if (Vector3.Distance(player.position, transform.position) < fleeDist)
            {
                isFleeing = true;
                return;
            }
           
               
            
            if (isWandering)
            {

                if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                    return;

                StartCoroutine(EatCoroutine());
            }
        }

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

    IEnumerator EatCoroutine()
    {
        isWandering = false;
        
        int secs = Random.Range(5, 15);
        yield return new WaitForSeconds(secs);

        if (Vector3.Distance(player.position, transform.position) < fleeDist)
        {
            isFleeing = true;
            yield break;
        }

        isWandering = true;

        m_Agent.destination = GetNewDest();
    }
}
