using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetPoint : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent collisionEvents;
    [SerializeField] private UnityEvent renderEvents;

    private CameraFollow cameraFollow;

    private void Awake()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    private void Update()
    {
        if (cameraFollow != null && cameraFollow.ObjectIsVisible(transform))
        {
            renderEvents?.Invoke();
        }

    }

    private void OnWillRenderObject()
    {
        //renderEvents?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Finish game logic
            collisionEvents?.Invoke();
        }
    }
}
