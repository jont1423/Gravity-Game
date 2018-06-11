using UnityEngine;
using System.Collections;

public class Parrots : MonoBehaviour {

	public GameObject parrot;
	//private bool parrotPresent = false;

	// Use this for initialization
	void Start () {
		Instantiate (parrot, new Vector2 (7.35f,Random.Range(-4.0f, 4.0f)),Quaternion.identity);
		//parrotPresent = true;
	}
	
	// Update is called once per frame
	//void Update () {
		//Instantiate (parrot, new Vector2 (7.35f,Random.Range(-4.0f, 4.0f)),Quaternion.identity);
	//}
}
