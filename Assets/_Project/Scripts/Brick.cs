using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

//	[SerializeField]
//	private int maxHits;
	public AudioClip crack;
	public static int breakableBricks = 0;
	public GameObject smokeVFX;

	private int timesHit;
	private float destroyDelay = 0.5f;
	private bool isBreakable;
	private Collider2D coll;
	private SpriteRenderer sRenderer;

	public Sprite[] hitSprites;

	void Awake () {
		Init ();
	}

	void Init() {
		// cache components
		coll = gameObject.GetComponent<Collider2D> ();
		sRenderer = gameObject.GetComponent<SpriteRenderer> ();

		// Set isBreakable and keep track of breakable bricks
		isBreakable = (this.gameObject.tag == "Breakable");
		if (isBreakable) {
			breakableBricks++;
		}

		// set times hit
		timesHit = 0;
	}

	void OnCollisionEnter2D(Collision2D other) {
		AudioSource.PlayClipAtPoint (crack, this.transform.position);

		bool validHit = (other.gameObject.tag == "Ball");

		if (validHit && isBreakable) {
			HandleHits ();
			print ("The number of breakable bricks left is " + breakableBricks);
		}

	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			HandleDestroy ();
		} else {
			LoadSprite ();
		}
	}

	void HandleDestroy() {
		breakableBricks--;
		coll.enabled = false;
		sRenderer.enabled = false;
		GenerateVFX ();
//		Destroy (gameObject, destroyDelay);
		LevelManager.BrickDestroyed ();
	}

	void GenerateVFX() {
		if (smokeVFX != null) {
		smokeVFX.GetComponent<ParticleSystem> ().startColor = sRenderer.color;
		GameObject vfx = Instantiate (smokeVFX, transform.position, Quaternion.identity) as GameObject;
		}
	}

	void LoadSprite() {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			sRenderer.sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Missing sprite in " + this.gameObject.name + "'s hitSprites array at index " + spriteIndex);
		}
	}

	// TODO remove this function once proper win functionality is implemented
//	void SimulateWin () {
//		LevelManager.LoadNextLevel ();
//	}

}
