using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour {
    
    //public string className = "empty";
	public int playerIndex = 5; //0=ass, 1=dd, 2=heal, 3=sup, 4=tank
	int prevPlayerIndex;
    public Races races;
    public int position;
    public PlayerManager playerManager;

    public SpriteRenderer spriteRenderer;

    public GameObject border;
    
    public int      health =     100;
    public int      damage =     0;
    public float    hitChance =  0;              //0-1
    public int      dodge =      0;
    public float    blightRes =  0;              //0-1
    public float    stunRes =    0;              //0-1
    public float    bleedRes =   0;              //0-1
    public int      initiative = 0;

    public GameObject weapon;
    public GameObject armor;
    

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.GetSiblingIndex();
        UpdateStats();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r") || playerIndex != prevPlayerIndex) {
            UpdateStats();
        }
        if(health <= 0) {
            spriteRenderer.sprite = races.deadSprites[playerIndex];
        }
	}
    
    public void UpdateStats() {
		races.SetClass(playerIndex);

        health = races.health;
        damage = races.damage;
        hitChance = races.hitChance;
        dodge = races.dodge;
        blightRes = races.blightRes;
        stunRes = races.stunRes;
        bleedRes = races.bleedRes;
        initiative = races.initiative;
        
        spriteRenderer.sprite = races.idleSprites[playerIndex];
        playerManager.image.sprite = races.idleSprites[playerIndex];

		prevPlayerIndex = playerIndex;
    }

    void OnMouseDown() {
        playerManager.selected = position;
        playerManager.image.sprite = races.idleSprites[playerIndex];
    }
}
