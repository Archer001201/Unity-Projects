using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;


    private void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }

    private void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.position = pos;

        if (pos.x > leftAndRightEdge) speed = -Mathf.Abs(speed);
        else if (pos.x < -leftAndRightEdge) speed = Mathf.Abs(speed);
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections) speed *= -1;
    }

    private void DropApple()
    {
        var apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), secondsBetweenAppleDrops);
    }
}
