﻿using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartButton () {
		Application.LoadLevel ("SessionOneScene");
	}

	public void QuitButton () {
		Application.Quit ();
	}
}
