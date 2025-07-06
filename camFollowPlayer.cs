using UnityEngine;

public class camFollowPlayer : MonoBehaviour
{
    public GameObject playerChar;
    public GameObject enemyChar;

    void Update()
    {
        Vector3 focusPoint = (playerChar.transform.position + enemyChar.transform.position)/2f;
        transform.LookAt(focusPoint);
    }
}
