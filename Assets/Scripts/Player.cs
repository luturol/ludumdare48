using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform restartPosition;

    [Header("Gravity Scale")]
    [SerializeField] private float increseGravityIn = 3f;
    [SerializeField] private float decreseGravityIn = 1.5f;

    [Header("Events")]
    [SerializeField] private UnityEvent restartEvents = new UnityEvent();

    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rigidbody;
    private bool canStopImpulse = false;
    private float initialMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initialMoveSpeed = moveSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        restartEvents.AddListener(RestartPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");

        var verticalAxis = Input.GetAxis("Vertical");

        if (verticalAxis < 0)
        {
            movement.y = -1;

            if (!canStopImpulse)
            {                
                moveSpeed += increseGravityIn;
            }

            canStopImpulse = true;
        }

        if (canStopImpulse && verticalAxis == 0)
        {            
            moveSpeed -= decreseGravityIn;
            canStopImpulse = false;
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            restartEvents?.Invoke();            
        }

    }

    private void RestartPlayer()
    {
        moveSpeed = initialMoveSpeed;
        transform.position = restartPosition.position;
    }

}
