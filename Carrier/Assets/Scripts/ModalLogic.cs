using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

// TODO: make way to store your points
// TODO: make way to get bird_num
// TODO: bird photos

public class ModalLogic : MonoBehaviour {
	private Conversation conversation;
    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    // private UnityAction birdSelect;
		private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myMaybeAction;

	public static ModalLogic Instance;
	int theScore = 0;

    void Awake () {
        modalPanel = ModalPanel.Instance ();
        displayManager = DisplayManager.Instance ();
		Instance = this;
    }
	MasterConversation theConversation;

    //  Send to the Modal Panel to set up the Buttons and Functions to call
	public void birdSelect (int birdNum, Texture2D portrait) {

		modalPanel.iconImage.texture = portrait;

		theConversation = new MasterConversation(birdNum, 1);
		theScore = 0;

		modalPanel.Choice(theConversation.Conversation1, YesAction, NoAction, false);
	}

	void YesAction(){
  	// add 2 points to something
		theScore = theScore + 2;
		NextConversation ();
		displayManager.DisplayMessage ("Right");
	}

	void NoAction(){
	  // Add 0 points
		NextConversation ();
		displayManager.DisplayMessage ("Wrong");
	}

	void NextConversation() {
		Debug.Log ("Current convo: " + theConversation.CurrentConversation);
		int current = theConversation.CurrentConversation;
		int nextCon = current + 1;
		theConversation.CurrentConversation = nextCon;
		Debug.Log("New conversation: " + nextCon);
		Debug.Log("Made it to next conversation");
		switch (nextCon) {
		case 2:
			Debug.Log ("Made it to second switch");
			modalPanel.Choice(theConversation.Conversation2, YesAction, NoAction, false);
			break;
		case 3:
			Debug.Log ("Made it to third switch");
			modalPanel.Choice (theConversation.Conversation3, YesAction, NoAction, true);
			break;
		default:
			GameStats.Instance.SetBirdSeduction (theConversation.BirdNum, theScore >= 3);
			modalPanel.ClosePanel ();
			break;
		}
	}
}
