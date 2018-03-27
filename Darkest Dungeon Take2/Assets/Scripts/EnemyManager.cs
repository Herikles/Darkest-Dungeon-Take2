using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];
    public PlayerManager playerManager;

    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];

    public string className = "empty";
    public int selected = 0;
    public int selectedEnemy = 0;

	void Start () {

	}
	
	void Update () {
		
	}

    public void SetCharacter(string charClass) {
        if (playerManager.selectedSide == 1) {
            //Debug.Log("!!!setCharacter enemy = " + charClass);
            enemyCharacter[selectedEnemy].className = charClass;
            enemyCharacter[selectedEnemy].UpdateStats();
        }
    }
}
