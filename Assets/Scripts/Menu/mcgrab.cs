using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class MyBehaviour : MonoBehaviour
{
    public string skin;
    public Texture t;
    public GameObject g;
    Renderer r;
    void Start()
    {
        r = g.GetComponent<Renderer>();
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://mineskin.eu/skin/"+ skin + ".png");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            t = DownloadHandlerTexture.GetContent(www);
            t.filterMode = FilterMode.Point;
            r.material.mainTexture = t;
        }
    }
}