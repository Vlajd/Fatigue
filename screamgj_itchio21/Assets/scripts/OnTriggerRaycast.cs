using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    private OnTriggerDoorAnimationController doorAnim;
    private OnTriggerItemCollect itemCall;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private Text crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;
    private const string interactableDoorTag = "InteractiveDoor";
    private const string interactableItemTag = "InteractiveItem";


    private void Update () {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) {

            if (hit.collider.CompareTag(interactableDoorTag)) {

                //doors
                if (!doOnce) {
                    doorAnim = hit.collider.gameObject.GetComponent<OnTriggerDoorAnimationController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey)) {
                    doorAnim.PlayAnimation();
                }
            }

            //items
            if (hit.collider.CompareTag(interactableItemTag)) {
                if (!doOnce) {
                    itemCall = hit.collider.gameObject.GetComponent<OnTriggerItemCollect>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey)) {
                    itemCall.itemCollect();
                }
            }
        }

        else {
            if(isCrosshairActive) {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on) {
        if (on && !doOnce) {
            crosshair.color = new Color(0.785f, 0.785f, 0.785f, 0.5f);
        }
        else {
            crosshair.color = new Color(0f, 0f, 0f, 0f);
            isCrosshairActive = false;
        }
    }
}
