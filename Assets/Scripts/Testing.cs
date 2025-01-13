using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.ShaderGraph;

public class Testing : MonoBehaviour
{

    public Vector3 op;

    int pw;
    int ph;

    private Grid grid;

    int mmb = 0;
    int width = 1;
    int height = 1;
    int cellSize = 10;
    int selectedValue = 0;
    string tagV;
    GameObject player;



    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.SetActive(false);
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
        WorldText.CreateWorldText("3", "10", null, new Vector3(13, -11, 0), 40, new Vector4(0,0,0,0), TextAnchor.MiddleCenter);
        

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
    void OnLeftMClick()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        grid.SetValue(worldPosition, 2);
        Debug.Log(worldPosition);
    }

    void OnMiddleMClick()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(grid.GetValue(worldPosition));

    }

    void OnRightMClick()
    {
        if (mmb == 0 || mmb == 1)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(grid.GetValue(worldPosition) != 0)
            {
                grid.SetValue(worldPosition, mmb);
                mmb++;
            }
            
            Debug.Log(worldPosition);
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
                if(selectedValue < 3) 
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
    void OnVRight()
    {
        if(selectedValue == 4)
        {
            Debug.Log("1");
            selectedValue++;
            Debug.Log(selectedValue);
            Debug.Log(player);
            player.SetActive(true);
            Debug.Log(player);
        }
        if (selectedValue == 3)
        {
            selectedValue++;
            for (int i = 0; i < 4; i++)
            {
                tagV = i.ToString();
                Destroy(GameObject.FindWithTag(tagV));
            }
            GameObject[] gs = GameObject.FindGameObjectsWithTag("gs");
            foreach (GameObject go in gs)
            {
                Destroy(go);
            }

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


}
