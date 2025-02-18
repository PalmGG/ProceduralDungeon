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
            create = new Dgvt(width, height, cellSize, originPosition, prefab);
        }
    }
}

/*public class WillTheRealDungeonGeneratorPleaseStandUp : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private GameObject[] prefab;
    GameObject pf;
    int lastvaluex;
    int lastvaluey;

    public WillTheRealDungeonGeneratorPleaseStandUp(int width, int height, float cellSize, Vector3 originPosition, GameObject[] prefab)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.prefab = prefab;
        gridArray = new int[width, height];
        Vector3 tf;
        int layerMask = ~LayerMask.GetMask("Player");
        int startselected = 0;

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                tf = new Vector3(x * cellSize, 30, y * cellSize);

                if (Physics.Raycast(tf, Vector3.down, out RaycastHit hit, 30, layerMask))
                {
                    Debug.Log("CoolNothingHappened");
                }
                else
                {
                    int prefabofchoice = Random.Range(0, prefab.Length);
                    pf = prefab[prefabofchoice];
                    Debug.Log(gridArray[x, y] + "Ga");
                    GameObject go = Instantiate(pf, new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(-90, 0, 0));
                    go.layer = 3;
                    go.tag = "Platform";
                    go.name = "Platform";
                    if (prefabofchoice == 0 && startselected == 0)
                    {
                        Renderer rend = go.GetComponent<Renderer>();
                        int amountMaterials = rend.materials.Length;
                        for (int i = 0; i < amountMaterials; i++)
                        {
                            rend.materials[i].color = Color.green;
                            go.tag = "Start";
                            go.name = "Start";
                        }
                        startselected++;
                    }
                    if (prefabofchoice == 1)
                    {
                        go.tag = "nan";
                        go.name = "nan";
                    }
                }
                lastvaluex = x;
                lastvaluey = y;
            }
        }
        GameObject[] nan = GameObject.FindGameObjectsWithTag("nan");
        foreach (GameObject obj in nan)
        {
            DestroyImmediate(obj);
        }

    }
}*/

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
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.prefab = prefab;
        gridArray = new int[width, height];
        //Vector3 tf;
        int layerMask = ~LayerMask.GetMask("Player");
        int selected = 0;
        int lx; //Last value x      (room 2 steps back)
        int ly; //Last value y 
        int x; //Current value x    (room previously created)
        int y; //Current value y 
        int nx; //New value x       (room about to be created)
        int ny; //New value y 
        int rotation;
        //GameObject go = Instantiate(prefab[Random.Range(0, prefab.Length)]);

        #region Startroom
        //Select if the spawnroom will be created on the x-axis or y-axis (0 = x) (1 = y)
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
        GameObject start = Instantiate(prefab[0], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0)); //Maybe adjust rotation later based on coordinates
        start.tag = "Start";
        start.name = "Start";
        start.layer = 3;
        start.GetComponent<Renderer>().material.color = Color.green;
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
        GameObject first = Instantiate(prefab[Random.Range(4, prefab.Length)], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(-90, rotation, 0));
        first.tag = "Platform";
        first.name = "Last";
        first.layer = 3;
        gridArray[x, y] = 1;
        #endregion

        #region RestOfTheRooms
        GameObject go;
        int rooms = 2;
        //bool twobytwo = false;
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
            if (iterate == 0 || rooms == 10)
            {
                go = GameObject.Find("Last");
                DestroyImmediate(go);
                Debug.Log(x * cellSize + " | " + y * cellSize);
                GameObject boss = Instantiate(prefab[1], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(0, rotation, 0));
                boss.tag = "Boss";
                boss.name = "Boss";
                boss.layer = 3;
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
                        if (gridArray[a, b] == 2 && check == 0 && i != random)
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
                        if(lx != a && ly != b)
                        {
                            //Debug variables
                            int dx = lx - a;
                            int dy = ly - b;
                            int cx = lx - x;
                            int cy = ly - y;
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
                                rotation = -90;
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
                        //if (rooms != 3)
                        //{
                            int room = rooms - 2;
                            go = GameObject.Find("Last");
                            go.name = "Room: " + room;
                        //}

                        go = Instantiate(prefab[Random.Range(4, prefab.Length)], new Vector3(x * cellSize, 0, y * cellSize), Quaternion.Euler(-90, rotation, 0));
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