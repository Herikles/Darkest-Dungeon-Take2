using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {

    public GameObject PopUpMenuParent;
    public GameObject PopUpMenu;
    public GameObject SettingsMenu;
    //public GameObject MainMenu;

    public GameObject chooseCharacter;
    public GameObject fightSystem;

    public GameObject playerManager;
    public GameObject enemyManager;
    
    void Start() {
        PopUpMenuParent.SetActive(false);

        chooseCharacter.SetActive(true);
        fightSystem.SetActive(false);
        enemyManager.SetActive(false);
        playerManager.SetActive(true);
    }
    
    void Update() {



        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (PopUpMenuParent.active == true) {
                PopUpMenuParent.SetActive(false);
            }
            else if (PopUpMenuParent.active == false) {
                PopUpMenuParent.SetActive(true);
                PopUpMenu.SetActive(true);
                SettingsMenu.SetActive(false);
            }
        }


    }

    public void StartFight() {
        chooseCharacter.SetActive(false);
        fightSystem.SetActive(true);
        enemyManager.SetActive(true);
    }

    public void ChangeVolume(float newVolume) {
        AudioListener.volume = newVolume;
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
                SettingsMenu.SetActive(false);
                PopUpMenu.SetActive(true);
                break;
        }
    }
}
