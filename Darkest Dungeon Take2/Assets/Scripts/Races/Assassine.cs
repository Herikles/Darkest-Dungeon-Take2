using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Assassine : MonoBehaviour {

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
        className = "Assassine";
        health = 7 + dice.RollDice(3);
        damage = 5;
        hitChance = 0.95f;
        dodge = 10 + dice.RollDice(3);
        blightRes = 0.70f;
        stunRes = 0.60f;
        bleedRes = 0.70f;
        initiative = 9 + dice.RollDice(6);
    }

    public void Reroll() {
        health = 7 + dice.RollDice(3);
        dodge = 10 + dice.RollDice(3);
        initiative = 9 + dice.RollDice(6);
    }

    // Update is called once per frame
    void Update() {

    }
}
