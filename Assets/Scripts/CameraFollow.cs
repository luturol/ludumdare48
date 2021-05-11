using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float offset;

    public UnityEvent events = new UnityEvent();

    private bool FreezeY = false;

    private Camera camera;
    private float initialOffset;


    private void Awake()
    {
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x;

        if (!FreezeY)
            position.y = player.transform.position.y - offset;

        transform.position = position;
    }


    public void MustFreezeYAxis(Transform objectTransform)
    {
        FreezeY = ObjectIsVisible(objectTransform);
    }
    
    private bool ObjectIsVisible(Transform objectTransform)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(objectTransform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
