using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardController : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] outerWallsTiles;
    public GameObject[] floorTiles;
    public GameObject[] enemyTiles;
    public GameObject exitTile;

    private GameObject board;
    private List<Vector3> gridPosition = new List<Vector3>();
    private int level = 10;

    void Start()
    {
        board = new GameObject("Board");
        SetupScene(level);
    }

    void SetupList()
    {
        gridPosition.Clear();
        for (int i = 1; i < width-1; i++)
        {
            for (int j = 1; j < height-1; j++)
            {
                gridPosition.Add(new Vector3(i, j, 0f));
            }
        }
        gridPosition.RemoveAt(0);
        gridPosition.RemoveAt(gridPosition.Count-1);
    }

   
    void SetupBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject tilePre = floorTiles[Random.Range(0,floorTiles.Length)];
                if(i==0 || i== width-1 || j==0 ||j==height-1)
                {
                    tilePre = outerWallsTiles[Random.Range(0, outerWallsTiles.Length)];
                }
                Instantiate(tilePre, new Vector3(i, j, 0f), Quaternion.identity, board.transform);
            }
        }
        Instantiate(exitTile, new Vector3(width - 2, height - 2, 0),Quaternion.identity);
    }


    void SetupScene(int level)
    {
        SetupList();
        SetupBoard();
        ObjectAtRandom(foodTiles,Random.Range(0,level));
        ObjectAtRandom(wallTiles, Random.Range(0, level));
        ObjectAtRandom(enemyTiles, Random.Range(0, level));
    }

    private void ObjectAtRandom(GameObject[] gameObjects, int v)
    {
        for (int i = 0; i < v; i++)
        {
            GameObject prefab = gameObjects[Random.Range(0, gameObjects.Length)];
            Instantiate(prefab, RandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 RandomPosition()
    {
        int index = Random.Range(0, gridPosition.Count);
        Vector3 pos = gridPosition[index];
        gridPosition.RemoveAt(index);
        return pos;
    }
}
