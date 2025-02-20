using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travelscript : MonoBehaviour
{
    public GameObject g;
    public string s;
    private void OnTriggerEnter(Collider g)
    {
        SceneManager.LoadScene(sceneName: s);
    }
}
