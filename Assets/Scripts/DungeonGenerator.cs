using UnityEngine;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour
{
    private WillTheRealDungeonGeneratorPleaseStandUp dg;
    public int width;
    public int height;
    public float cellSize;
    public Vector3 originPosition;
    public GameObject[] prefab;

    private void Awake()
    {
        dg = new WillTheRealDungeonGeneratorPleaseStandUp(width, height, cellSize, originPosition, prefab);
    }
}

public class WillTheRealDungeonGeneratorPleaseStandUp : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private GameObject[] prefab;
    GameObject pf;
    public WillTheRealDungeonGeneratorPleaseStandUp(int width, int height, float cellSize, Vector3 originPosition, GameObject[] prefab)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.prefab = prefab;
        gridArray = new int[width, height];
        

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                pf = prefab[Random.Range(0,prefab.Length)];
                Debug.Log(gridArray[x, y]);
                Instantiate(pf, new Vector3(x * 300, 0, y * 300),Quaternion.identity);
            }

        }
    }
}