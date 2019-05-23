using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject boardManager;
    public GameObject player;
    GameObject foodText;
    GameObject levelImage;
    Text levelText;

    private void Awake()
    {
        if (GameController.Instance == null)
            GameController.Instance = this;
        if (this != GameController.Instance)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foodText = GameObject.Find("FoodText");
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
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
