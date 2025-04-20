using UnityEngine;

public class Choice : MonoBehaviour
{
    public GameObject g;
    public GameObject player;
    float health = 100;
    float defense = 0;
    float strength = 0;
    float intelligence = 100;
    float critChance = 30;
    float critDamage = 50;
    float bonus_atk_spd = 0;
    float speed = 100;
    float lifesteal = 0;
    float ap = 0;
    int stupid = 0;
    public void John(int index)
    {
        bool john = true;
        switch (index)
        {
            case 0:
                Debug.Log("Stupid ah select a real class");
                health = 1;
                defense = 1;
                strength = 1;
                intelligence = 1;
                critChance = 1;
                critDamage = 1;
                bonus_atk_spd = 1;
                speed = 1;
                lifesteal = 1;
                ap = 1;
                stupid++;
                if (stupid < 3)
                {
                    //Voiceline: "Are you sure whatever you're doing is worth it"
                    john = false;
                }
                break;

            case 1:
                Debug.Log("Tank");
                health = 150;
                defense = 25;
                strength = 0;
                intelligence = 100;
                critChance = 30;
                critDamage = 50;
                bonus_atk_spd = 0;
                speed = 100;
                lifesteal = 0;
                ap = 0;
                break;

            case 2:
                Debug.Log("Berserker");
                health = 100;
                defense = 0;
                strength = 50;
                intelligence = 100;
                critChance = 30;
                critDamage = 50;
                bonus_atk_spd = 0;
                speed = 150;
                lifesteal = 10;
                ap = 0;
                break;

            case 3:
                Debug.Log("Archer");
                health = 75;
                defense = 0;
                strength = 0;
                intelligence = 100;
                critChance = 60;
                critDamage = 75;
                bonus_atk_spd = 25;
                speed = 100;
                lifesteal = 0;
                ap = 0;
                break;

            case 4:
                Debug.Log("Mage");
                health = 75;
                defense = 0;
                strength = 0;
                intelligence = 200;
                critChance = 30;
                critDamage = 50;
                bonus_atk_spd = 0;
                speed = 100;
                lifesteal = 0;
                ap = 30;
                break;
        }
        player.GetComponent<PlayerStats>().change(health, defense, strength, intelligence, critChance, critDamage, bonus_atk_spd, speed, lifesteal, ap);
        g.SetActive(john);
    }
}
