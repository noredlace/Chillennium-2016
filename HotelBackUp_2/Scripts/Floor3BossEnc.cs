using UnityEngine;
using System.Collections;

public class Floor3BossEnc : MonoBehaviour {

    Animator anim;
    GameObject player;
    public GameObject door;
    // Use this for initialization
    void Start()
    {
        anim = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Floor3BossEnc", true);
            Destroy(GameObject.FindGameObjectWithTag("Cage"));
        }
    
    }
}
