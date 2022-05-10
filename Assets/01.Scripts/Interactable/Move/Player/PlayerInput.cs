using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // ют╥б boolean
    public bool up { get; private set; }
    public bool down { get; private set; }
    public bool left { get; private set; }
    public bool right { get; private set; }
    public bool moveInput { get; private set; }

    private KeyCode upKey = KeyCode.UpArrow;
    private KeyCode downKey = KeyCode.DownArrow;
    private KeyCode leftKey = KeyCode.LeftArrow;
    private KeyCode rightKey = KeyCode.RightArrow;

    private void Update()
    {
        up = Input.GetKeyDown(upKey);
        down = Input.GetKeyDown(downKey);
        left = Input.GetKeyDown(leftKey);
        right = Input.GetKeyDown(rightKey);
        moveInput = up || down || left || right ;
    }
}
