using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FightManager : MonoBehaviour {

    public GameObject PopUpMenuParent;
    public GameObject PopUpMenu;
    public GameObject SettingsMenu;
    public GameObject SaveLoadMenu;

    public GameObject chooseCharacter;
    public GameObject fightSystem;

    public GameObject playerManager;
    public GameObject enemyManager;

	public int level = 0;
	public int gold = 0;
	public float volume = 1.0f;
    
    void Start() {
        PopUpMenuParent.SetActive(false);

        chooseCharacter.SetActive(true);
        fightSystem.SetActive(false);
        enemyManager.SetActive(false);
        playerManager.SetActive(true);
    }

	public void UpdateData() {
		PopUpMenuParent.SetActive (false);
		if (level == 0) {
			chooseCharacter.SetActive (true);
			fightSystem.SetActive (false);
			enemyManager.SetActive (false);

		} else if (level > 0) {
			chooseCharacter.SetActive (false);
			fightSystem.SetActive (true);
			enemyManager.SetActive (true);
		}
	}
    
    void Update() {
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

    public void StartFight() {
		level++;
        chooseCharacter.SetActive(false);
        fightSystem.SetActive(true);
        enemyManager.SetActive(true);
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
