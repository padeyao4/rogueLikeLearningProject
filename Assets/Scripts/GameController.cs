using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject boardManager;
    public GameObject player;
    Text foodText;
    GameObject levelImage;
    Text levelText;

    int playerFood = 100; 
    private void Awake()
    {
        if (GameController.Instance == null)
            GameController.Instance = this;
        if (this != GameController.Instance)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    public void SetFoodText(string content)
    {
        foodText.text = content;
    }

    private void Start()
    {
        levelImage.SetActive(false); 
    }

    void SetLevelImageHide()
    {
        levelImage.SetActive(false);
    }

    void ShowLevel()
    {
        levelImage.SetActive(true);
    }


    void OnSceneLoad()
    {
        
    }

    void Update()
    {
        
    }
}
