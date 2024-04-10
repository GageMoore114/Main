using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shoot;

    // Start is called before the first frame update
    public override void Start()
    {
        //If we have a GameManager
        if (GameManager.instance != null)
        {
            // and it tracks the player 
            if (GameManager.instance.player != null)
            {
                //register with the gamemanager
                GameManager.instance.player.Add(this);
            }
        }
        // Run the Start() function from the parent (base) class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Process our Keyboard Inputs
        ProcessInputs();

        // Run the Update() function from the parent (base) class
        base.Update();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
    public void OnDestroy()
    {
        //if we have a gamemanager
        if (GameManager.instance != null)
        {
            //it tracks the player
            //Deregister with the gamemanager
            GameManager.instance.player.Remove(this);
        }
    }
}
