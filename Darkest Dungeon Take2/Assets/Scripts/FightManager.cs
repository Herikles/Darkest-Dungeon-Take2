using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FightManager : MonoBehaviour {

    public GameObject PopUpMenuParent;
    public GameObject PopUpMenu;
    public GameObject SettingsMenu;
    public GameObject SaveLoadMenu;

    public GameObject chooseCharacter;
    public GameObject fightSystem;
    public GameObject levelText;

    public GameObject UIplayerManager;
    public GameObject UIenemyManager;
    public EnemyManager enemyManager;

	public int wave = 0;
    public int maxWave = 3;
    public int encounter = 0;
	public int gold = 0;
	public float volume = 1.0f;
    
    void Start() {
        UpdateData();
    }

    void Update() {
        if (wave > 0) {
            enemyManager.CheckDead();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (PopUpMenuParent.activeSelf == true) {
                PopUpMenuParent.SetActive(false);
            }
            else if (PopUpMenuParent.activeSelf == false) {
                PopUpMenuParent.SetActive(true);
                PopUpMenu.SetActive(true);
                SettingsMenu.SetActive(false);
				SaveLoadMenu.SetActive (false);
            }
        }
    }

	public void UpdateData() {
		PopUpMenuParent.SetActive (false);
		if (wave == 0) {
            levelText.GetComponent<Text>().text = "Choose your Heroes!";
			chooseCharacter.SetActive (true);
			fightSystem.SetActive (false);
			UIenemyManager.SetActive (false);
            UIplayerManager.SetActive(true);

		} else if (wave > 0 && wave < maxWave) {
            levelText.GetComponent<Text>().text = "Wave " + wave;
            chooseCharacter.SetActive (false);
			fightSystem.SetActive (true);
			UIenemyManager.SetActive (true);
		} else if (wave == maxWave) {
            levelText.GetComponent<Text>().text = "Final Wave";
        }
	}

    public void StartFight() {
		wave++;
        enemyManager.randomCharacters();
		UpdateData ();
    }

    public void ChangeVolume(float newVolume) {
        AudioListener.volume = newVolume;
		volume = newVolume;
    }

    public void ButtonPressed(int buttonIndex) {
        switch (buttonIndex) {
        case 0:                     //settings
            PopUpMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            break;
        case 1:                     //continue
            PopUpMenuParent.SetActive(false);
       		break;
        case 2:                     //return to main menu
            Application.Quit();
            break;
		case 3:                     //return to first page
			SettingsMenu.SetActive (false);
			SaveLoadMenu.SetActive (false);
            PopUpMenu.SetActive(true);
            break;
		case 4:
			SaveLoadMenu.SetActive (true);
			PopUpMenu.SetActive (false);
			break;
        }
    }
}
