using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject[] dots;

    private BackgroundTile[,] allTiles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        SetUp();
    }
    public void destroyed()
    {
        //  dot = null;
        Debug.Log("hi");
    }
    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(dots[Random.Range(0, 7)], tempPosition, Quaternion.identity) as GameObject;
                //  backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";
            }
        }
    }
}
