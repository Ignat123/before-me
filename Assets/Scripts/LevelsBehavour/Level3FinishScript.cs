using UnityEngine;
using System.Collections;

public class Level3FinishScript : MonoBehaviour {

	private Transform playerPoint;
	public GameObject door;
	private SimpleControl control;
	private float speed = 3f;

	void Start () {
		playerPoint = GameObject.Find ("CharacterCentralPoint").transform;
		control = GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ();
		control.enabled = false;
		GameObject.Find ("Player").GetComponent<Animator> ().Play ("Flying");
		if (door.transform.position.x < playerPoint.transform.position.x && control.isFacedRight
		    || door.transform.position.x > playerPoint.transform.position.x && !control.isFacedRight)
			control.Flip ();
		GameObject.Find ("CharacterCentralPoint").GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		door.GetComponent<Animator>().enabled = true;
	}

	void Update () {
		float step = speed * Time.deltaTime;
		playerPoint.position = Vector3.MoveTowards(playerPoint.position, door.transform.position, step);
		if (playerPoint.position == door.transform.position) {
			GameObject.Find ("Player").GetComponent<SetLightOff> ().enabled = true;
			GameObject.Find ("BlackGround").GetComponent<SetLightOn> ().enabled = true;
			this.enabled = false;
		}
	}
}
