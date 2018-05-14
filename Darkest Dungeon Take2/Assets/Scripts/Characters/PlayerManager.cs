using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [Header("Characters")]
    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];

    [Header("Other Objects")]
	public Races races;
    public FightManager fightManager;
    public GameObject characterIcon;
    public Image image;
    public EnemyManager enemyManager;
    public PopUpThings popUpThings;

    [Header("Selected")]
    //public string className = "empty";
    public int selected = 0;
    public int selectedEnemy = 0;
    public int prevSelected = 0;
    public int prevSelectedEnemy = 0;

    public int selectedSide = 0;
    public int prevSelectedSide = 0;

    public int damage;
    
    [Header("Save System")]
    public int saveslot = 0;
    public Button[] setSaveslotButtons;

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

            popUpThings.attack(character[selected].playerIndex, enemyCharacter[selectedEnemy].enemyIndex, true);

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
        } else {
            popUpThings.attackFailed();
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
        int damage = 100;
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


	public void SetCharacter(int playerIndex) {
        if (selectedSide == 0) {
            //Debug.Log("Position index = " + selected);
			character[selected].playerIndex = playerIndex;
            character[selected].UpdateStats();
        }
    }


	public void setSaveslot(int ss) {
		for (int i = 0; i < 4; i++) {
			if (i == ss)
				setSaveslotButtons [i].GetComponent<Image>().color = new Color32(0,255,255,255);
			else
				setSaveslotButtons [i].GetComponent<Image>().color = Color.white;
		}
		Debug.Log ("Saveslot set to " + ss);
		saveslot = ss;
	}

	public void Save() {
		for (int i = 0; i < 4; i++) {
			SaveLoadManager.SavePlayer (character, saveslot);
			SaveLoadManager.SaveEnemy (enemyCharacter, saveslot);
		}
		SaveLoadManager.SaveGameData (fightManager, saveslot);
	}
		
	public void Load() {
		
		float[] gameStats = SaveLoadManager.LoadGameData (saveslot);
		fightManager.wave = (int)gameStats [0];
		fightManager.gold = (int)gameStats [1];
		fightManager.volume = gameStats [2];
		fightManager.UpdateData ();

		for (int i = 0; i < 4; i++) {
			float[] loadedEnemyStats = SaveLoadManager.LoadEnemy (i, saveslot);
			enemyCharacter [i].enemyIndex = (int)loadedEnemyStats [4];
			enemyCharacter [i].UpdateStats ();
			enemyCharacter [i].health = (int)loadedEnemyStats [0];
			enemyCharacter [i].damage = (int)loadedEnemyStats [1];
			enemyCharacter [i].dodge = (int)loadedEnemyStats [2];
			enemyCharacter [i].initiative = (int)loadedEnemyStats [3];
			enemyCharacter [i].position = (int)loadedEnemyStats [5];
			enemyCharacter [i].hitChance = loadedEnemyStats [6];
			enemyCharacter [i].blightRes = loadedEnemyStats [7];
			enemyCharacter [i].stunRes = loadedEnemyStats [8];
			enemyCharacter [i].bleedRes = loadedEnemyStats [9];


			float[] loadedStats = SaveLoadManager.LoadPlayer (i, saveslot);
			character [i].playerIndex = (int)loadedStats [4];
			character [i].UpdateStats ();
			character [i].health = (int)loadedStats [0];
			character [i].damage = (int)loadedStats [1];
			character [i].dodge = (int)loadedStats [2];
			character [i].initiative = (int)loadedStats [3];
			character [i].position = (int)loadedStats [5];
			character [i].hitChance = loadedStats [6];
			character [i].blightRes = loadedStats [7];
			character [i].stunRes = loadedStats [8];
			character [i].bleedRes = loadedStats [9];
		}

	}
}
