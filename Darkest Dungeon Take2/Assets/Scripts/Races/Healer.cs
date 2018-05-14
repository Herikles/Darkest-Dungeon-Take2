using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Healer : MonoBehaviour {

    public Dice dice;

    public string className;
    public int health;
    public int damage;
    public float hitChance;
    public int dodge;
    public float blightRes;
    public float stunRes;
    public float bleedRes;
    public int initiative;
    public int[] range = new int[4] { 0, 0, 0, 0 };


    void Start() {
        className = "Healer";
        health = 8 + dice.RollDice(3);
        damage = 1;
        hitChance = 0.80f;
        dodge = 3 + dice.RollDice(6);
        blightRes = 0.80f;
        stunRes = 0.60f;
        bleedRes = 0.60f;
        initiative = 7 + dice.RollDice(4);
    }

    public void Reroll() {
        health = 9 + dice.RollDice(3);
        dodge = 3 + dice.RollDice(6);
        initiative = 7 + dice.RollDice(4);
    }

    // Update is called once per frame
    void Update() {

    }
}
