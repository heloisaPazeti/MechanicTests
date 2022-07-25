using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rig;

    private bool isPlayerPaused;
    private Vector3 moveDelta;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (!isPlayerPaused)
            transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);


        if(movementJoystick.joystickVec.y != 0)
        {
            rig.velocity = new Vector2(
                movementJoystick.joystickVec.x * playerSpeed,
                movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }
    public void PausePlayer(bool pausePlayer)
    {
        isPlayerPaused = pausePlayer;
    }
}
