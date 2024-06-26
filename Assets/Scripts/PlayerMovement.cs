using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private AudioClip jumpAudio;
    [SerializeField] private AudioSource audioPersonaje;

    public bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        #region JUMPING

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            audioPersonaje.PlayOneShot(jumpAudio);
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
        #endregion

        #region CROUCHING

        if(isGrounded && Input.GetButtonDown("Fire3"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);

            if (isJumping)
            {
                GFX.localScale = new Vector3(GFX.localScale.x, 3f, GFX.localScale.z);
            }
        }

        if (Input.GetButtonUp("Fire3"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 3f, GFX.localScale.z);
        }
        #endregion

    }
}
