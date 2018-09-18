using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject sceneController;

    public float laneWidth = 2;
    int lane = 0;

    public int playerHealthMax = 3;
    int playerHealth;

    bool isGrounded = true;
    bool hasJetpack = false;

    float playerHeight = 0;
    public int jumpHeight = 2;
    public int gravity = -2;

    void Start () {
        if (!sceneController) return;
        playerHealth = playerHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Horizontal"))
        {
            if (h == -1) // if pressing left
            {
                lane--;
            }
            else if (h == 1) // if pressing right
            {
                lane++;
            }
            lane = Mathf.Clamp(lane, -1, 1);
        }

        

        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Vertical"))
        {
            if(v == 1) //if pressing up
            {
                if(isGrounded != false)
                {
                    playerHeight += jumpHeight;
                    isGrounded = false;
                }
            }   
        }

        float targetX = lane * laneWidth;
        float x = (targetX - transform.position.x) * .1f;

        float y = (playerHeight - transform.position.y) * .1f;

        transform.position += new Vector3(x, y, 0);

        if (!isGrounded && !hasJetpack)
        {
            playerHeight -= gravity *.1f;
        }
    }

    void JetpackDepleted()
    {
        hasJetpack = false;
    }

    void OnOverlappingAABB(ObjectAABB other)
    {
        if(other.tag == "Powerup")
        {
            //it must be a powerup...
            Powerup powerup = other.GetComponent<Powerup>();
            switch (powerup.type)
            {
                case Powerup.Type.None:
                    break;
                case Powerup.Type.Slowmo:
                    //set timer in SceneController to start counting down slowmo time.
                    sceneController.BroadcastMessage("SetSlowmoTimer");
                    break;
                case Powerup.Type.Health:
                    playerHealth++;
                    if (playerHealth >= playerHealthMax) playerHealth = playerHealthMax;
                    print("Player's Health is at: " + playerHealth);
                    break;
                case Powerup.Type.JetpackBoost:
                    playerHeight = jumpHeight * 1.2f;
                    hasJetpack = true;
                    isGrounded = false;
                    sceneController.BroadcastMessage("PlayerHasJetpack");
                    break;
                case Powerup.Type.Wall:
                    playerHealth--;
                    print("Player's Health is at: " + playerHealth);
                    if (playerHealth <= 0) sceneController.BroadcastMessage("PlayerDead");
                    break;
            }
            Destroy(other.gameObject);
        }
        if(other.tag == "Ground")
        {
            //it must be the ground...
            isGrounded = true;
            playerHeight = 0;
        }
    }
}
