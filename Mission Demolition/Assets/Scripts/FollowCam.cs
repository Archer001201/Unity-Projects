using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // ReSharper disable once InconsistentNaming
    public static GameObject POI;
    private Camera _camera;

    //相机运动的平滑值
    [Header("Set in Inspector")] public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")] public float camZ;

    private void Awake()
    {
        camZ = transform.position.z;
        _camera = this.gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
        if (POI == null) return;
        
        //将兴趣点设置为终点
        var destination = POI.transform.position;
        //约束终点，使其不得低于特定的最小值
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //线性插值，根据easing的值计算出相机位置和兴趣点之间的一个中间位置，并将这个中间位置赋值给终点
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        //每一帧相机位置都移动到终点位置，easing越小运动越平滑
        transform.position = destination;
        _camera.orthographicSize = destination.y + 10;
    }
}
