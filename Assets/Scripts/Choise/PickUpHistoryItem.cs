using UnityEngine;
using System.Collections;

public class PickUpHistoryItem : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public GameObject choiceCanvas;
    public bool isOnArea = false;

    public bool isTaken = false;
    public Sprite[] elementSprites;
    private SpriteRenderer thisRenderer;

    private bool isGoToPosition = false;
    public bool isThereTutorial = false;

    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGoToPosition = true;
        }
        if (isTaken == false)
        {
            thisRenderer.sprite = elementSprites[1];
        }
        if (isTaken == false && isOnArea)
        {
            TakeItOnPosition();
        }
    }

    void TakeItOnPosition()
    {
		if (!GameObject.Find ("CharacterCentralPoint").GetComponent<SimpleControl> ().enabled)
			return;
        if (Input.GetMouseButtonDown(0) || isGoToPosition)
        {
            if (isThereTutorial)
            {
                if (GameObject.Find("TutorialCanvas") != null)
                {
                    GameObject.Find("TutorialCanvas").SetActive(false);
                }
            }
            isGoToPosition = false;
            playerRigidbody.velocity = new Vector2(0, 0);

            choiceCanvas.SetActive(true);

            this.enabled = false;
        }
    }

    void OnMouseExit()
    {
        thisRenderer.sprite = elementSprites[0];
        if (Input.GetMouseButtonDown (0))
            isGoToPosition = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "CharacterCentralPoint")
        {
            isOnArea = true;
            if (!isTaken && isGoToPosition)
                TakeItOnPosition ();
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
