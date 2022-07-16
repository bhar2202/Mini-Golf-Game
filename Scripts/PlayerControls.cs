using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControls : MonoBehaviour
{
    public Sprite redBall;
    public Sprite yellowBall;
    public Sprite blueBall;
    public Sprite dogBall;
    public SpriteRenderer ball;
    public GameObject gameplayPanel;
    public GameObject congratsPanel;
    public GameObject aimPivot;
    public GameObject player;
    public Text strokeCounter;
    public Text levelText;
    public Rigidbody2D rigidBody;
    bool inPlay;
    public float force;
    public float drag;
    Vector3 lastVelocity;
    int numStrokes;
    int currentLevel;

    void drawAimLine()
    {
        //finds the distance between the ball and the mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var distance = Vector3.Distance(gameObject.transform.position, mousePosition);
        


        aimPivot.transform.LookAt(mousePosition);
        if(aimPivot.transform.rotation.y > 0)
        {
            aimPivot.transform.Rotate(new Vector3(0, -90, -90));
        } else
        {
            aimPivot.transform.Rotate(new Vector3(0, 90, 90));
        }


        //draws length of line
        if(distance < 10f)
        {
            aimPivot.transform.localScale = new Vector3(1,distance / 10f,1);
        } else
        {
            aimPivot.transform.localScale = new Vector3(1, 1, 1);
        }
        
        
    }

    

    void Start()
    {
        //variable setup
        numStrokes = 0;
        currentLevel = PlayerPrefs.GetInt("Current Level");

        //scene setup
        applyBallImage();
        strokeCounter.text = "00";
        levelText.text = "hole " + currentLevel;
        Time.timeScale = 1.0f;
        player.SetActive(true);
        aimPivot.SetActive(true);
        gameplayPanel.SetActive(true);
        congratsPanel.SetActive(false);
        inPlay = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            //adds a bounce effect when the player hits a wall
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rigidBody.velocity = direction * Mathf.Max(speed, 0f);
            
        }

        if(collision.gameObject.tag == "hole")
        {
            Time.timeScale = 1.0f;
            PlayerPrefs.SetInt("Total Score", PlayerPrefs.GetInt("Total Score") + numStrokes);
            PlayerPrefs.SetInt("level " + currentLevel + " shots", numStrokes);
            player.SetActive(false);
            gameplayPanel.SetActive(false);
            congratsPanel.SetActive(true);

        }
    }

    void applyBallImage()
    {
        string type = PlayerPrefs.GetString("Ball Type");
        if (type.Equals("red"))
        {
            ball.sprite = redBall;
        } else if (type.Equals("blue"))
        {
            ball.sprite = blueBall;
        } else if (type.Equals("yellow"))
        {
            ball.sprite = yellowBall;
        } else if (type.Equals("dog"))
        {
            ball.sprite = dogBall;
        }
    }

    


    void Update()
    {
        lastVelocity = rigidBody.velocity;

        if (!inPlay && Input.GetMouseButtonUp(0))
        {
            numStrokes += 1;

            if(numStrokes < 10)
            {
                strokeCounter.text = "0" + numStrokes;
            } else
            {
                strokeCounter.text = "" + numStrokes;
            }
            

            inPlay = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 distance = mousePosition - gameObject.transform.position;
            //add force to the ball
            rigidBody.AddForce(distance.normalized * force,ForceMode2D.Impulse);
            

        }
        else if (inPlay)
        {
            aimPivot.SetActive(false);
            rigidBody.drag += drag;
        } 

        if(inPlay && rigidBody.velocity.magnitude < 0.01)
        {
            aimPivot.SetActive(true);
            inPlay = false;
            rigidBody.drag = 0;
            rigidBody.velocity = new Vector2(0,0);
        }

        drawAimLine();
        
    }

}
