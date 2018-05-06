using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * when enemy is killed, you gain XP
 * XP will be indicated with a short popup (eg +12XP)
 * 
 *                      !!! not working on last enemy of wave!!!
 * 
 */

public class PopUpThings : MonoBehaviour {

    public DungeonManager dungeonManager;
    public Indicator indicator;
    public GameObject indicatorObject;
    public GameObject newObject;

    float startTime;
    public float duration = 1.0f;

    int gainedXP = 0;

    bool showText = false;

	// Use this for initialization
	void Start () {
		
	}

    public void GainXP(int gXP) {
        newObject = GameObject.Instantiate(indicatorObject, new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
        indicator = newObject.GetComponent<Indicator>();
        indicator.PopUp(duration, gXP);
        dungeonManager.exp += gXP;
    } 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s")) {
            GainXP(12);
        }
	}
}
