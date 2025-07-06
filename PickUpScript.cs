using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    //Set held object to transform location
    public Transform itemPos;
    //Set if able to throw object
    private bool itemHeld = false;

    private void Start()
    {
        //script.SetParent();
    }

    private void OnTriggerStay(Collider itemCollider)
    {
        if (itemCollider.CompareTag("itemPickup"))
        {
            Debug.Log("You can pick this up");
            if (Input.GetKey(KeyCode.E))
            {
                if (itemHeld == false)
                {
                    //Parent the gameobject in collision with box collider
                    itemCollider.transform.SetParent(itemPos);
                    itemCollider.transform.SetParent(itemPos, false);

                    itemCollider.attachedRigidbody.isKinematic = true;
                    itemCollider.transform.position = itemPos.position;
                    itemCollider.transform.rotation = itemPos.rotation;

                    itemHeld = false;
                }
                /*else
                {
                    itemCollider.transform.parent = null;

                    itemHeld = false;
                }*/
            }
                
        }
    }
}
