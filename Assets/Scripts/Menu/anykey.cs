using UnityEngine;
using UnityEngine.UI;

public class anykey : MonoBehaviour
{
    public GameObject se;
    public GameObject p;
    GameObject bg;
    Color c = new Color(0.62f, 0.62f, 0.62f, 1f);
    void Start()
    {
        bg = GameObject.FindWithTag("0");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            bg.GetComponent<RawImage>().color = c;
            Instantiate(se,p.transform);
            this.gameObject.SetActive(false);
        }
    }
}
