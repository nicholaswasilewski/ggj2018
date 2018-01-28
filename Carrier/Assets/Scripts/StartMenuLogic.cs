using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StartMenuLogic : MonoBehaviour {
    private StartMenu startMenu;
    private DisplayManager displayManager;

    public UnityAction startAction;
    public UnityAction aboutAction;

    void Awake () {
        startMenu = StartMenu.Instance ();
        displayManager = DisplayManager.Instance ();

        startAction = new UnityAction (StartFunction);
      	aboutAction = new UnityAction (AboutFunction);
		StartThings ();
    }

	public void StartThings () {
		startMenu.StartChoice ("Wing Buddies", startAction, aboutAction);
	}


    //  These are wrapped into UnityActions
    void StartFunction () {
      // Logic for starting game here
        displayManager.DisplayMessage ("Starting on your bird journey");
		GameStats.Clear ();
		SceneManager.LoadScene("scene2");
    }

    void AboutFunction () {
      // Logic for about page here
		startMenu.StartChoice ("Andrew Davis \n Greg Weaver \n Brandon Walsh\n Nicholas Wasilewski", startAction, aboutAction);
    }

}
