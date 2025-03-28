using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    private Dgvt create;
    public int width;
    public int height;
    public float cellSize;
    public Vector3 originPosition;
    public GameObject[] prefab;

    private void Awake()
    {
        create = new Dgvt(width, height, cellSize, originPosition, prefab);
    }
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            GameObject[] platform = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject obj in platform)
            {
                DestroyImmediate(obj);
            }

            DestroyImmediate(GameObject.FindGameObjectWithTag("Start"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("Boss"));
            DestroyImmediate(GameObject.FindGameObjectWithTag("Player"));
            create = new Dgvt(width, height, cellSize, originPosition, prefab);
        }
    }
}

public class Dgvt : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private int[,] gaCopy;
    private GameObject[] prefab;


    public Dgvt(int width, int height, float cellSize, Vector3 originPosition, GameObject[] prefab)
    {
        this.width = width; //Antal rutor på bredden
        this.height = height; //Antal rutor på höjden
        this.cellSize = cellSize; //Rutornas storlek
        this.originPosition = originPosition; //Utgångspunkten för dungeon
        this.prefab = prefab; //Alla rum som ska instantieras
        gridArray = new int[width, height]; //Rutnät som innehåller nummer
        
        int layerMask = ~LayerMask.GetMask("Player");
        int selected = 0;
        int lx; //Förra x-värdet     (room 2 steps back)
        int ly; //Förra y-värdet 
        int x; //Nuvarande x-värdet    (room previously created)
        int y; //Nuvarande y-värdet 
        int nx; //Nya x-värdet      (room about to be created)
        int ny; //Nya y-värdet
        int rotation; //Rotationen för rummet som instantieras

        #region Camera position
        Camera.main.transform.position = new Vector3(width * cellSize / 2, 150, height * cellSize / 2);
        #endregion

        #region Startroom
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            x = 0;
            y = Random.Range(0, gridArray.GetLength(1));
            rotation = 0;
        }
        else
        {
            y = 0;
            x = Random.Range(0, gridArray.GetLength(0));
            rotation = -90;
        }
        selected++;
        Debug.Log("Startroom has been selected: " + x + "," + y);
        Debug.Log("Selected: " + selected);
        gridArray[x, y] = 1;
        GameObject start = Instantiate(prefab[0], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0)); 
        start.tag = "Start";
        start.name = "Start";
        start.layer = 3;
        lx = x;
        ly = y;
        #endregion

        #region First room creation
        if (rotation == 0)
        {
            x++;
        }
        else
        {
            y++;
        }
        GameObject first = Instantiate(prefab[Random.Range(5, prefab.Length)], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0));
        first.tag = "Platform";
        first.name = "Last";
        first.layer = 3;
        gridArray[x, y] = 1;

        float connectx = 0;
        float connecty = 0;
        switch (ly - y)
        {
            case -1: connecty = ly + 0.5f; break;
            case 0: connecty = ly; break;
            case 1: connecty = y + 0.5f; break;
        }
        switch (lx - x)
        {
            case -1: connectx = lx + 0.5f; break;
            case 0: connectx = lx; break;
            case 1: connectx = x + 0.5f; break;
        }

        

        #endregion
        //Add new corner rule, if corner chance of 2x2 room, check if space is availible
        #region RestOfTheRooms
        GameObject go;
        int rooms = 0;
        //bool twobytwo = false;

        go = Instantiate(prefab[4], new Vector3(connectx * cellSize, 0, connecty * cellSize), Quaternion.Euler(0, rotation + 90, 0));

        while (true)
        {
            Debug.Log("Last coordinates: " + x + "," + y);
            int iterate = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    nx = x + i;
                    ny = y + j;
                    if (nx != x && ny != y) continue;
                    if (nx >= 0 && nx < gridArray.GetLength(0) && ny >= 0 && ny < gridArray.GetLength(1))
                    {
                        if (gridArray[nx, ny] == 0)
                        {
                            gridArray[nx, ny] = 2;
                            iterate++;
                            Debug.Log($"Availible Neighbor at ({nx}, {ny}):");
                        }
                        else
                        {
                            //Debug.Log($"Occupied Neighbor at ({nx}, {ny}):");
                        }


                    }
                }
            }
            if (iterate == 0 || rooms == width * height / 2)
            {
                go = GameObject.Find("Last");
                DestroyImmediate(go);
                Debug.Log(x * cellSize + " | " + y * cellSize);
                if (lx - x == 0)
                {
                    switch (ly - y)
                    {
                        case -1: rotation = 0; break;
                        case 1: rotation = 180; break;
                    }
                }
                else if (ly - y == 0)
                {
                    switch (lx - x)
                    {
                        case -1: rotation = 90; break;
                        case 1: rotation = 270; break;
                    }
                }
                GameObject boss = Instantiate(prefab[1], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0));
                boss.tag = "Boss";
                boss.name = "Boss";
                boss.layer = 3;
                GameObject player = Instantiate(prefab[3], new Vector3(start.transform.position.x, 5, start.transform.position.z), Quaternion.Euler(0, 0, 0));
                break;

            }
            random = Random.Range(0, iterate);
            Debug.Log("Options:" + iterate);
            Debug.Log("Random:" + random);
            for (int i = 0; i <= iterate + 1; i++)
            {
                Debug.Log("Loop start: " + iterate);
                int check = 0;
                for (int a = 0; a < gridArray.GetLength(0); a++)
                {
                    for (int b = 0; b < gridArray.GetLength(1); b++)
                    {
                        if (gridArray[a, b] == 2 && check == 0 && i == random)
                        {
                            gridArray[a, b] = 3;
                            iterate--;
                            check++;
                            rooms++;
                            Debug.Log("Placed");
                        }
                        else if (gridArray[a, b] == 2 && check == 0 && i != random)
                        {
                            gridArray[a, b] = 0;
                            iterate--;
                            check++;
                        }

                    }
                }

            }
            for (int a = 0; a < gridArray.GetLength(0); a++)
            {
                for (int b = 0; b < gridArray.GetLength(1); b++)
                {
                    if (gridArray[a, b] == 3)
                    {
                        if (lx != a && ly != b)
                        {
                            //Debug variables
                            int cx = lx - x;
                            int cy = ly - y;
                            int dx = lx - a;
                            int dy = ly - b;
                            if (dx == -1 && dy == -1 && cx == 0) // Moving top-right
                            {
                                rotation = 270;
                            }
                            else if (dx == -1 && dy == 1 && cx == 0) // Moving bottom-right
                            {
                                rotation = 180;
                            }
                            else if (dx == 1 && dy == -1 && cx == 0) // Moving top-left
                            {
                                rotation = 0;
                            }
                            else if (dx == 1 && dy == 1 && cx == 0) // Moving bottom-left
                            {
                                rotation = 90;
                            }
                            if (dx == -1 && dy == -1 && cy == 0) // Moving top-right
                            {
                                rotation = 90;
                            }
                            else if (dx == -1 && dy == 1 && cy == 0) // Moving bottom-right
                            {
                                rotation = 0;
                            }
                            else if (dx == 1 && dy == -1 && cy == 0) // Moving top-left
                            {
                                rotation = 180;
                            }
                            else if (dx == 1 && dy == 1 && cy == 0) // Moving bottom-left
                            {
                                rotation = 270;
                            }

                            Debug.Log("Last: " + lx + "," + ly + "Current: " + x + "," + y + "New: " + a + "," + b + "Cx: " + cx + "Cy" + cy + "Difference: " + dx + "," + dy);
                            go = GameObject.Find("Last");
                            DestroyImmediate(go);
                            go = Instantiate(prefab[2], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0));
                            go.tag = "Platform";
                            go.name = "Last";
                            go.layer = 3;
                        }

                        lx = x;
                        ly = y;
                        x = a;
                        y = b;
                        if (lx != x)
                        {
                            rotation = 0;
                        }
                        else { rotation = 90; }

                        switch (ly - y)
                        {
                            case -1: connecty = ly + 0.5f; break;
                            case 0: connecty = ly; break;
                            case 1: connecty = y + 0.5f; break;
                        }
                        switch (lx - x)
                        {
                            case -1: connectx = lx + 0.5f; break;
                            case 0: connectx = lx; break;
                            case 1: connectx = x + 0.5f; break;
                        }

                        go = Instantiate(prefab[4], new Vector3(connectx * cellSize, 0, connecty * cellSize), Quaternion.Euler(0, rotation + 90, 0));

                        //if (rooms != 3)
                        //{
                        go = GameObject.Find("Last");
                        go.name = "Room: " + rooms;
                        //}

                        go = Instantiate(prefab[Random.Range(5, prefab.Length)], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0));
                        go.tag = "Platform";
                        go.name = "Last";
                        go.layer = 3;
                        gridArray[x, y] = 1;
                    }
                }
            }
        }



        //check how many available coordinates around platform
        #endregion
    }
}