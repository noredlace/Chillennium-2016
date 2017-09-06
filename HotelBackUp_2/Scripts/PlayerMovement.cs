using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

    //GameObject WallMat;
    //Material material2;
    public float speed;
    public float jumpHeight;
    public Text EndText;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isAngry = false;
    public string FloorLevel;


	// Use this for initialization
	void Start () {
       rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        EndText.GetComponent<Text>();
        EndText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(moveHorizontal * Time.deltaTime * speed, 0f, moveVertical * Time.deltaTime * speed);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 8, 0);

        if ((Input.GetKeyDown(KeyCode.Space)== true) && (isGrounded == true))
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);

           
        }
        if ((Input.GetKeyDown(KeyCode.F) == true))
        {
            isAngry = !isAngry;
            if (isAngry)
            {
                changeWallColor(isAngry);
               /* Color color = Color.red;
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
                }*/
            }
            else
            {
                changeWallColor(isAngry);

            }
        }
    }

void changeWallColor (bool Angry)

    {
        Color color;
        if (Angry)
        {
            color = new Color(0.5F, 0.0F, 0.0F);
        }
    else
        {
            color = new Color(0.6F, 1.0F, 0.4F);
        }
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
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Doors"))
        {
            collide.gameObject.SetActive(false);
        }
        if (collide.gameObject.CompareTag("EndLevel"))
        {
            EndText.text = "You completed level 1";
            Application.LoadLevel(FloorLevel);
        }
    }




    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject && isGrounded == false)
        {
            isGrounded = true;
        }

    }

    void onCollisionExit(Collision coll)
    {
        isGrounded = false;
    }
}
