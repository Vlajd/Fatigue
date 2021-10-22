using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDoorAnimationController : MonoBehaviour
{
    private bool deAniBool = true;
    private Animator doorAnim;
    private bool doorOpen = false;
    public AudioSource[] audio = new AudioSource[2];

    private void Awake () {
        doorAnim = gameObject.GetComponent<Animator>();
    }
    public void aniBoolean () {
        deAniBool = true;
        Debug.Log("Animating Door Done");
    }
    public void PlayAnimation() {
        if (!doorOpen && deAniBool) {
            doorAnim.Play("DoorOpen", 0, 0f);
            audio[0].Play();
            Debug.Log("Opening " + gameObject);
            doorOpen = true;
            deAniBool = false;
        }
        else {
            if (deAniBool) {
                doorAnim.Play("DoorClose", 0, 0f);
                audio[1].Play();
                Debug.Log("Closing " + gameObject);
                doorOpen = false;
                deAniBool = false;
            }
        }
    }
}
