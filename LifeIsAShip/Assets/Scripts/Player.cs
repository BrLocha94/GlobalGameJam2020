using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    float animCooldownTimer = 1f;
    float currentTime = 1f;

	void Update ()
    {
        CheckBasicInput();
    }

    private void CheckBasicInput()
    {
        if (currentTime >= animCooldownTimer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("up");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                animator.Play("down");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                animator.Play("left");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                animator.Play("right");
                currentTime = 0f;
            }
        }
        else
            currentTime += Time.deltaTime;
    }
}
