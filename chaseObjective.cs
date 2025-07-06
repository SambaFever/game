using UnityEngine;
using UnityEngine.AI;

public class chaseObjective : MonoBehaviour
{
    GameObject obj;
    NavMeshAgent agent;
    public int targetSelect;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        int targetId = targetSelect;

        switch (targetId)
        {
            case 0:
                //Debug.Log("Tower (1)");
                obj = GameObject.Find("First Tower");
                break;
            case 1:
                Debug.Log("Tower");
                obj = GameObject.Find("Second Tower");
                break;
            case 2:
                //Debug.Log("EnemyBase");
                obj = GameObject.Find("EnemyBase");
                break;
            default:
                //obj = GameObject.Find("Player");
                break;
        }

        agent.SetDestination(obj.transform.position);
    }
}
