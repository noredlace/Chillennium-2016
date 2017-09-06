using UnityEngine;
using System.Collections;

public class Floor3Door1Trigger : MonoBehaviour {

    bool showText = true;
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
            showText = true;
            anim.SetBool("Floor3BossEnc", true);
        }
        if (coll.gameObject == player)
        {
            Debug.Log("HITTING THE DOOR");
            anim.SetBool("Floor3Door1Trig", true);
        }
        if (coll.gameObject.CompareTag("FirstEnemy")) ;
        {
            Color color;
            color = new Color(0.5F, 0F, 0F);

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Walls");
            foreach (GameObject go in objects)
            {
                MeshRenderer[] renderers = go.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in renderers)
                {
                    foreach (Material m in r.materials)
                    {
                        if (m.HasProperty("_Color"))
                            m.color = color;
                    }

                }

            }
        }
    }
    
  void OnGUI(Collider coll)
    {
 
            GUI.Button(new Rect(10, 10, 200, 50), "Welcome TreyBot to your new home! \n You have been uniquely created to care after the people and rooms of this hotel. You are truly one of a kind. Make your way down to Floor 1" );
          
        
    }
}
