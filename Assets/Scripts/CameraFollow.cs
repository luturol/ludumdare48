using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float offset;

    private float initialOffset;
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
        position.y = player.transform.position.y - offset;
        transform.position = position;
    }

    public void ClearOffset()
    {
        offset = 0;
    }
}