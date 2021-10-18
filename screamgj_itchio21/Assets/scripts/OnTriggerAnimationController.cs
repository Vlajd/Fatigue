using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimationController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake() {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation() {
        if (!doorOpen) {
            doorAnim.Play("DoorOpen", 0, 0f);
            Debug.Log("Opening " + gameObject);
            doorOpen = true;
        }
        else {
            doorAnim.Play("DoorClose", 0, 0f);
            Debug.Log("Closing " + gameObject);
            doorOpen = false;
        }
    }
}
