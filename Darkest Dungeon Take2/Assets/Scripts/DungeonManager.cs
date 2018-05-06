using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {

    public FightManager fightManager;

    [Header("Player Level")]
    public int expLevel;
    public int exp;
    public int startExp = 100;
    public int nextExp;

    [Header("Dungeon Level")]
    public int dungeonLevel = 0;
    public float dLevelMulti = 1.5f;

	// Use this for initialization
	void Start () {
        nextExp = Mathf.RoundToInt(startExp * Mathf.Pow(1.2f, expLevel));
        dungeonLevel = fightManager.wave;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int calcXP() {
        return 10;
    }
}
