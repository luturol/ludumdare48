using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetPoint : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent collisionEvents;
    [SerializeField] private UnityEvent<Transform> renderEvents;
    
    private void Update()
    {
        renderEvents?.Invoke(transform);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collisionEvents?.Invoke();
        }
    }
}
