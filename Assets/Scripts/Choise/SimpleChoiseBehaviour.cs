using UnityEngine;
using UnityEngine.UI;

public class SimpleChoiseBehaviour : MonoBehaviour {

    public SimpleControl playerControl;
    public PickUpHistoryItem[] disableObjects;
	public Text choiseText;
	public string choiseQuestionString;
	public SetLightOn[] lightOnScripts;
	public SetLightOff[] lightOffScripts;
	public MonoBehaviour positiveBehaviour;
    public GameObject canvas;
	//public MonoBehaviour negativeBehaviour;

	void Start () {
        playerControl.enabled = false;
		choiseText.text = choiseQuestionString;
	}

	public void PositiveAction() {
		ActionCommonPart ();
		positiveBehaviour.enabled = true;
        playerControl.enabled = true;
        foreach (PickUpHistoryItem obj in disableObjects)
        {
            obj.isTaken = true; 
        }
	}

	public void NegativeAction() {
		ActionCommonPart ();
        playerControl.enabled = true;
		//negativeBehaviour.enabled = true;
	}

	public void ActionCommonPart() {
		foreach (SetLightOn lightOnScript in lightOnScripts)
			lightOnScript.enabled = false;
		foreach (SetLightOff lightOffScript in lightOffScripts)
			lightOffScript.enabled = true;
        //canvas.SetActive(false);
	}

	public void CloseOff() {
		foreach (SetLightOff lightOffScript in lightOffScripts)
			lightOffScript.enabled = false;
		foreach (SetLightOn lightOnScript in lightOnScripts)
			lightOnScript.enabled = true;
		canvas.SetActive (false);
	}
}
