using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour {

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];
    public PlayerManager playerManager;

    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];
    public FightManager fightManager;

    public string className = "empty";
    public int selected = 0;
    public int selectedEnemy = 0;

    bool[] alive = new bool[4] { true, true, true, true };

	void Start () {

	}
	
	void Update () {
        
	}

    public void CheckDead() {
        for (int i = 0; i < 4; i++) {
            if (enemyCharacter[i].health <= 0) {
                alive[i] = false;
            } else {
                alive[i] = true;
            }
        }
        
        if (alive[0] == false && alive[1] == false && alive[2] == false && alive[3] == false) {
            randomCharacters();
            fightManager.wave++;
            fightManager.UpdateData();
        }
    }

    public void randomCharacters() {
        for (int i = 0; i < 4; i++) {
            enemyCharacter[i].enemyIndex = Random.Range(0, 5);
            enemyCharacter[i].UpdateStats();
        }
    }

	public void SetCharacter(int enemyIndex) {
        if (playerManager.selectedSide == 1) {
            //Debug.Log("!!!setCharacter enemy = " + charClass);
			enemyCharacter[selectedEnemy].enemyIndex = enemyIndex;
            enemyCharacter[selectedEnemy].UpdateStats();
        }
    }
}
