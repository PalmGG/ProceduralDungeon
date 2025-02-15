using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject g;
    Rigidbody rb;

    private void Start()
    {
        g = GameObject.FindGameObjectWithTag("pm");
        g.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
    private void OnPause()
    {
        Debug.Log(g);
        if (g.activeSelf)
        {
            g.SetActive(false);
            GetComponent<camRotate>().enabled = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            GetComponent<camRotate>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            g.SetActive(true); 
            
        }
        
    }
}
