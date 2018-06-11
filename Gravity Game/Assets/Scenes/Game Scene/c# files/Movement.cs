using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public int score = 0;
	public int highscore = 0;
    public Text scoreCount;
    public Text highScoreCount;
	public int highScore = 0;
	public int speed = 10;
	//public GameObject displayScore;
	public GameObject jewel;
	private bool right = true;
	private float moveX;

	void Start(){
		addJewel ();

        highScoreCount.text = "High Score: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		movePlayer ();
	}

	void movePlayer(){
		moveX = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump")) {
			//Debug.Log ("!");
			if (gameObject.GetComponent<Rigidbody2D> ().position.y < -4 || gameObject.GetComponent<Rigidbody2D> ().position.y > 4) {
				flipY ();
			} else {
				addJewel ();
			}
		}

		if (moveX < 0.0f && right) {
			flipX ();
		}

		else if(moveX > 0.0f && !right){
			flipX ();
		}

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void flipX(){
		right = !right;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void flipY(){
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = -gameObject.GetComponent<Rigidbody2D> ().gravityScale;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.y *= -1;
		transform.localScale = localScale;
	}

	void addJewel(){
		Instantiate (jewel, new Vector2 (Random.Range(-7.0f, 7.0f),Random.Range(-4.0f, 4.0f)),Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D trig){
		//Debug.Log ("!");
		if (trig.gameObject.tag == "JewelTag"){
			//Debug.Log ("!!");
			score += 10;
            SetCountText();

			//displayScore.gameObject.GetComponent<Text> ().text = "" + score;
			addJewel ();
			Destroy (trig.gameObject);
		}
		if (trig.gameObject.tag == "ParrotTag") {
			Debug.Log ("You're dead.");
			score = 0;
            SetCountText();
			//Get game to restart properly
		}
	}
    void SetCountText(){
        scoreCount.text = "Score: " + score.ToString();

        if(score > PlayerPrefs.GetInt("Highscore", 0)){
            PlayerPrefs.SetInt("Highscore", score);
            highScoreCount.text = "High Score: " + score.ToString();
        }
    }
}
