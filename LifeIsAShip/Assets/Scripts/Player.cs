using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    bool initiatedMinigame = false;

    public static Player instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        gameObject.transform.position = MapManager.instance.GetCurrentNodePosition();
    }

    void Update ()
    {
        if(initiatedMinigame == false)
            CheckBasicInput();
    }

    private void CheckBasicInput()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            if (Input.GetKeyDown(KeyCode.Space) && MapManager.instance.CanInitiateMinigame())
            {
                initiatedMinigame = true;

                //Play MiniGame animation

                MapManager.instance.StartMiniGame();
            }
            else if (Input.GetKeyDown(KeyCode.W) && MapManager.instance.CheckCanMove(PassageDirection.Up))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Up);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.4f
                    ));
                
                animator.Play("up");
            }
            else if (Input.GetKeyDown(KeyCode.S) && MapManager.instance.CheckCanMove(PassageDirection.Donw))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Donw);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.4f
                    ));

                animator.Play("down");
            }
            else if (Input.GetKeyDown(KeyCode.A) && MapManager.instance.CheckCanMove(PassageDirection.Left))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Left);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.4f
                    ));

                animator.Play("left");
            }
            else if (Input.GetKeyDown(KeyCode.D) && MapManager.instance.CheckCanMove(PassageDirection.Right))
            {
                MapManager.instance.MovimentCurrentNode(PassageDirection.Right);

                iTween.MoveTo(gameObject, iTween.Hash(
                    "position", MapManager.instance.GetCurrentNodePosition(),
                    "time", 0.4f
                    ));

                animator.Play("right");
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("AAAAAAAAAAAAA");
        if (collision.gameObject.tag.Equals("Box"))
        {
            print("true");
            Destroy(collision.gameObject);
        }
    }
}
