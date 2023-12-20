using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    private void Start()
    {
        basketList = new List<GameObject>();
        for (var i = 0; i < numBaskets; i++)
        {
            var tBasketGO = Instantiate(basketPrefab) as GameObject;
            var pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        var tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        var basketIndex = basketList.Count - 1;
        var tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0) SceneManager.LoadScene("GameOver");
    }
}
