using UnityEngine;
using UnityEngine.SceneManagement;

public class Travelscript : MonoBehaviour
{
    GameObject g1;
    GameObject g2;
    GameObject g3;
    GameObject g4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        g1 = GameObject.FindWithTag("0");
        g2 = GameObject.FindWithTag("1");
        g3 = GameObject.FindWithTag("2");
        g4 = GameObject.FindWithTag("3");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider g1)
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }
}
