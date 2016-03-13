using UnityEngine;
using System.Collections;

public class ChoiseCanvasDisabler : MonoBehaviour {

	public SimpleChoiseBehaviour choise;

	void Update () {
		choise.CloseOff ();
		this.enabled = false;
	}
}
