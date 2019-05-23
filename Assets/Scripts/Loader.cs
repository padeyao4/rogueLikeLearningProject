using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    void Start()
    {
        if (GameController.Instance == null)
            Instantiate(gameManager);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
