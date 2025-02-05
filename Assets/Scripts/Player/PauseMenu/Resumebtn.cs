using UnityEngine;

public class Resumebtn : MonoBehaviour
{
    public void OnResumeBtnClick()
    {
        GameObject.FindGameObjectWithTag("pm").SetActive(false);
    }
}
