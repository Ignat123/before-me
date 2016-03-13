using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiaryActivator : MonoBehaviour {

	private Canvas diaryCanvas;
	private bool isEnabled = false;
	private SimpleControl control;

	void Start () {
		diaryCanvas = GameObject.Find ("DiaryCanvas").GetComponent<Canvas> ();
		control = GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ();
		this.enabled = false;
	}

	public void Turn () {
		if (!isEnabled && !control.enabled)
			return;
		isEnabled = !isEnabled;
		if (isEnabled) {
			GameObject.Find ("CharacterCentralPoint").GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
			control.enabled = false;
			diaryCanvas.enabled = true;
            GameObject.Find("Diary").GetComponent<Animator>().SetBool("NewEntry", false);
		} else {
			control.enabled = true;
			diaryCanvas.enabled = false;
		}
	}
}
