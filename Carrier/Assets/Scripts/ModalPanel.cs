// Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
	 public void Choice (string question, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent) {
			 modalPanelObject.SetActive (true);

			 yesButton.onClick.RemoveAllListeners();
			 yesButton.onClick.AddListener (yesEvent);
			 yesButton.onClick.AddListener (ClosePanel);

			 noButton.onClick.RemoveAllListeners();
			 noButton.onClick.AddListener (noEvent);
			 noButton.onClick.AddListener (ClosePanel);

			 cancelButton.onClick.RemoveAllListeners();
			 cancelButton.onClick.AddListener (cancelEvent);
			 cancelButton.onClick.AddListener (ClosePanel);

			 this.question.text = question;

			 this.iconImage.gameObject.SetActive (false);
			 yesButton.gameObject.SetActive (true);
			 noButton.gameObject.SetActive (true);
			 cancelButton.gameObject.SetActive (true);
	 }

	 void ClosePanel () {
			 modalPanelObject.SetActive (false);
	 }
}
