using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("controller.isGrounded = " + controller.isGrounded);

        if(controller.isGrounded && velocity.y < 0) //if player is being pulled down but is already on the ground
        {
            velocity.y = -2f; // set gravity force to -2
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //transform.right stores the coordinates to add which will move the object to it's right by 1 unit. this is always updated when the rotation changes
        //transform.forward stores the coordinates to add which will move the object forward by 1 unit
        //x will store -1, 0 or 1 depending on the buttons pressed, which will change the amount to move the character by:
        //  if x = 1 and transform.right = (1, 0, 0) (player is facing forward, right arrow key held down), the code will calculate as (1, 0, 0), 
        //  saying that the player should have these coordinates added to their position.
        //  therefore move stores the coordinates to be added to the player's current position

        //Debug.Log("transform.right: " + transform.right);
        //Debug.Log("transform.forward: " + transform.forward);
        //Debug.Log("Vector3 move = " + transform.right + " * " + x + " + " + transform.forward + " * " + z);
        //Debug.Log("Vector3 move = " + move);

        if(Input.GetButtonDown("Jump") && controller.isGrounded) //only works when placed before the first controller.Move
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("jump executed");
        }

        controller.Move(move * speed * Time.deltaTime);
        // multiply by speed to increase the coordinates to be added, thereby increasing the distance the object is moved when this code is run

        

        velocity.y += gravity * Time.deltaTime;
        // y value is equal to current y value + gravity - velocity continously increase

        controller.Move(velocity * Time.deltaTime);
        // always add velocity
    }
}
