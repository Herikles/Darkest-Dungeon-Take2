using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public Dice dice;

    public string name = "banana";
    public int damage;
    
    public int tier1_minDamage = 1;
    public int tier1_maxDamage = 3;

    public int tier2_minDamage = 3;
    public int tier2_maxDamage = 5;

    public int tier3_minDamage = 5;
    public int tier3_maxDamage = 7;

    public void SetWeapon(int tier) {
        switch (tier) {
            case 1:
                damage = dice.RollDice(tier1_minDamage, tier1_maxDamage);
                Debug.Log("Tier 1 Weapon set!");
                break;
            case 2:
                damage = dice.RollDice(tier2_minDamage, tier2_maxDamage);
                Debug.Log("Tier 2 Weapon set!");
                break;
            case 3:
                damage = dice.RollDice(tier3_minDamage, tier3_maxDamage);
                Debug.Log("Tier 3 Weapon set!");
                break;
        }
    }

    void Start() {

    }

    void Update() {

    }
}