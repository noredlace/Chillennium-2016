using UnityEngine;
using System.Collections;

public class Whack : MonoBehaviour {

    private int whack = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (whack == 0)
        {
            GameObject.Find("down").transform.localScale = new Vector3(0, 0, 0);
        }

        else
        {
            GameObject.Find("down").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("up").transform.localScale = new Vector3(1, 1, 1);
            whack = 0;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            whack = 1;
            GameObject.Find("down").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("up").transform.localScale = new Vector3(0, 0, 0);
        }
	}
}
