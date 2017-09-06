using UnityEngine;
using System.Collections;

public class Stabbing : MonoBehaviour {

    private int stab;

	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (stab == 0)
        {
            GameObject.Find("out").transform.localScale = new Vector3(0, 0, 0);
        }

        else
        {
            GameObject.Find("out").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("in").transform.localScale = new Vector3(1, 1, 1);
            stab = 0;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            stab = 1;
            GameObject.Find("out").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("in").transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
