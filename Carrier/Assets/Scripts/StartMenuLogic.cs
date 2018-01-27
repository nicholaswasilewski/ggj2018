using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
		startMenu.StartChoice ("Title Here", startAction, aboutAction);
		//      modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myMaybeAction);
	}


    //  These are wrapped into UnityActions
    void StartFunction () {
      // Logic for starting game here
        displayManager.DisplayMessage ("Starting game");
    }

    void AboutFunction () {
      // Logic for about page here
        displayManager.DisplayMessage ("No way, José!");
    }

}
