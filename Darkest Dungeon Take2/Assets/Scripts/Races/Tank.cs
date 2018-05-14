using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tank : MonoBehaviour {

    public Dice dice;

    public string   className;
    public int      health;
    public int      damage;
    public float    hitChance;
    public int      dodge;
    public float    blightRes;
    public float    stunRes;
    public float    bleedRes;
    public int      initiative;
    public int[] range = new int[4] { 0, 0, 0, 0 };


    void Start() {
        className = "Tank";
        health = 12 + dice.RollDice(3);
        damage = 2;
        hitChance = 0.90f;
        dodge = 3 + dice.RollDice(6);
        blightRes = 0.70f;
        stunRes = 0.80f;
        bleedRes = 0.80f;
        initiative = 5 + dice.RollDice(4);
    }

    public void Reroll() {
        health = 12 + dice.RollDice(3);
        dodge = 3 + dice.RollDice(6);
        initiative = 5 + dice.RollDice(4);
    }

    // Update is called once per frame
    void Update() {
		
	}
}
