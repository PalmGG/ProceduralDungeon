using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public GameObject g;


    public void ClassSelected()
    {
        int indexElement = g.GetComponent<Dropdown>().value;
        switch (indexElement)
        {
            case 1:
                Debug.Log("Tank");
                //Choice i playerstats
                break;

            case 2:
                Debug.Log("Berseker");
                break;

            case 3:
                Debug.Log("Archer");
                break;
            case 4:
                Debug.Log("Mage");
                break;
            default:
                Debug.Log("How did we get here?");
                break;
        }
    }
}
