using UnityEngine;
using System.Collections;

public class Floor3Door1Trigger : MonoBehaviour {


    Animator anim;
    GameObject player;
    public GameObject door;
	// Use this for initialization
	void Start () {
        anim = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Boss1"))
        {
            anim.SetBool("Floor3BossEnc", true);
        }
        if (coll.gameObject == player)
        {
            Debug.Log("HITTING THE DOOR");
            anim.SetBool("Floor3Door1Trig", true);
        }

    }

   void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == player)
        {
            Debug.Log("LEAVING THE DOOR");
            anim.SetBool("Floor3Door1Trig", false);
        }


    }
}
