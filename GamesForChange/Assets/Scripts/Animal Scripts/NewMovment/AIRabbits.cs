using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRabbits : MonoBehaviour
{
    NavMeshAgent m_Agent;


    public float xExtent;
    public float zExtent;


    public Transform animalArea;

    bool isWandering;
    public bool isFleeing;

    public int wanderSpeed;
    public int fleeSpeed;

    public Transform player;
    public int fleeDist;
    public Transform hole;

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
            m_Agent.destination = hole.position;

            if (Vector3.Distance(transform.position, hole.position) < 1f)
            { 
                hole.gameObject.GetComponent<RabbitHole>().AddRabbit();
                Destroy(gameObject);
            }
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

        

        int secs = Random.Range(5, 10);
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
