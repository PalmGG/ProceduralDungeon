using UnityEditor;
using UnityEngine;

public class Grid //https://youtu.be/waEsGu--9P8
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = WorldText.CreateWorldText("nan", x + ", " + y, null, GetWorldPosition(x, y) + new Vector3(cellSize, 0, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }

        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            string platform = "";
            Color clr = Color.white;
            switch (value)
            {
                case 1:
                    platform = "Start";
                    clr = Color.green;
                    break;
                case 2:
                    platform = "Goal";
                    clr = Color.red;
                    break;
                case 3:
                    platform = "Platform";
                    clr = Color.blue;
                    break;
            }
            //Remove if
            if (debugTextArray[x, y].tag != "Start" && debugTextArray[x, y].tag != "Goal")
            {
                debugTextArray[x, y].tag = platform;
                debugTextArray[x, y].text = platform;
                debugTextArray[x, y].color = clr;

            }

        }

    }
    
    /*public void DBug()
    {
        GameObject go;
        TextMesh tm;
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(gridArray[x, y]);
                switch (gridArray[x, y])
                {
                    //debugTextArray[x, y]
                    case 0:
                        break;
                    case 1:
                        go = GameObject.FindGameObjectWithTag("Start");
                        tm = go.GetComponent<TextMesh>();
                        Destroy(tm);
                        break;
                    case 2:
                        go = GameObject.FindGameObjectWithTag("Goal");
                        break;
                    case 3:
                        go = GameObject.FindGameObjectWithTag("Platform");
                        break;
                }
            }
        }
    }*/
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return -1;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
