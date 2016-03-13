using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {

	public Sprite normal;
	public Sprite highlited;

	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
        renderer.sprite = this.highlited;
	}

	void OnMouseExit() 
	{
		renderer.sprite = this.normal;
	}
}
