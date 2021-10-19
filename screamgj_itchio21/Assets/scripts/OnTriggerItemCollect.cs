using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerItemCollect : MonoBehaviour
{
    public int itemIndex;
    private PlayerInventory playerInventory;

    private void Start () {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>();
    }

    public void itemCollect () {
        for (int i = 0; i < playerInventory.inventorySlots.Length; i++) {
            if (playerInventory.inventoryBools[i] == false) {
                Destroy(gameObject);
                Debug.Log("Picking up " + gameObject);
                playerInventory.inventoryBools[i] = true;
                break;
            }
        }
    }
}
