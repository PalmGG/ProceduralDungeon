using UnityEngine;
using UnityEngine.SceneManagement;

public class Travelscript : MonoBehaviour
{
    GameObject p;
    public string s;
    public bool sexyteleport;

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider p)
    {
        if (sexyteleport == true)
        {
            
            SceneManager.LoadScene(sceneName: s);
        }
    }
}
