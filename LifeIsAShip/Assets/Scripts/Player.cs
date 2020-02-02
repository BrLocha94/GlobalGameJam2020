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

    void Start()
    {
        gameObject.transform.position = MapManager.instance.GetCurrentNodePosition();
    }

    void Update ()
    {
        CheckBasicInput();
    }

    private void CheckBasicInput()
    {
        if (currentTime >= animCooldownTimer)
        {
            if (Input.GetKeyDown(KeyCode.W) && MapManager.instance.CheckCanMove(PassageDirection.Up))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Up);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.95f
                    ));
                
                animator.Play("up");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.S) && MapManager.instance.CheckCanMove(PassageDirection.Donw))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Donw);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.95f
                    ));

                animator.Play("down");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.A) && MapManager.instance.CheckCanMove(PassageDirection.Left))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Left);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.95f
                    ));

                animator.Play("left");
                currentTime = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.D) && MapManager.instance.CheckCanMove(PassageDirection.Right))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Right);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.95f
                    ));

                animator.Play("right");
                currentTime = 0f;
            }
        }
        else
            currentTime += Time.deltaTime;
    }

}
