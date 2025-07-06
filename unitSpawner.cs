using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class unitSpawner : MonoBehaviour
{
    [SerializeField]GameObject unitPrefab = null;
    private Camera cam;
    public float maxEnergy;
    public float gains;

    private float StaminaRegenTimer = 0.0f;
    private const float StaminaDecreasePerFrame = 1.0f;
    private const float StaminaIncreasePerFrame = 5.0f;
    private const float StaminaTimeToRegen = 3.0f;

    void Update()
    {
        bool isRunning = false;
        if (Input.GetMouseButtonDown(0))
        {
            if (gains >= 10)
            {
                SpawnAtMouse();
                isRunning = true;
            }
        }
        else
        {
            isRunning = false;
        }

        if (isRunning)
        {
            gains -= 10;
            StaminaRegenTimer = 0.0f;
        }
        else if (gains < maxEnergy)
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
                gains = Mathf.Clamp(gains + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, maxEnergy);
            else
                StaminaRegenTimer += Time.deltaTime;
            //Debug.Log(gains);
        }
    }

    void SpawnAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Instantiate(unitPrefab, hit.point, Quaternion.identity);
        }
    }
}
