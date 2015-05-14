﻿using UnityEngine;
using System.Collections;

public class CustomTitleScript : MonoBehaviour {

    //logic
    public bool finished;
    public int titleDuration;
    private float titleStart;
    public System.Action setupNextPhase;
    private int lastChar;
    private float loadCharTimer;
    public float charLoadInterval;
    private bool loading;

    //information
    private string title;
    private string loadedText;
    private char[] charsToShow;

    //formating
    public int titleLateralPadding;
    public int titleRectHeight;
    public GUIStyle titleFormat;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (lastChar < charsToShow.Length && (Time.time - loadCharTimer) > charLoadInterval)
        {
            //load another char
            loadedText += charsToShow[lastChar++];
            //check if loading is done
            if (lastChar == charsToShow.Length)
            {
                titleStart = Time.time; // start final countdown
                loading = false;
            }
            loadCharTimer = Time.time;
        }
        if (loading || ((Time.time - titleStart) < titleDuration && !finished))
        {   
            GUI.Label(
                    new Rect(titleLateralPadding, Screen.height / 2 - titleRectHeight / 2, Screen.width - titleLateralPadding * 2, titleRectHeight),
                    loadedText,
                    titleFormat);
        }
        else
        {
            finished = true;
        }
    }

    public void Setup(System.Action _nextPhase, string _title){
        setupNextPhase = _nextPhase;
        finished = false;
        title = _title;
        lastChar = 0;
        charsToShow = title.ToCharArray();
        loading = true;
        loadedText = "";
        loadCharTimer = Time.time;
    }
}
