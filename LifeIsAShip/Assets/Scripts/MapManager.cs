using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Structure height and widht")]
    public int height;
    public int widht;

    [Header("All the nodes in the scene")]
    [SerializeField]
    private NodeBehaviour[] referenceNodes;

    [Header("Holds all the possible configs to sort to a node")]
    [SerializeField]
    private NodeConfig[] configNodes;

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

    public void SortScenarios()
    {
        for(int i = 0; i < (referenceNodes.Length - 2); i++)
        {
            int random = Random.Range(0, configNodes.Length);

            referenceNodes[i].SetConfig(configNodes[random]);
        }
    }
}
