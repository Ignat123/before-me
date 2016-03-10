using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {

	public Sprite normal;
	public Sprite highlited;

	private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
		this._renderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		this._renderer.sprite = this.highlited;
	}

	void OnMouseExit() 
	{
		this._renderer.sprite = this.normal;
	}
}
