using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour {

    public Text question;
    public Image iconImage;
    public Button yesButton;
    public Button noButton;
    public Button maybeButton;
    public GameObject modalPanelObject;
		public GameObject yesHighlightObject;
		public GameObject noHighlightObject;
		public GameObject maybeHighlightObject;

	bool isLastTime = false;
		int the_choice = 0;
		int response = 0;
		int theScore = 0; 
		UnityAction yesEvent;
		UnityAction noEvent;
		UnityAction maybeEvent;

		private static ModalPanel modalPanel;

    public static ModalPanel Instance () {
        if (!modalPanel) {
            modalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			if (the_choice > 0 && the_choice <= 2 ){
				the_choice = the_choice - 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			if (the_choice >= 0 && the_choice < 2 ){
				the_choice = the_choice + 1;
			}
		}
		if (the_choice == 0 ){
			yesHighlightObject.gameObject.SetActive (true);
			noHighlightObject.gameObject.SetActive (false);
			maybeHighlightObject.gameObject.SetActive (false);
		} else if (the_choice == 1){
			yesHighlightObject.gameObject.SetActive (false);
			noHighlightObject.gameObject.SetActive (true);
			maybeHighlightObject.gameObject.SetActive (false);
		}
		else{
			yesHighlightObject.gameObject.SetActive (false);
			noHighlightObject.gameObject.SetActive (false);
			maybeHighlightObject.gameObject.SetActive (true);
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			//activate selection
			Debug.Log("the choice: " + the_choice);
			Debug.Log("the response: " + response);
			if (the_choice == response ){
				yesEvent();
				if (isLastTime == true) {
					ClosePanel ();
				}
			}
			else {
				noEvent();
				if (isLastTime) {
					ClosePanel ();
				}
			}
		}
	}

    // Yes/No/maybe: A string, a Yes event, a No event and maybe event
    public void Choice (Conversation theConversation, UnityAction yesEvent,
		UnityAction noEvent, UnityAction maybeEvent, bool lastTime
		) {
		bool isLastTime = lastTime;
		// needs to be set for the particular object
			// conversation 1
		// check state then activate.
		Debug.Log("==========");
		Debug.Log(theConversation.Question);
		Debug.Log(theConversation.Answer1);
		Debug.Log(theConversation.Answer2);
		Debug.Log(theConversation.Answer3);
		Debug.Log (theConversation.CorrectAnswer);
			the_choice = 0;
			this.yesEvent = yesEvent;
			this.noEvent = noEvent;
			this.maybeEvent = maybeEvent;
			modalPanelObject.SetActive (true);
			this.question.text = theConversation.Question;
			yesButton.gameObject.GetComponentsInChildren<UnityEngine.UI.Text> () [0].text = theConversation.Answer1;
			noButton.gameObject.GetComponentsInChildren<Text>()[0].text = theConversation.Answer2;
			maybeButton.gameObject.GetComponentsInChildren<Text>()[0].text = theConversation.Answer3;
			response = theConversation.CorrectAnswer;
			this.iconImage.gameObject.SetActive (false);
			yesButton.gameObject.SetActive (true);
			noButton.gameObject.SetActive (true);
			maybeButton.gameObject.SetActive (true);
		Debug.Log (isLastTime);

    }

    public void ClosePanel () {
		Debug.Log ("Closing Panel");
        modalPanelObject.SetActive (false);
    }
}
