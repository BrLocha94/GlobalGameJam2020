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


    [Header("Max Of the same node")]
    [SerializeField]
    private int maxEqualNodes;

    [Header("Holds all the possible configs to sort to a node")]
    [SerializeField]
    private NodeConfig[] configNodes;

    [Header("Minigame Spaw position")]
    public Transform spawPosition;

    private static NodeBehaviour currentNode;

    public static MapManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<MapManager>();
        }
        if (maxEqualNodes == 0)
        {
            maxEqualNodes = 1;
        }
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
        List<int> nodesList = new List<int>();


        for (int i = 0; i < (referenceNodes.Length - 2); i++)
        {
            int qtdOfNodes = 0;
            int randomNodeValue = Random.Range(0, configNodes.Length);
            if (nodesList.Contains(randomNodeValue))
            {
                for (int k = 0; k < nodesList.Count; k++)
                {
                    if (nodesList[k] == randomNodeValue)
                    {
                        qtdOfNodes++;
                    }
                }

                if (qtdOfNodes < maxEqualNodes)
                {

                    nodesList.Add(randomNodeValue);
                }
            }

            else
            {
                nodesList.Add(randomNodeValue);
            }
        }

        for (int i = 0; i < nodesList.Count; i++)

        {
            referenceNodes[i].SetConfig(configNodes[nodesList[i]]);
        }

        if (nodesList.Count < (referenceNodes.Length - 2))
        {
            for(int i = nodesList.Count; i < ((referenceNodes.Length - 2) - nodesList.Count);  i++)
            referenceNodes[i].SetConfig(configNodes[0]);
        }
    }

    public bool CanInitiateMinigame()
    {
        return currentNode.CanInitiateMinigame();
    }

    public void StartMiniGame()
    {
        currentNode.StartMiniGame(spawPosition);
    }
}
