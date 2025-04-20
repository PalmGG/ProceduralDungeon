using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public GameObject player;
    public GameObject g;
    public GameObject Classy;
    public GameObject ctext;
    public GameObject Statty;
    public GameObject stext;

    public GameObject c;
    public GameObject s;

    public void ClassClick()
    {
        Classy.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        ctext.GetComponent<TextMeshProUGUI>().color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);
        Statty.GetComponent<Image>().color = new Color(0.172549f, 0.172549f, 0.172549f, 1);
        stext.GetComponent<TextMeshProUGUI>().color = new Color(0.9607843f, 0.9607843f, 0.9607843f, 1);

        c.SetActive(true);
        s.SetActive(false);
    }

    public void StatClick()
    {
        Classy.GetComponent<Image>().color = new Color(0.172549f, 0.172549f, 0.172549f, 1);
        ctext.GetComponent<TextMeshProUGUI>().color = new Color(0.9607843f, 0.9607843f, 0.9607843f, 1);
        Statty.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        stext.GetComponent<TextMeshProUGUI>().color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);

        c.SetActive(false);
        s.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            string t = "";
            string name = (i + 1).ToString();
            Debug.Log(name);
            switch (i)
            {
                case 0:
                    t = player.GetComponent<PlayerStats>().health.ToString();
                    break;

                case 1:
                    t = player.GetComponent<PlayerStats>().defense.ToString();
                    break;

                case 2:
                    t = player.GetComponent<PlayerStats>().strength.ToString();
                    break;

                case 3:
                    t = player.GetComponent<PlayerStats>().intelligence.ToString();
                    break;

                case 4:
                    t = player.GetComponent<PlayerStats>().critChance.ToString();
                    break;

                case 5:
                    t = player.GetComponent<PlayerStats>().critDamage.ToString();
                    break;

                case 6:
                    t = player.GetComponent<PlayerStats>().bonus_atk_spd.ToString();
                    break;

                case 7:
                    t = player.GetComponent<PlayerStats>().speed.ToString();
                    break;

                case 8:
                    t = player.GetComponent<PlayerStats>().lifesteal.ToString();
                    break;

                case 9:
                    t = player.GetComponent<PlayerStats>().ability_power.ToString();
                    break;
                default:
                    t = "";
                    break;
            }
            GameObject.Find(name).GetComponent<TMPro.TextMeshProUGUI>().text = t;
        }
    }
}
