using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Races : MonoBehaviour {

    public Support support;
    public Tank tank;
    public DamageDealer damageDealer;
    public Healer healer;
    public Assassine assassine;

    //string _className;
    //public int playerIndex;
    //public int enemyIndex;
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

    public Sprite GetSprite(int index, bool player, bool attacker) {
        Sprite sprite = new Sprite();
        if (player == true) {
            if (attacker == true) {
                sprite = attackSprites[index];
            } else {
                sprite = hitSprites[index];
            }
        } else {
            if(attacker == true) {
                sprite = attackSprites[index];
            } else {
                sprite = hitSprites[index];
            }
        }
        return sprite;
    }

    public void SetClass(int playerIndex) {
        Reroll();
		if (playerIndex == 3) {
            health = support.health;
            damage = support.damage;
            hitChance = support.hitChance;
            dodge = support.dodge;
            blightRes = support.blightRes;
            stunRes = support.stunRes;
            bleedRes = support.bleedRes;
            initiative = support.initiative;
        }
		else if (playerIndex == 4) {
            health = tank.health;
            damage = tank.damage;
            hitChance = tank.hitChance;
            dodge = tank.dodge;
            blightRes = tank.blightRes;
            stunRes = tank.stunRes;
            bleedRes = tank.bleedRes;
            initiative = tank.initiative;
        }
		else if (playerIndex == 1) {
            health = damageDealer.health;
            damage = damageDealer.damage;
            hitChance = damageDealer.hitChance;
            dodge = damageDealer.dodge;
            blightRes = damageDealer.blightRes;
            stunRes = damageDealer.stunRes;
            bleedRes = damageDealer.bleedRes;
            initiative = damageDealer.initiative;
        }
		else if (playerIndex == 2) {
            health = healer.health;
            damage = healer.damage;
            hitChance = healer.hitChance;
            dodge = healer.dodge;
            blightRes = healer.blightRes;
            stunRes = healer.stunRes;
            bleedRes = healer.bleedRes;
            initiative = healer.initiative;
        }
		else if (playerIndex == 0) {
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
        }
		Debug.Log("race = " + playerIndex);
    }

    public void Reroll() {
        assassine.Reroll();
        damageDealer.Reroll();
        healer.Reroll();
        support.Reroll();
        tank.Reroll();
    }
}
