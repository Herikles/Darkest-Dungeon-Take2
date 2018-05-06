using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {

	public static void SavePlayer(Character[] player, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Create);

		PlayerData data = new PlayerData (player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void SaveEnemy(EnemyCharacter[] enemy, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Create);

		EnemyData data = new EnemyData (enemy);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void SaveGameData(FightManager fightManager, int saveslot) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav", FileMode.Create);
		GameProgress data = new GameProgress (fightManager);
		bf.Serialize (stream, data);
		stream.Close();
		Debug.Log ("Data saved to slot " + saveslot);
	}

	public static float[] LoadPlayer(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Player.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
			if (position == 0)
				return data.stats0;
			if (position == 1)
				return data.stats1;
			if (position == 2)
				return data.stats2;
			if (position == 3)
				return data.stats3;
			else
				return new float[6];
			
		} else {
			Debug.LogError ("File not found");
			return new float[6]; 
		}
	}
	public static float[] LoadEnemy(int position, int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "Enemy.sav", FileMode.Open);

			EnemyData data = bf.Deserialize (stream) as EnemyData;

			stream.Close ();
			if (position == 0)
				return data.stats0;
			else if (position == 1)
				return data.stats1;
			else if (position == 2)
				return data.stats2;
			else if (position == 3)
				return data.stats3;
			else {
				return new float[10];
			}

		} else {
			Debug.LogError ("File not found");
			return new float[6]; 
		}
	}

	public static float[] LoadGameData(int saveslot) {
		if (File.Exists (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/slot" + saveslot.ToString() + "GameData.sav", FileMode.Open);
			GameProgress data = bf.Deserialize (stream) as GameProgress;
			stream.Close ();

			Debug.Log ("Data loaded from slot " + saveslot);
			return data.gameData;
		} else {
			return new float[6];
		}
	}
}

[Serializable]
public class GameProgress {
	public float[] gameData;

	public GameProgress(FightManager fightManager) {
		gameData = new float[10];
		gameData [0] = fightManager.wave;
		gameData [1] = fightManager.gold;
		gameData [2] = fightManager.volume;
	}
}

[Serializable]
public class PlayerData {
	public float[] stats0;
	public float[] stats1;
	public float[] stats2;
	public float[] stats3;

	public PlayerData(Character[] player) {
		stats0 = new float[10];
		stats0 [0] = player [0].health;
		stats0 [1] = player [0].damage;
		stats0 [2] = player [0].dodge;
		stats0 [3] = player [0].initiative;
		stats0 [4] = player [0].playerIndex;
		stats0 [5] = player [0].position;
		stats0 [6] = player [0].hitChance;
		stats0 [7] = player [0].blightRes;
		stats0 [8] = player [0].stunRes;
		stats0 [9] = player [0].bleedRes;

		stats1 = new float[10];
		stats1 [0] = player [1].health;
		stats1 [1] = player [1].damage;
		stats1 [2] = player [1].dodge;
		stats1 [3] = player [1].initiative;
		stats1 [4] = player [1].playerIndex;
		stats1 [5] = player [1].position;
		stats1 [6] = player [1].hitChance;
		stats1 [7] = player [1].blightRes;
		stats1 [8] = player [1].stunRes;
		stats1 [9] = player [1].bleedRes;

		stats2 = new float[10];
		stats2 [0] = player [2].health;
		stats2 [1] = player [2].damage;
		stats2 [2] = player [2].dodge;
		stats2 [3] = player [2].initiative;
		stats2 [4] = player [2].playerIndex;
		stats2 [5] = player [2].position;
		stats2 [6] = player [2].hitChance;
		stats2 [7] = player [2].blightRes;
		stats2 [8] = player [2].stunRes;
		stats2 [9] = player [2].bleedRes;

		stats3 = new float[10];
		stats3 [0] = player [3].health;
		stats3 [1] = player [3].damage;
		stats3 [2] = player [3].dodge;
		stats3 [3] = player [3].initiative;
		stats3 [4] = player [3].playerIndex;
		stats3 [5] = player [3].position;
		stats3 [6] = player [3].hitChance;
		stats3 [7] = player [3].blightRes;
		stats3 [8] = player [3].stunRes;
		stats3 [9] = player [3].bleedRes;
	}
}

[Serializable]
public class EnemyData {
	public float[] stats0;
	public float[] stats1;
	public float[] stats2;
	public float[] stats3;

	public EnemyData(EnemyCharacter[] enemy) {
		stats0 = new float[10];
		stats0 [0] = enemy [0].health;
		stats0 [1] = enemy [0].damage;
		stats0 [2] = enemy [0].dodge;
		stats0 [3] = enemy [0].initiative;
		stats0 [4] = enemy [0].enemyIndex;
		stats0 [5] = enemy [0].position;
		stats0 [6] = enemy [0].hitChance;
		stats0 [7] = enemy [0].blightRes;
		stats0 [8] = enemy [0].stunRes;
		stats0 [9] = enemy [0].bleedRes;

		stats1 = new float[10];
		stats1 [0] = enemy [1].health;
		stats1 [1] = enemy [1].damage;
		stats1 [2] = enemy [1].dodge;
		stats1 [3] = enemy [1].initiative;
		stats1 [4] = enemy [1].enemyIndex;
		stats1 [5] = enemy [1].position;
		stats1 [6] = enemy [1].hitChance;
		stats1 [7] = enemy [1].blightRes;
		stats1 [8] = enemy [1].stunRes;
		stats1 [9] = enemy [1].bleedRes;

		stats2 = new float[10];
		stats2 [0] = enemy [2].health;
		stats2 [1] = enemy [2].damage;
		stats2 [2] = enemy [2].dodge;
		stats2 [3] = enemy [2].initiative;
		stats2 [4] = enemy [2].enemyIndex;
		stats2 [5] = enemy [2].position;
		stats2 [6] = enemy [2].hitChance;
		stats2 [7] = enemy [2].blightRes;
		stats2 [8] = enemy [2].stunRes;
		stats2 [9] = enemy [2].bleedRes;

		stats3 = new float[10];
		stats3 [0] = enemy [3].health;
		stats3 [1] = enemy [3].damage;
		stats3 [2] = enemy [3].dodge;
		stats3 [3] = enemy [3].initiative;
		stats3 [4] = enemy [3].enemyIndex;
		stats3 [5] = enemy [3].position;
		stats3 [6] = enemy [3].hitChance;
		stats3 [7] = enemy [3].blightRes;
		stats3 [8] = enemy [3].stunRes;
		stats3 [9] = enemy [3].bleedRes;
	}
}
