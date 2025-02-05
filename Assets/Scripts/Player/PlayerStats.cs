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
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100;
    public float defense = 0;
    public float strength = 0;
    public float intelligence = 100;
    public float critChance = 30;
    public float critDamage = 50;
    public float bonus_atk_spd = 0;
    public static float speed = 100;

    void Start()
    {
        LoadData();
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
            speed = speed
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
    }
}