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

    public void CallTp()
    {
        if (sexyteleport == true)
        {
            SceneManager.LoadScene(sceneName: s);
        }
    }

    public void SB()
    {
        if(this.GetComponent<PlayerStats>().speed == 0)
        {
            SceneManager.LoadScene(sceneName: "CharacterCreation");
        }
        else
        {
            SceneManager.LoadScene(sceneName: "Start");
        }
    }
}
