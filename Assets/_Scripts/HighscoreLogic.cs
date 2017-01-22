using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreLogic : MonoBehaviour {

	public string backToScene;
	public bool useKeyboard;
	public GameObject newHighscorePanel;
	public InputField playerNameInput;
	public HighscoreStore store;
	private bool activeInput;
	private float time;

	// Use this for initialization
	void Start () {
		playerNameInput.characterLimit = 20;
		activeInput = false;
		NewHighscore ();
		time = 1;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time < 1) {
			return;
		}
		bool triggConfirm = false;
		bool triggBack = false;
		bool triggCancel = false;
		if (useKeyboard) {
			if (!activeInput) {
				triggBack = Input.GetAxis ("Submit") == 1;
				triggBack = triggBack || Input.GetAxis ("Cancel") == 1;
			} else {
				triggConfirm = Input.GetAxis ("Submit") == 1 && !Input.GetKeyDown(KeyCode.Space);
				triggCancel = Input.GetAxis ("Cancel") == 1;
			}
		}
		if (activeInput) {
			
			if (triggConfirm) {
				string name = playerNameInput.text;
				name = name.Trim ();
				if (name.Length >= 2) {
					store.AddScore (name, 100);
				}
			}
			if (triggConfirm || triggCancel) {
				activeInput = false;
				playerNameInput.text = "";
				newHighscorePanel.gameObject.SetActive (false);
				time = 0;
			}
		} else if (triggBack) {
			time = 0;
			AutoFade.LoadLevel (backToScene, 1, 1, Color.black);
		}
	}

	public void NewHighscore(){
		activeInput = true;
		newHighscorePanel.transform.SetAsLastSibling ();
		playerNameInput.Select ();
		playerNameInput.ActivateInputField ();
	}
}
