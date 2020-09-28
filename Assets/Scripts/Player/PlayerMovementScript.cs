﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    #region Private methods

    private void Move(){
        playerScript.states.isCrounching = playerScript.inputScript.isCrounchPressed;
        playerScript.states.isMoving = playerScript.inputScript.xAxis == 0f ? false : true;
        playerScript.rb2d.velocity = new Vector2(playerScript.inputScript.xAxis * playerScript.moveSpeed, playerScript.rb2d.velocity.y);
    }

    private void Jump(){
        if(playerScript.inputScript.isJumpPressed && playerScript.states.isOnGround){
            playerScript.rb2d.velocity = new Vector2(0f, 0f);
            playerScript.rb2d.AddForce(new Vector2(0f, playerScript.jumpForce), ForceMode2D.Impulse);
        }
    }
    #endregion
}
