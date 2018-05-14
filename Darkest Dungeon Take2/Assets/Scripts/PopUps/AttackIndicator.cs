using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIndicator : MonoBehaviour {

    float startTime;
    float duration;

    public int characterIndex;
    public int enemyIndex;
    public bool attackSide;         //true = player, false = enemy

    public float movementSpeed = 1.0f;

    public SpriteRenderer character;
    public SpriteRenderer enemy;

    public Races races;

	// Use this for initialization
	void Start () {
        races = GameObject.Find("RacesManager").GetComponent<Races>();
    }
	
    public void PopUp(float duration, int characterIndex, int enemyIndex, bool attackSide) {
        startTime = Time.time;

        this.duration = duration;
        this.characterIndex = characterIndex;
        this.enemyIndex = enemyIndex;
        this.attackSide = attackSide;

        races = GameObject.Find("RacesManager").GetComponent<Races>();
        character.sprite = races.GetSprite(characterIndex, attackSide, true);
        enemy.sprite = races.GetSprite(enemyIndex, attackSide, false);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > duration) {
            Destroy(this.gameObject);
        }
        character.gameObject.transform.Translate(movementSpeed*Time.deltaTime, 0.0f, 0.0f);
    }
}
