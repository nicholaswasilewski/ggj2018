using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
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

		int the_choice = 0;
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
			if (Input.GetKeyDown(KeyCode.LeftArrow)){
				if (the_choice > 0 && the_choice <= 2 ){
					the_choice = the_choice - 1;
				}
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)){
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
					Debug.Log(the_choice);
					if (the_choice == 0 ){
						yesEvent();
					}
					if (the_choice == 1){
						noEvent();
					}
					if (the_choice == 2){
						maybeEvent();
					}
					ClosePanel();
			}
		}

    // Yes/No/maybe: A string, a Yes event, a No event and maybe event
    public void Choice (string question, UnityAction yesEvent, UnityAction noEvent, UnityAction maybeEvent) {
				the_choice = 0;
				this.yesEvent = yesEvent;
				this.noEvent = noEvent;
				this.maybeEvent = maybeEvent;
				modalPanelObject.SetActive (true);
        this.question.text = question;
        this.iconImage.gameObject.SetActive (false);
        yesButton.gameObject.SetActive (true);
        noButton.gameObject.SetActive (true);
        maybeButton.gameObject.SetActive (true);
    }

    void ClosePanel () {
        modalPanelObject.SetActive (false);
    }
}
