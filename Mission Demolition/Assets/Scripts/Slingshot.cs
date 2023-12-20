using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;
    
    [Header("Set Dynamically")] 
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody _projectileRigidbody;
    
    private GameObject _launchPoint;
    private Camera _mainCamera;
    private float _maxMagnitude;

    private void Awake()
    {
        var launchPointTrans = transform.Find("LaunchPoint");
        _launchPoint = launchPointTrans.gameObject;
        _launchPoint.SetActive(false);
        _mainCamera = Camera.main;
        _maxMagnitude = GetComponent<SphereCollider>().radius;

        launchPos = launchPointTrans.position;
    }

    private void Update()
    {
        if (!aimingMode) return;

        //获得鼠标在窗口中的坐标
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -(_mainCamera.transform.position.z);
        var mousePos3D = _mainCamera.ScreenToWorldPoint(mousePos2D);

        //计算鼠标和launchPos亮点之间的坐标差
        var mouseDelta = mousePos3D - launchPos;
        //将mouseDelta的坐标限制在弹弓的球状碰撞器的半径范围内
        if (mouseDelta.magnitude > _maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= _maxMagnitude;
        }
        //更新弹珠的位置
        var projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        // ReSharper disable once InvertIf
        if (Input.GetMouseButtonUp(0))
        {
            //如果松开鼠标左键，发射弹珠
            aimingMode = false;
            _projectileRigidbody.isKinematic = false;
            _projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }

    private void OnMouseEnter()
    {
        //激活halo
        _launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        //关闭halo
        _launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        //当鼠标悬浮在弹弓上且按下了鼠标左键的时候进入瞄准模式
        aimingMode = true;
        //实例化弹珠
        projectile = Instantiate(prefabProjectile);
        //设置弹珠的初始化位置于launchPos
        projectile.transform.position = launchPos;
        //设置当前的isKinematic属性，当isKinematic的时候刚体会无视物理影响
        _projectileRigidbody = projectile.GetComponent<Rigidbody>();
        _projectileRigidbody.isKinematic = true;
    }
}
