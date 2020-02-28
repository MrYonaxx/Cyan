using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDetection : MonoBehaviour
{
    [SerializeField]
    string tagName = "Player";
    [SerializeField]
    UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName)
        {
            unityEvent.Invoke();
        }
    }


}
