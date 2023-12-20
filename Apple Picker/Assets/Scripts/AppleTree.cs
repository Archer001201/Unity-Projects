using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject applePrefab;
    public List<LevelSetting> levels;
    public float leftAndRightEdge = 10f;
    public int levelIndex;

    private float _speed;
    private float _chanceToChangeDirections;
    private float _secondsBetweenAppleDrops;
    private TextMeshProUGUI _scoreCounterText;
    
    private void Awake()
    {
        // ReSharper disable once InvertIf
        if (levels.Count <= 0)
        {
            enabled = false;
            return;
        }
        
        UpdateDifficulty();
    }

    private void Start()
    {
        _scoreCounterText = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
        Invoke(nameof(DropApple), 2f);
    }

    private void Update()
    {
        if (int.Parse(_scoreCounterText.text) / 1000 > levelIndex)
        {
            levelIndex = int.Parse(_scoreCounterText.text) / 1000;
            UpdateDifficulty();
        }

        var pos = transform.position;
        pos.x += _speed * Time.deltaTime;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.position = pos;

        if (pos.x > leftAndRightEdge) _speed = -Mathf.Abs(_speed);
        else if (pos.x < -leftAndRightEdge) _speed = Mathf.Abs(_speed);
    }

    private void FixedUpdate()
    {
        if (Random.value < _chanceToChangeDirections) _speed *= -1;
    }

    private void DropApple()
    {
        var apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), _secondsBetweenAppleDrops);
    }

    private void UpdateDifficulty()
    {
        if (levelIndex >= levels.Count) return;
        var level = levels[levelIndex];
        _speed = level.speed;
        _chanceToChangeDirections = level.chanceToChangeDirections;
        _secondsBetweenAppleDrops = level.secondsBetweenAppleDrops;
    }
}
