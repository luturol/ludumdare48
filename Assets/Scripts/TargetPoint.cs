using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    [SerializeField] private CameraFollow cameraFollow;

    private void OnWillRenderObject()
    {
        cameraFollow.ClearOffset();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Finish game logic
            events?.Invoke();
        }
    }
}
