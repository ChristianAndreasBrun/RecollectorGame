using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { Playing, Stop }

public class PlayerControl : MonoBehaviour
{
    public GameManager manager;
    public PlayerState state;
    public CharacterController control;
    public Animator anim;
    public float speedMove, speedRotation, jumpForece, gravity;
    public int life, score;

    [Header("Audio SFX")]
    public AudioSource takeScrollSFX;
    public AudioSource footStepsSFX;
    public AudioSource jumpSFX;
    public AudioSource deathSFX;

    Vector3 moveDir;


    void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Playing:
                PlayingUpdate();
                break;

            case PlayerState.Stop:
                StopUpdate();
                break;
        }
    }


    void PlayingUpdate()
    {
        anim.SetBool("isGrounded", control.isGrounded);

        if (control.isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            moveDir = new Vector3(horizontalInput * speedMove, 0, verticalInput * speedMove);
            moveDir = transform.TransformDirection(moveDir);

            Vector3 normalizedDir = moveDir.normalized;
            float speedAnim = normalizedDir.magnitude;
            anim.SetFloat("Speed", speedAnim);

            if (Input.GetButton("Jump"))
            {
                anim.SetTrigger("Jump");
                moveDir.y = jumpForece;
                jumpSFX.Play();
            }

            if (horizontalInput != 0 || verticalInput != 0)
            {
                if (!footStepsSFX.isPlaying)
                {
                    footStepsSFX.Play();
                }
            }
            else
            {
                footStepsSFX.Stop();
            }


        }
        else
        {
            moveDir.y -= gravity * Time.deltaTime;
        }

        anim.SetFloat("VelocityY", moveDir.y);
        transform.Rotate(Vector3.up * speedRotation * Input.GetAxis("Mouse X") * Time.deltaTime);
        control.Move(moveDir * Time.deltaTime);
    }

    void StopUpdate()
    {
        anim.SetBool("isGrounded", control.isGrounded);
        anim.SetFloat("Speed", 0);


        // Caer verticalmente
        moveDir = new Vector3(0, moveDir.y, 0);
        if (!control.isGrounded)
        {
            moveDir.y -= gravity * Time.deltaTime;
            control.Move(moveDir * Time.deltaTime);
        }
    }

    public void StopPlayer()
    {
        state = PlayerState.Stop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Recollect"))
        {
            takeScrollSFX.Play();
            Destroy(other.gameObject);
            score++;
        }
    }


    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            anim.SetTrigger("Death");
            deathSFX.Play();
            state = PlayerState.Stop;
            StartCoroutine(manager.cGameOver());
        }
    }
}
