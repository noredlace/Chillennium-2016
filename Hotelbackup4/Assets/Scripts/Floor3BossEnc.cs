using UnityEngine;
using System.Collections;

public class Floor3BossEnc : MonoBehaviour {

    Animator anim;
    GameObject player;
    GameObject[] cageWall;
    public GameObject door;
    // Use this for initialization
    void Start()
    {
        anim = door.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        cageWall = GameObject.FindGameObjectsWithTag("Cage");
        
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
            foreach (GameObject Cage in cageWall) {
                Debug.Log("Iterating foreach Loop");
                //Destroy(GameObject.FindGameObjectWithTag("Cage"));
                GameObject.Destroy(Cage);
            }
        }
    
    
    }
}
