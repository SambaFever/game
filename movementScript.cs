using UnityEngine;
using UnityEngine.AI;

public class NPCMoveWithDistance : MonoBehaviour
{
    public GameObject targetObject;   // The target GameObject (e.g., enemy)
    public float desiredDistance = 5f;  // The desired distance the NPC should maintain from the target
    private NavMeshAgent navMeshAgent;  // Reference to the NavMeshAgent component

    void Start()
    {
        // Get the NavMeshAgent component attached to the NPC
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Calculate the desired position based on the target's position and the desired distance
            Vector3 direction = targetObject.transform.position - transform.position;  // Vector pointing from NPC to target
            direction.Normalize();  // Normalize the direction to only use it for offsetting position

            // Calculate the position at the desired distance from the target
            Vector3 offsetPosition = targetObject.transform.position - direction * desiredDistance;

            // Move the NPC to the offset position
            navMeshAgent.SetDestination(offsetPosition);
        }
    }

    // This method is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the NPC is colliding with a specific object (e.g., enemy)
        if (other.CompareTag("Enemy"))
        {
            // Perform actions when the NPC enters the trigger zone with an enemy
            Debug.Log("NPC entered the trigger zone of the enemy!");
            // Example action: Stop moving or perform another action
            navMeshAgent.isStopped = true;  // This will stop the NPC from moving
        }
    }

    // Optional: This method can handle when another collider exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Example: Resume movement when the enemy leaves the trigger zone
            Debug.Log("NPC exited the trigger zone of the enemy!");
            navMeshAgent.isStopped = false;  // Resume movement if desired
        }
    }
}
