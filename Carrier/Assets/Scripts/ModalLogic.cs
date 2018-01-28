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

    void Awake () {
        modalPanel = ModalPanel.Instance ();
        displayManager = DisplayManager.Instance ();
		Instance = this;
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void birdSelect (int birdNum) {
		Conversation theConversation = Conversation.makeConversationWithBird(birdNum);
		modalPanel.Choice(theConversation, YesAction, NoAction, MaybeAction);
	}

	void YesAction(){
  // add 2 points to something
		displayManager.DisplayMessage ("Yes!");
	}

	void NoAction(){
  // Add 0 points
		displayManager.DisplayMessage ("Nope");
	}

	void MaybeAction(){
  // Add 1 point
		displayManager.DisplayMessage ("Maybe?");
	}
}
