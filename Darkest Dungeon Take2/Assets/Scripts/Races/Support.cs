using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Support : MonoBehaviour {

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
        className = "Support";
        health = 9 + dice.RollDice(3);
        damage = 3;
        hitChance = 0.90f;
        dodge = 5 + dice.RollDice(6);
        blightRes = 0.70f;
        stunRes = 0.60f;
        bleedRes = 0.70f;
        initiative = 8 + dice.RollDice(4);
        range = new int[4] {1,1,1,1};
    }

    public void Reroll() {
        health = 9 + dice.RollDice(3);
        dodge = 5 + dice.RollDice(6);
        initiative = 8 + dice.RollDice(4);
    }

    // Update is called once per frame
    void Update() {

    }
}
