using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    public AudioClip audioClip;
    public AudioSource source;
    public SimpleControl playerControl;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public bool isOnArea = false;
    public MonoBehaviour[] afterTakenScripts;
    public MonoBehaviour[] startScripts;
    public Sprite[] elementSprites;
    public MonoBehaviour successScript;
    private SpriteRenderer thisRenderer;
    private PlayAudio bedToyScript;
    private PlayAudio bearScript;
    private PlayAudio horseScript;
	private bool isEnabled = false;

    void Start()
    {
        //thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        //thisRenderer.sprite = elementSprites[0];
    }

    void OnMouseOver()
    {
		//Debug.Log ("OnMouseOver");
        //thisRenderer.sprite = elementSprites[1];
        if (!source.isPlaying && isOnArea)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.Play("Take", -1, 0);
                playerRigidbody.velocity = new Vector2(0, 0);
                source.PlayOneShot(audioClip);
				if (!isEnabled) {
					playerControl.enabled = false;
					isEnabled = true;
				}
                if (this.gameObject.name == "Box")
                {
                    this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 50);
                }

                bedToyScript = GameObject.Find("BedToy").GetComponent<PlayAudio>();
                bearScript = GameObject.Find("Bear").GetComponent<PlayAudio>();
                horseScript = GameObject.Find("ToyCar").GetComponent<PlayAudio>();

                if (bedToyScript.source.isPlaying && bearScript.source.isPlaying && horseScript.source.isPlaying)
                {
                    successScript.enabled = true;
                } else
				{
					foreach (MonoBehaviour script in startScripts)
						script.enabled = true;
                    GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = false;
                }
            }
        }
    }

    void CloseCanvas()
    {
        GameObject.Find("SpeachCanvas").GetComponent<Canvas>().enabled = false;
    }

    void OnMouseExit()
    {
		//Debug.Log ("OnMouseExit");
        //thisRenderer.sprite = elementSprites[0];
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CharacterCentralPoint")
        {
            isOnArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CharacterCentralPoint")
        {
            isOnArea = false;
        }
    }
}
