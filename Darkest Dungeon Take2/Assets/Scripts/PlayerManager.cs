using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];
    public Races races;

    public GameObject characterIcon;
    public Image image;

    public EnemyManager enemyManager;
    public string className = "empty";
    public int selected = 0;
    public int selectedEnemy = 0;
    public int prevSelected = 0;
    public int prevSelectedEnemy = 0;

    public int selectedSide = 0;
    public int prevSelectedSide = 0;

    public int damage;

    void Start() {
        image = characterIcon.GetComponent<Image>();
        image.sprite = races.idleSprites[selected];
        character[selected].border.SetActive(true);
        enemyCharacter[selected].border.SetActive(true);
    }
	
	void Update () {
        damage = character[selected].damage + character[selected].GetComponent<CarriedItem>().weaponDamage;
        WhichSelected();
        
	}

    public void WhichSelected() {
        // TODO: Character nach anwählen der gegnerseite nicht erneut anwählbar. 
        // Erst nach anwählen eines anderen characters möglich.
        selectedEnemy = enemyManager.selectedEnemy;
        if (selected != prevSelected) {                                 //Grund
            character[selected].border.SetActive(true);
            character[prevSelected].border.SetActive(false);
            //enemyCharacter[selectedEnemy].border.SetActive(false);
            prevSelected = selected;
            selectedSide = 0;
        }
        if (enemyManager.selectedEnemy != prevSelectedEnemy) {          //Grund2
            enemyCharacter[selectedEnemy].border.SetActive(true);
            enemyCharacter[prevSelectedEnemy].border.SetActive(false);
            //character[selected].border.SetActive(false);
            prevSelectedEnemy = enemyManager.selectedEnemy;
            selectedSide = 1;
        }
    }

    public void Attack(int attackNum) {
        damage = character[selected].damage + character[selected].GetComponent<CarriedItem>().weaponDamage;
        if (Hit() == true) {
            switch (attackNum) {
                case 0:
                    Attack1();
                    break;
                case 1:
                    Attack2();
                    break;
                case 2:
                    Attack3();
                    break;
                case 3:
                    Attack4();
                    break;
            }
        }
    }

    public void Attack1() {
        Debug.Log("Character " + selected + " attacks Enemy " + selectedEnemy + " with Attack 1");
        enemyCharacter[selectedEnemy].health -= damage;
    }

    public void Attack2() {
        //Attack2 stuff
        Debug.Log("Character " + selected + " attacks Enemy " + selectedEnemy + " with Attack 2");
        int damage = 4;
        enemyCharacter[selectedEnemy].health -= damage;
    }

    public void Attack3() {
        //Attack3 stuff
        Debug.Log("Character " + selected + " attacks Enemy " + selectedEnemy + " with Attack 3");
        int damage = 8;
        enemyCharacter[selectedEnemy].health -= damage;
    }

    public void Attack4() {
        //Attack4 stuff
        Debug.Log("Character " + selected + " attacks Enemy " + selectedEnemy + " with Attack 4");
        int damage = 1000;
        enemyCharacter[selectedEnemy].health -= damage;
    }

    public bool Hit() {
        float hitChance = character[selected].hitChance;
        float dodge = enemyCharacter[selectedEnemy].dodge/100f;
        Debug.Log("Hitchance = " + hitChance + "; Dodge = " + dodge);
        if (Random.Range(0.0f, 1.0f) < (hitChance-dodge)) {
            Debug.Log("Attack successfull");
            return true;
        } else {
            Debug.Log("Attack failed");
            return false;
        }
    }


    public void SetCharacter(string charClass) {
        if (selectedSide == 0) {
            //Debug.Log("Position index = " + selected);
            character[selected].className = charClass;
            character[selected].UpdateStats();
        }
    }
}
