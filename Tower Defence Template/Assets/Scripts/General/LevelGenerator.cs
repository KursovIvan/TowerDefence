using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    public GameObject[] cellPrefabs;
    public GameObject cellParent;
    public int cellWidth;
    public int cellHeight;

    private void Awake()
    {
        Instance = this;
    }
    public void createLevel(string levelNumber)
    {
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        string levelLay = LoadLevelLayout(levelNumber);
        for (int i = 0; i < cellHeight; i++)
        {
            for (int k = 0; k < cellWidth; k++)
            {
                createCell(k, i, worldVec, levelLay[i*cellWidth+k] - '0');              
            }
        }
    }
    void createCell(int x, int y, Vector3 wV, int cellType)
    {
        GameObject cellInstance = Instantiate(cellPrefabs[cellType]);
        cellInstance.transform.SetParent(cellParent.transform, false);
        float spriteSizeX = cellInstance.GetComponent<SpriteRenderer>().bounds.size.x;
        float spriteSizeY = cellInstance.GetComponent<SpriteRenderer>().bounds.size.y;
        cellInstance.transform.position = new Vector3(wV.x + (spriteSizeX * x), wV.y + (spriteSizeY * -y), 0);
        cellInstance.GetComponent<CellScript>().orderInLayer = y + 1;
    }
    string LoadLevelLayout(string levelNumber)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("Level" + levelNumber + "Layout");
        string tmpLayout = tmpTxt.text.Replace(Environment.NewLine, string.Empty);
        return tmpLayout;
    }
}
