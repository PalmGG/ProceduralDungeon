using UnityEngine;

public class Choice : MonoBehaviour
{
    public GameObject g;
    public void John(int index)
    {
        if (index == 0)
        {
            g.SetActive(false);
        }
        else
        {
            g.SetActive(true);
        }
    }
}
