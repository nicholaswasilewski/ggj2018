using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdState {
	public bool alive;
	public bool seduced;
}

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


	private GameStats() {
		Birds = InitBirds ();
	}


	public BirdState[] InitBirds()
	{
		BirdState[] Birds = new BirdState[BirdsToSeduce];
		for (int i = 0; i < BirdsToSeduce; i++) {
			Birds [i] = new BirdState ();
			Birds [i].alive = true;
			Birds [i].seduced = false;
		}

		return Birds;
	}
}
