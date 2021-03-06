﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	public GameObject mover;
	public int movementAmt =1;
	public Vector3 startingPosition;
	public GameObject winSpot;
	public GameObject Enemy;
	public GameObject Trap;
	public GameObject[] enemies; 
	public GameObject bg;
	public float enemySpeed = 1.0f;
	public AudioSource testSound;
	public AudioClip boomSound;
	public AudioClip test2;





	// Use this for initialization
	void Start () {
		startingPosition = 
			mover.transform.position;
	}
		
	
	// Update is called once per frame
	void Update () {

		// check is mover's transform.position.* is beyond each threshold
		if (mover.transform.position.z < -4 || // is it behind the grid?
		    mover.transform.position.z > 4 || // is it too far off the grid?
		    mover.transform.position.x < -4 || // is it too far to the left of the grid?
		    mover.transform.position.x > 5) { // is it too far to the right of the grid?
			mover.transform.position = startingPosition; // is any of these are true....reste it's position to the startingPosition.
		}


		if (mover.transform.position ==
		    new Vector3 (winSpot.transform.position.x,
			    mover.transform.position.y,
			    winSpot.transform.position.z)) {
			Debug.Log ("win");
			mover.GetComponent<MeshRenderer> ().material.color = Color.cyan;
			newLevel ();
			//mover.transform.localScale *= 1.01f;
		}




		if (mover.transform.position == Enemy.transform.position){
			mover.transform.position = startingPosition;
			testSound.PlayOneShot (boomSound, 0.7f);
			}




		if (mover.transform.position == Trap.transform.position) {
			mover.transform.position = startingPosition;
			testSound.PlayOneShot (test2, 0.7f);

		}
		




		for (int i = 0; i < enemies.Length; i++) {
			if (mover.transform.position ==
			    enemies [i].transform.position) {
				mover.transform.position = startingPosition;
			}
		}
		
		    





      
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Debug.Log ("Space bar pressed down");
			mover.transform.position += new Vector3 (0,0,-movementAmt);
		} else {
			Debug.Log ("false");
		}
	

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Debug.Log ("Space bar pressed down");
			mover.transform.position += new Vector3 (0,0,movementAmt);
		} else {
			Debug.Log ("false");
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Debug.Log ("Left Arrow pressed down");
			mover.transform.position += new Vector3 (movementAmt, 0, 0);
		} else {
			Debug.Log ("false");
		}


	
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Debug.Log ("Space bar pressed down");
			mover.transform.position += new Vector3 (-movementAmt, 0, 0);
		} else {
			Debug.Log ("false");
		}
	
		}

	void newLevel(){
		mover.transform.position = startingPosition;
		mover.GetComponent<MeshRenderer> ().material.color = new
			Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1f);
		bg.GetComponent<MeshRenderer> ().material.color 
		= new
			Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1f);
		enemySpeed += 1.0f;

		for (int i = 0; i < enemies.Length; i++) {
			enemies [i].transform.position = new Vector3 (Random.Range (-2, 3), enemies [i].transform.position.y, Random.Range (1, 6));
		}
	}






}

