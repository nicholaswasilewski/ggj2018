using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdState {
	public bool alive;
	public bool seduced;
}

public enum BirdType {
	Turkey = 1,
	Eagle = 2,
	Wren = 3,
	Parrot = 4,
	Ostrich = 5,
	Emu = 6,
};

public class GameStats {
	public static GameStats instance = null;
	public static GameStats Instance {
		get {
			if (instance == null) {
				instance = new GameStats ();
			}
			return instance;
		}

		set {
			instance = value;
		}
	}

	public static void Clear()
	{
		instance = new GameStats();
	}
		
	public const int BirdsToSeduce = 6;
	public BirdState[] Birds;

	public int RunCount;


	private GameStats() {
		Birds = InitBirds ();
		RunCount = 0;
	}


	public BirdState[] InitBirds()
	{
		BirdState[] Birds = new BirdState[BirdsToSeduce];
		for (int i = 0; i < BirdsToSeduce; i++) {
			Birds [i] = new BirdState ();
			Birds [i].alive = true;
		}

		return Birds;
	}

	public void KillBird(BirdType birdType) {
		Birds [(int)birdType - 1].alive = false;
	}

	public void SetBirdSeduction(int birdNumber, bool seductionState) {
		Birds [birdNumber - 1].seduced = seductionState;
	}
}
