using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Races : MonoBehaviour {

    public Support support;
    public Tank tank;
    public DamageDealer damageDealer;
    public Healer healer;
    public Assassine assassine;

    //string _className;
    public int playerIndex;
    public int enemyIndex;
    public int health = 100;
    public int damage;
    public float hitChance;
    public int dodge;
    public float blightRes;
    public float stunRes;
    public float bleedRes;
    public int initiative;

    public Sprite[] idleSprites;
    public Sprite[] attackSprites;
    public Sprite[] hitSprites;
    public Sprite[] deadSprites;

    public void SetClass(string className) {
        //Debug.Log("Still still Updating!");
        Reroll();
        if (className == "support") {
            playerIndex = 3;
            enemyIndex = 3;
            health = support.health;
            damage = support.damage;
            hitChance = support.hitChance;
            dodge = support.dodge;
            blightRes = support.blightRes;
            stunRes = support.stunRes;
            bleedRes = support.bleedRes;
            initiative = support.initiative;
        }
        else if (className == "tank") {
            playerIndex = 4;
            enemyIndex = 4;
            health = tank.health;
            damage = tank.damage;
            hitChance = tank.hitChance;
            dodge = tank.dodge;
            blightRes = tank.blightRes;
            stunRes = tank.stunRes;
            bleedRes = tank.bleedRes;
            initiative = tank.initiative;
        }
        else if (className == "damageDealer") {
            playerIndex = 1;
            enemyIndex = 1;
            health = damageDealer.health;
            damage = damageDealer.damage;
            hitChance = damageDealer.hitChance;
            dodge = damageDealer.dodge;
            blightRes = damageDealer.blightRes;
            stunRes = damageDealer.stunRes;
            bleedRes = damageDealer.bleedRes;
            initiative = damageDealer.initiative;
        }
        else if (className == "healer") {
            playerIndex = 2;
            enemyIndex = 2;
            health = healer.health;
            damage = healer.damage;
            hitChance = healer.hitChance;
            dodge = healer.dodge;
            blightRes = healer.blightRes;
            stunRes = healer.stunRes;
            bleedRes = healer.bleedRes;
            initiative = healer.initiative;
        }
        else if (className == "assassine") {
            playerIndex = 0;
            enemyIndex = 0;
            health = assassine.health;
            damage = assassine.damage;
            hitChance = assassine.hitChance;
            dodge = assassine.dodge;
            blightRes = assassine.blightRes;
            stunRes = assassine.stunRes;
            bleedRes = assassine.bleedRes;
            initiative = assassine.initiative;
        }
        else {
            playerIndex = 5;
            enemyIndex = 5;
        }
        Debug.Log("race = " + className);
    }

    public void Reroll() {
        assassine.Reroll();
        damageDealer.Reroll();
        healer.Reroll();
        support.Reroll();
        tank.Reroll();
    }
}
