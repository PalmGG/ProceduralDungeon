using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject g;
    private void Start()
    {
        g = GameObject.FindGameObjectWithTag("pm");
        g.SetActive(false);
    }
    private void OnPause()
    {
        Debug.Log(g);
        if (g.activeSelf)
        {
            g.SetActive(false);
        }
        else { g.SetActive(true); }
        
    }
}
