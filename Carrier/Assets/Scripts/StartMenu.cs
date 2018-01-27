using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StartMenu : MonoBehaviour {

    public Text title;
    public Image iconImage;
    public Button startButton;
    public Button aboutButton;
    public GameObject startMenuObject;
		public GameObject startHighlightObject;
		public GameObject aboutHighlightObject;

		int the_choice = 0;
		UnityAction startEvent;
		UnityAction aboutEvent;

		private static StartMenu startMenu;

		public static StartMenu Instance () {
        if (!startMenu) {
            startMenu = FindObjectOfType(typeof (StartMenu)) as StartMenu;
            if (!startMenu)
                Debug.LogError ("There needs to be one active StartMenu script on a GameObject in your scene.");
        }

        return startMenu;
    }

		void Update() {
			if (Input.GetKeyDown(KeyCode.LeftArrow)){
				if (the_choice > 0 && the_choice <= 1 ){
					the_choice = the_choice - 1;
				}
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)){
				if (the_choice >= 0 && the_choice < 1 ){
					the_choice = the_choice + 1;
				}
			}
			if (the_choice == 0 ){
				startHighlightObject.gameObject.SetActive (true);
				aboutHighlightObject.gameObject.SetActive (false);
			} else if (the_choice == 1){
				startHighlightObject.gameObject.SetActive (false);
				aboutHighlightObject.gameObject.SetActive (true);
			}

			if (Input.GetKeyDown(KeyCode.Return)) {
				//activate selection
					if (the_choice == 0 ){
						ClosePanel();
						startEvent();
					}
					if (the_choice == 1){
						aboutEvent();
					}
			}
		}

    // Yes/No/maybe: A string, a Yes event, a No event and maybe event
    public void StartChoice (string title, UnityAction startEvent, UnityAction aboutEvent) {
				the_choice = 0;
				this.startEvent = startEvent;
				this.aboutEvent = aboutEvent;
				startMenuObject.SetActive (true);
        this.title.text = title;
        this.iconImage.gameObject.SetActive (true);
        startButton.gameObject.SetActive (true);
        aboutButton.gameObject.SetActive (true);
    }

    void ClosePanel () {
        startMenuObject.SetActive (false);
    }
}
