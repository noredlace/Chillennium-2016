using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private bool isGrounded;
    private bool isVisible;

    void Start(){
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        /*
        count = 0;
        SetCountText();
        winText.text = "";
        */
    }

    void FixedUpdate(){
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Camera camera = Camera.current;

        transform.Translate(moveHorizontal*Time.deltaTime*speed, 0f, moveVertical*Time.deltaTime*speed);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 8, 0);

        GameObject.Find("happyRobot").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("angryRobot").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("angryRobotArmsForward").transform.localScale = new Vector3(0, 0, 0);
       // GameObject.Find("angryRobotTray").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("angryRobotstab").transform.localScale = new Vector3(0, 0, 0);

        if ((Input.GetKeyDown(KeyCode.Space) == true) && (isGrounded == true))
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
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

    /*
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    */
}