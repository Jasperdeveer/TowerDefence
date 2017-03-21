using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			ToggleMenu();
		}
	}

	public void ToggleMenu(){

		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{ 
			Time.timeScale = 0f;
		}
		else{
			Time.timeScale = 1f;
		}

	}

	public void Retry(){
		ToggleMenu();
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu(){
		SceneManager.LoadScene("MainMenu");
	}
}
