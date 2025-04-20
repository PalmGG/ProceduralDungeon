/*using UnityEngine;

public class PlayerStats : MonoBehaviour {

    //base stats are taken from hypixel skyblock: https://hypixel-skyblock.fandom.com/wiki/Stats
    //Default values of Stats
    public float hp = 100; // Health
    public float defense = 0; // Negates a % of damage
    public float strength = 0; // Adds more damage to your attacks
    public float intelligence = 100; // 1:1 convertion to mana
    public float cc = 30; // Crit chance
    public float cd = 50; // Crit damage
    public float bonus_atk_spd = 0; // Bonus attack speed

    void Start()
    {
        //Get load data
    }
    void OnSprint()
    {
        SaveSystem.Save();
    }
    #region Save and Load
    public void Save(ref PlayerSaveData data)
    {
        data.health = hp;
    }
    public void Load(PlayerSaveData data)
    {
        hp = data.health;
    }
    #endregion
    [System.Serializable]
    public struct PlayerSaveData
    {
        public float health;
    }
}
*/
using System.IO;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public float health = 0;
    public float defense = 0;
    public float strength = 0;
    public float intelligence = 0;
    public float critChance = 0;
    public float critDamage = 0;
    public float bonus_atk_spd = 0;
    public float speed = 0;
    public float lifesteal = 0;
    public float ability_power = 0;

    void Start()
    {
        string filePath = Application.persistentDataPath + "/save.json";

        if (File.Exists(filePath))
        {
            LoadData();
        }
    }
    public void change(float h, float d, float s, float i, float cc, float cd, float basp, float sp, float ls, float ap)
    {
        health = h;
        defense = d;
        strength = s;
        intelligence = i;
        critChance = cc;
        critDamage = cd;
        bonus_atk_spd = basp;
        speed = sp;
        lifesteal = ls;
        ability_power = ap;
        SaveData();
    }
    public void SaveData()
    {
        PlayerSaveData data = new PlayerSaveData
        {
            health = health,
            defense = defense,
            strength = strength,
            intelligence = intelligence,
            critChance = critChance,
            critDamage = critDamage,
            bonusAttackSpeed = bonus_atk_spd,
            speed = speed,
            lifesteal = lifesteal,
            ability_power = ability_power
        };

        SaveSystem.Save(data);
    }

    public void LoadData()
    {
        PlayerSaveData data = SaveSystem.Load();
        health = data.health;
        defense = data.defense;
        strength = data.strength;
        intelligence = data.intelligence;
        critChance = data.critChance;
        critDamage = data.critDamage;
        bonus_atk_spd = data.bonusAttackSpeed;
        speed = data.speed;
        lifesteal = data.lifesteal;
        ability_power = data.ability_power;
    }

    [System.Serializable]
    public struct PlayerSaveData
    {
        public float health;
        public float defense;
        public float strength;
        public float intelligence;
        public float critChance;
        public float critDamage;
        public float bonusAttackSpeed;
        public float speed;
        public float lifesteal;
        public float ability_power;
    }
}
//Camera settings: y.25 z-4.3 || x5
//Cylinder settings y-1.1 || xz 2.75 y.1
//Cylinder1 settings y-1.24 || xz 4 y.1