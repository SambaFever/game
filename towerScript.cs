using UnityEngine;

public class towerScript : MonoBehaviour
{
    public chaseObjective unit;
    public string towerName;
    float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CauseDamage(float hurt)
    {
        health -= hurt;
        Debug.Log("Ow!");

        if (health <= 0)
        {
            if(towerName == "First Tower")
            {
                Debug.Log("Tower Destroyed!");
                unit.targetSelect += 1;
            }else if (towerName == "Second Tower")
            {
                unit.targetSelect += 1;
            }
            //gameObject.SetActive(false);
        }
    }
}
