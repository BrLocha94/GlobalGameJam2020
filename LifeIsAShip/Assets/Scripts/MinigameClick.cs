using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameClick : Minigame
{
    public GameObject baseSprite;

    bool isOver = false;

    public int maxClicks = 20;
    int currentClicks = 0;

    float ratio;

    float timer = 15f;

    void Awake()
    {
        ratio = 1f / (float)maxClicks;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            OnFinishedGame(false);

        if (isOver == true && Input.GetMouseButtonDown(0))
        {
            currentClicks++;
            UpdateUI();
            if (maxClicks <= currentClicks)
                OnFinishedGame(true);
        }
    }

    private void OnMouseEnter()
    {
        print("AQUI");
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

    private void UpdateUI()
    {
        Vector3 scale = new Vector3(baseSprite.transform.localScale.x + ratio, baseSprite.transform.localScale.y + ratio, 1f);
        baseSprite.transform.localScale = scale;
    }
}
