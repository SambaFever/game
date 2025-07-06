using Unity.VisualScripting;
using UnityEngine;

public class WeaponAbilities : MonoBehaviour
{
    public Collider attackSensor;
    public Transform gunBarrel;
    public int iCoins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
            Gamble();
        }
    }

    private void OnTriggerEnter(Collider attackSensor)
    {
        EnemyChase enemyScript;

        if(attackSensor.gameObject.tag == "Enemy")
        {
            //Debug.Log("Chicken Jockey!!!");
            enemyScript = attackSensor.gameObject.GetComponent<EnemyChase>();
            enemyScript.KillEnemy();
        }
    }

    private void Shoot()
    {
        EnemyChase enemyScript;

        Ray ray = new Ray(gunBarrel.position, gunBarrel.forward);
        RaycastHit hit;
        float gunRange = 20;

        if (Physics.Raycast(ray, out hit, gunRange))
        {
            gunRange = hit.distance;
            if (hit.collider.gameObject.tag == "Enemy")
            {
                enemyScript = hit.collider.gameObject.GetComponent<EnemyChase>();
                Debug.DrawRay(ray.origin, ray.direction * gunRange, Color.red);
                enemyScript.KillEnemy();
            }
            Debug.DrawRay(ray.origin, ray.direction * gunRange, Color.blue);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * gunRange, Color.green);
        }
    }

    private void Gamble()
    {
        //fCoins create a random float
        float fCoins = Random.Range(111, 999);
        //iCoins turn float into integer
        iCoins = (int)fCoins;
        //Shows iCoins in debug window
        Debug.Log(iCoins);
        //iCoins is sepreated into three seperate integers for the comparison if statement
        int hunCoins = iCoins / 100 % 10;
        int tenCoins = iCoins / 10 % 10;
        int oneCoins = iCoins % 10;

        if (hunCoins == oneCoins && tenCoins == oneCoins)
        {
            Debug.Log("JACKPOT!!!");
        }
    }
}
