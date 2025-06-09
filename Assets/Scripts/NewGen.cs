using UnityEngine;

public class NewGen : MonoBehaviour
{
    public int size; //Size: Small, Medium, Large
    public int difficulty; //Difficulty: Easy, Medium, Hard
    public GameObject start; //Inneh�ller f�rsta rummet
    public GameObject[] corridor; //Inneh�ller korridorer
    public GameObject[] rooms; //Inneh�ller rum
    public GameObject middle; //Inneh�ller mellersta rummet
    public GameObject end; //Inneh�ller sista rummet
    int rotation;
    int en = 0;
    int ex = 0;
    Vector3 exitpos = Vector3.zero;
    int negx = 1;

    void Start()
    {
        Instantiate(start, new Vector3(0, 0, 0), Quaternion.Euler(0, rotation, 0));
        for (int i = 0; i < 7; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                negx = -1;
            }
            else
            {
                negx = 1;
            }

            Instantiate(end, new Vector3(30 * Random.Range(1, 16) , 0, 30 * Random.Range(1, 16) * negx), Quaternion.Euler(0, rotation, 0));
            //door();
        }

    }

    void door()
    {
        entrance();
        exit();
        exitpoint();
    }
    void exitpoint()
    {
        for (int i = 1; i < ex + 1; i++)
            if (GameObject.Find("Exit" + i).tag == "0")
            {
                Debug.Log(i);
                GameObject.Find("Exit" + i).tag = "1";
                exitpos = GameObject.Find("Exit" + i).transform.position;
                Instantiate(end, exitpos, Quaternion.Euler(0, rotation, 0));
            }
    }

    void entrance()
    {
        //M�ste bygga script utifr�n att det ska finnas flera d�rrar senare
        //Kommer utf�ra detta genom att koppla nummer till rum/prefabs baserat p� antal d�rrar
        //Mellersta rummet kommer variera i antal d�rrar, m�ste d�rf�r h�lla det i tanken
        if (GameObject.Find("Entrance"))
        {
            en++;
            GameObject entrance = GameObject.Find("Entrance");
            entrance.name = "Entrance" + en;
        }
    }
    void exit()
    {
        //M�ste bygga script utifr�n att det ska finnas flera d�rrar senare
        //Kommer utf�ra detta genom att koppla nummer till rum/prefabs baserat p� antal d�rrar
        //Mellersta rummet kommer variera i antal d�rrar, m�ste d�rf�r h�lla det i tanken
        while (true)
        {
            if (GameObject.Find("Exit"))
            {
                ex++;
                GameObject exit = GameObject.Find("Exit");
                exit.name = "Exit" + ex;
                exit.tag = "0";
            }
            else { break; }
        }

    }
}
