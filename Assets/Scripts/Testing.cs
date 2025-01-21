using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.ShaderGraph;
using System.Collections;
using System;

public class Testing : MonoBehaviour
{

    public Vector3 op;

    int pw;
    int ph;

    private Grid grid;

    int mmb = 1;
    int width = 1;
    int height = 1;
    int cellSize = 10;
    int selectedValue = 0;
    string tagV;
    Boolean teleport = false;
    GameObject player;
    Rigidbody rb;
    GameObject ob;



    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        player.GetComponent<MoveFinalSystem>().enabled = false;
        player.GetComponent<camRotate>().enabled = false;
        //Settings Title
        WorldText.CreateWorldText("gs", "Grid settings", null, new Vector3(0, -10, 8), 40, Color.white, TextAnchor.MiddleCenter);
        //Categories
        WorldText.CreateWorldText("gs", "X", null, new Vector3(-10, -11, 4), 40, Color.white, TextAnchor.MiddleCenter);
        WorldText.CreateWorldText("gs", "Y", null, new Vector3(0, -11, 4), 40, Color.white, TextAnchor.MiddleCenter);
        WorldText.CreateWorldText("gs", "Size", null, new Vector3(13, -11, 4), 40, Color.white, TextAnchor.MiddleCenter);
        //Values
        WorldText.CreateWorldText("0", "1", null, new Vector3(-10, -11, 0), 40, Color.blue, TextAnchor.MiddleCenter);
        WorldText.CreateWorldText("1", "1", null, new Vector3(0, -11, 0), 40, Color.white, TextAnchor.MiddleCenter);
        WorldText.CreateWorldText("2", "10", null, new Vector3(13, -11, 0), 40, Color.white, TextAnchor.MiddleCenter);
        WorldText.CreateWorldText("3", "10", null, new Vector3(13, -11, 0), 40, new Vector4(0, 0, 0, 0), TextAnchor.MiddleCenter);


        //Selected value code

        //Next Value


