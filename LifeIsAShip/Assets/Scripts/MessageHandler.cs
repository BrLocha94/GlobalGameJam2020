using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    [Header("Hammer prefab and position to instantiate")]
    public Hammer hammer;
    public Transform position;

	public void OnHandAnimationExit()
    {
        GameObject newHammer = Instantiate(hammer.gameObject, position);
        newHammer.transform.SetParent(gameObject.transform);
    }
}
