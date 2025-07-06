using UnityEngine;

public class pickupItem : MonoBehaviour
{
    public Transform itemPos;
    public float force = 3f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            transform.parent = null;
            ThrowItem();
        }
    }

    public void ThrowItem()
    {
        Vector3 forwardDir = transform.forward;
        rb.isKinematic = false;
        rb.AddForce(forwardDir * force, ForceMode .Impulse);
    }
}
