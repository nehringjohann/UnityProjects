using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public GameObject interactText;

    private void OnTriggerStay(Collider otherObject)
    {
        if (otherObject.tag == "HitBox")
        {
            interactText.SetActive(true);
            Debug.Log("Entered HitBox...");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Interacted with 'E'...");
            }

        }
    }
    
    private void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.tag == "HitBox")
        {
            interactText.SetActive(false);
            Debug.Log("Left HitBox...");
        }
    }
}
