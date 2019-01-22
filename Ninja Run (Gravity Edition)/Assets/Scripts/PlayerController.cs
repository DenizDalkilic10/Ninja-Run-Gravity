using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidBody;
    private int anim_Index;
    private float horizontal_speed;
    private float vertical_speed;
    private enum State {on_Ground, on_Ceiling, on_Air };
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        anim_Index = 0;
        horizontal_speed = 7;
        vertical_speed = 10;
        state = State.on_Ground;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void FixedUpdate()
    {
        //Move Object with Constant Speed
        if (!GameController.paused)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontal_speed);

            if (state == State.on_Air)
            {
                transform.Translate(Vector3.down * Time.deltaTime * vertical_speed);
            }
        }


        //Temporary Start Signal
        //if (Input.GetButtonDown("Vertical"))
        //{
        //    GameController.paused = !GameController.paused;
        //    if (GameController.paused)
        //        anim_Index = 0;
        //    else
        //        anim_Index = 1;
        //}

        ////will be deleted
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    if (anim_Index != 2)
        //        anim_Index++;
        //    else
        //        anim_Index = 0;
        //    anim.SetInteger("state",anim_Index);
        //}

        //right side of the screen
        //if (Input.GetButtonDown("Jump") && state != State.on_Air) {
        //    rigidBody.gravityScale = 0;
        //    if (state == State.on_Ground) {
        //        transform.rotation = Quaternion.Euler(0, 180, 180);
        //    }
        //    else if (state == State.on_Ceiling)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //    }
        //    state = State.on_Air;
        //}

        //left side of the screen
        //sliding animation
        //if (Input.GetMouseButtonDown(0))
        //{
        //    anim.SetInteger("state",3);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    anim.SetInteger("state", 1);
        //}

        if (Input.touchCount > 0)
        {
            // touch x position is bigger than half of the screen, moving right
            if (Input.GetTouch(0).position.x > Screen.width / 2 && state != State.on_Air)
            {
                rigidBody.gravityScale = 0;
                if (state == State.on_Ground)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 180);
                }
                else if (state == State.on_Ceiling)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                state = State.on_Air;
            }
            // touch x position is smaller than half of the screen, moving left
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                GameController.paused = !GameController.paused;
                if (GameController.paused)
                {
                    //anim_Index = 0;
                }
                else
                    anim_Index = 1;
                anim.SetInteger("state", anim_Index);
            }
        }

        if (state != State.on_Air)
        {
            if (state == State.on_Ground)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (state == State.on_Ceiling)
                transform.rotation = Quaternion.Euler(0, 180, 180);


        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("coin"))
        {
            GameController.coins++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Equals("Ceiling"))
        {
            rigidBody.gravityScale = -3;
            state = State.on_Ceiling;
        }
        else if (collision.gameObject.name.Equals("Ground"))
        {
            rigidBody.gravityScale = 3;
            state = State.on_Ground;
        }
        else if (collision.gameObject.name.Equals("Trap"))
        {
            GameController.paused = true;
            anim.SetInteger("state", 2);
        }
        
        
       // Debug.Log("Collided Object: " + collision.gameObject.name);
    }
}