        /*       
        grid = new Grid(width, height, cellSize, op);
        Camera camera = Camera.main;
        pw = width * cellSize;
        ph = height * cellSize;
        camera.ortographic = true;
        camera.transform.position = new Vector3(op.x +pw * 0.5f, 30,op.y + ph * 0.5f);
        camera.orthographicellSizeize = Mathf.Max(pw * Screen.height / Screen.width * 0.5f, ph * 0.5f) + 1;
        */
    }
    //https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/

    private void FixedUpdate()
    {
        if(teleport == true)
        {
            rb.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y + 10, ob.transform.position.z);
            teleport = false;
        }
    }
    void OnLeftMClick()
    {
        if (selectedValue == 4)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (grid.GetValue(worldPosition) != 1 && grid.GetValue(worldPosition) != 2)
            {
                grid.SetValue(worldPosition, 3);
            }
        }
    }

    void OnMiddleMClick()
    {
        if (selectedValue == 4)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(grid.GetValue(worldPosition));
        }


    }

    void OnRightMClick()
    {
        if (mmb == 1 || mmb == 2)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (grid.GetValue(worldPosition) != 1 && grid.GetValue(worldPosition) != 2)
            {
                grid.SetValue(worldPosition, mmb);
                mmb++;
            }
        }
    }

    void OnVUp()
    {
        if (selectedValue < 3)
        {
            tagV = selectedValue.ToString();
            GameObject tm = GameObject.FindWithTag(tagV);
            TextMesh t = tm.GetComponent<TextMesh>();
            switch (selectedValue)
            {
                case 0:
                    width++;
                    t.text = width + "";
                    break;
                case 1:
                    height++;
                    t.text = height + "";
                    break;
                case 2:
                    cellSize++;
                    t.text = cellSize + "";
                    break;
            }
        }
    }
    void OnVDown()
    {
        if (selectedValue < 3)
        {
            tagV = selectedValue.ToString();
            GameObject tm = GameObject.FindWithTag(tagV);
            TextMesh t = tm.GetComponent<TextMesh>();
            switch (selectedValue)
            {
                case 0:
                    if (width > 1)
                    {
                        width--;
                    }
                    t.text = width + "";
                    break;
                case 1:
                    if (height > 1)
                    {
                        height--;
                    }
                    t.text = height + "";
                    break;
                case 2:
                    if (cellSize > 1)
                    {
                        cellSize--;
                    }
                    t.text = cellSize + "";
                    break;
            }
        }

    }
    void OnVLeft()
    {
        if (selectedValue < 4)
        {
            tagV = selectedValue.ToString();
            GameObject tm = GameObject.FindWithTag(tagV);
            TextMesh t = tm.GetComponent<TextMesh>();
            if (selectedValue > 0)
            {
                if (selectedValue < 3)
                {
                    t.color = Color.white;
                }
                selectedValue--;
                tagV = selectedValue.ToString();
                tm = GameObject.FindWithTag(tagV);
                t = tm.GetComponent<TextMesh>();
                t.color = Color.blue;
            }
        }
    }
    void DBug()
    {
        GameObject go;
        GameObject ngo;
        int gv;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gv = grid.GetValue(x, y);
                switch (gv)
                {
                    case 0:
                        go = GameObject.FindGameObjectWithTag("nan");
                        DestroyImmediate(go);
                        break;
                    case 1:
                        go = GameObject.FindGameObjectWithTag("Start");
                        ngo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        ngo.tag = "Start";
                        ngo.layer = 3;
                        ngo.GetComponent<MeshRenderer>().material.color = Color.green;
                        ngo.transform.position = go.transform.position;
                        ngo.transform.localScale = new Vector3(cellSize, 1, cellSize);
                        DestroyImmediate(go);

                        break;
                    case 2:
                        go = GameObject.FindGameObjectWithTag("Goal");
                        ngo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        ngo.tag = "Goal";
                        ngo.layer = 3;
                        ngo.GetComponent<MeshRenderer>().material.color = Color.red;
                        ngo.transform.position = go.transform.position;
                        ngo.transform.localScale = new Vector3(cellSize, 1, cellSize);
                        DestroyImmediate(go);
                        break;
                    case 3:
                        go = GameObject.FindGameObjectWithTag("Platform");
                        ngo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        ngo.tag = "RealPlat";
                        ngo.layer = 3;
                        ngo.transform.position = go.transform.position;
                        Debug.Log(cellSize);
                        ngo.transform.localScale = new Vector3(cellSize, 1, cellSize);
                        DestroyImmediate(go);
                        break;
                }
            }
        }
    }
    void OnVRight()
    {
        if (selectedValue == 4)
        {
            Debug.Log("Debug start");
            DBug();
            Debug.Log("Debug end");
            selectedValue++;
            GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
            ob = GameObject.FindGameObjectWithTag("Start");
            Debug.Log($"Before setting player position: {player.transform.position}");
            teleport = true;
            //rb.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y + 10, ob.transform.position.z);
            Debug.Log($"After setting player position: {player.transform.position}");
            Debug.Log(player);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            player.GetComponent<camRotate>().enabled = true;
            player.GetComponent<MoveFinalSystem>().enabled = true;
            //player.GetComponent<Testing>().enabled = false;
        }
        if (selectedValue == 3)
        {
            selectedValue++;
            for (int i = 0; i < 4; i++)
            {
                tagV = i.ToString();
                GameObject obj = GameObject.FindWithTag(tagV);
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
            StartCoroutine(DestroyObjectsWithDelay());

            grid = new Grid(width, height, cellSize, op);
            pw = width * cellSize;
            ph = height * cellSize;
            Camera.main.orthographic = true;
            Camera.main.transform.position = new Vector3(op.x + pw * 0.5f, 30, op.y + ph * 0.5f);
            Camera.main.orthographicSize = Mathf.Max(pw * Screen.height / Screen.width * 0.5f, ph * 0.5f) + 1;
        }
        if (selectedValue < 4)
        {
            if (selectedValue < 3)
            {
                tagV = selectedValue.ToString();
                GameObject tm = GameObject.FindWithTag(tagV);
                TextMesh t = tm.GetComponent<TextMesh>();
                t.color = Color.green;
                selectedValue++;
                if (selectedValue < 3)
                {
                    tagV = selectedValue.ToString();
                    tm = GameObject.FindWithTag(tagV);
                    t = tm.GetComponent<TextMesh>();
                    t.color = Color.blue;
                }
            }

        }
    }
    IEnumerator DestroyObjectsWithDelay()
    {
        yield return new WaitForEndOfFrame(); // Ensure all objects are properly initialized or destroyed in the frame

        GameObject[] gs = GameObject.FindGameObjectsWithTag("gs");
        foreach (GameObject go in gs)
        {
            if (go != null)
            {
                DestroyImmediate(go);
            }
            else
            {
                Debug.Log("Fuck");
            }
        }
    }

}
