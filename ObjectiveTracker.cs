using UnityEngine;

public class objectiveTracker : MonoBehaviour
{
    public chaseObjective unit;
    public int target; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToCounter(int count)
    {
        target += count;

        //unit.ChangeTarget(target);
        Debug.Log(target);
    }
}
