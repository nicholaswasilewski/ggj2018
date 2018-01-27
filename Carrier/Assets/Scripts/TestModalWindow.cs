using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myMaybeAction;

    void Awake () {
        modalPanel = ModalPanel.Instance ();
        displayManager = DisplayManager.Instance ();

        myYesAction = new UnityAction (TestYesFunction);
        myNoAction = new UnityAction (TestNoFunction);
        myMaybeAction = new UnityAction (TestMaybeFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void TestYMC () {
        modalPanel.Choice ("Are you a bird?", TestYesFunction, TestNoFunction, TestMaybeFunction);
//      modalPanel.Choice ("Would you like a poke in the eye?\nHow about with a sharp stick?", myYesAction, myNoAction, myMaybeAction);
    }

    //  These are wrapped into UnityActions
    void TestYesFunction () {
        displayManager.DisplayMessage ("Heck yeah! Yup!");
    }

    void TestNoFunction () {
        displayManager.DisplayMessage ("No way, José!");
    }

    void TestMaybeFunction () {
        displayManager.DisplayMessage ("Maybe?!");
    }
}
