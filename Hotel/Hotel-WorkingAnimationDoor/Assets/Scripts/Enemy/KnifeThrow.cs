﻿using UnityEngine;
using System.Collections;

public class KnifeThrow : MonoBehaviour {

    public float expiryTime = 0f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, expiryTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
