using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerItemCollect : MonoBehaviour
{
    public void itemCollect () {
        Destroy(gameObject);
        Debug.Log("Picking up " + gameObject);
    }
}
