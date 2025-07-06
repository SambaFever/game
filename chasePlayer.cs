using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public void KillEnemy()
    {
        //Debug.Log("I'm dying!!!");
        Destroy(gameObject);
    }
}
