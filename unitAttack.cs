using UnityEngine;

public class unitAttack : MonoBehaviour
{
    //public chaseObjective chasescript;
    public Collider attackSensor;
    public float attackPoints;
    public float timeMax;
    private float attackTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTime = timeMax;
    }

    private void OnTriggerEnter(Collider attackSensor)
    {
        towerScript tower;

        if (attackSensor.gameObject.tag == "PlayerObj") 
        {
            tower = attackSensor.gameObject.GetComponent<towerScript>();
            Debug.Log("I'm attacking!");
        }
        
    }

    private void OnTriggerStay(Collider attackSensor)
    {
        towerScript tower;

        if(attackSensor.gameObject.tag == "PlayerObj")
        {
            tower = attackSensor.gameObject.GetComponent<towerScript>();
            //Debug.Log("Still attacking!");
            if (attackTime >= 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                tower.CauseDamage(attackPoints);
                //Debug.Log("Pew Pew!!!");
                attackTime = timeMax;
            }
        }

        
    }

    private void OnTriggerExit(Collider attackSensor)
    {
        //canAttack = false;
    }
}
