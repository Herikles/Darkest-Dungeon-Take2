using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {

    float startTime;
    float duration;
    int gainedXP;
    private GUIStyle guiStyle = new GUIStyle();

    int random1, random2;
    int randomRange = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > duration) {
            Destroy(this.gameObject);
        }
	}

    public void PopUp(float duration, int gainedXP) {
        startTime = Time.time;
        this.duration = duration;
        this.gainedXP = gainedXP;
        random1 = Random.Range(-randomRange, randomRange);
        random2 = Random.Range(-randomRange, randomRange);
    }

    void OnGUI() {
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((Screen.width/2-100) + random1, (Screen.height/2-100) + random2, 200, 200), "+" + gainedXP + "XP", guiStyle);
    }
}
