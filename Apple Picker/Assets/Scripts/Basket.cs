using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")] public TextMeshProUGUI scoreGT;
    private Camera _mainCamera;

    private void Awake()
    {
        // 缓存主相机的引用
        _mainCamera = Camera.main;
        // ReSharper disable once InvertIf
        if (_mainCamera == null)
        {
            Debug.LogError("Main camera not found");
            enabled = false; // 禁用此脚本，防止后续的Update调用
            return;
        }
    }

    private void Start()
    {
        var scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }

    private void Update()
    {
        Vector3 mousePos2D = Mouse.current.position.ReadValue();
        mousePos2D.z = -_mainCamera.transform.position.z;
        var mousePos3D = _mainCamera.ScreenToWorldPoint(mousePos2D);
        var pos = this.transform.position;
        pos.x = mousePos3D.x;
        // ReSharper disable once Unity.InefficientPropertyAccess
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision other)
    {
        var collideWith = other.gameObject;
        // ReSharper disable once InvertIf
        if (collideWith.CompareTag("Apple"))
        {
            Destroy(collideWith);
            var score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
