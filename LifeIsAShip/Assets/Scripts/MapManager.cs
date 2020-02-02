using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Structure height and widht")]
    public int height;
    public int widht;

    [SerializeField]
    private NodeBehaviour[] referenceNodes;
    private static NodeBehaviour currentNode;

    public static MapManager instance;

    void Awake()
    {
        if (instance == null)
            instance = gameObject.GetComponent<MapManager>();

        currentNode = referenceNodes[6];    
    }

    public void ModifyCurrentNode(NodeBehaviour node)
    {
        currentNode = node;
    }

    public NodeBehaviour GetCurrentNode()
    {
        return currentNode;
    }

    public Vector3 GetCurrentNodePosition()
    {
        return currentNode.gameObject.transform.position;
    }

    public bool CheckCanMove(PassageDirection direction)
    {
        return currentNode.CheckCanMove(direction);
    }

    public void MovimentCurrentNode(PassageDirection direction)
    {
        currentNode = currentNode.GetNextNode(direction);
    }
}
