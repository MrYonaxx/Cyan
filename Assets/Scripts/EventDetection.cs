using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDetection : MonoBehaviour
{

    [SerializeField]
    UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            unityEvent.Invoke();
        }
    }


}
