using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {


    [Header("Door from Game")]
    [SerializeField]
    private GameObject[] Doors;

    [Header("Nodes")]
    [SerializeField]
    private GameObject[] AllNodes;

    private void Start()
    {
        int totalLevels = 0;
        List<int> doorToOpen = new List<int>();
        OpenSideController NewDoorController = GameObject.FindObjectOfType<OpenSideController>();

        if (NewDoorController != null)
        {
            totalLevels = NewDoorController.GetQtdOfLevels();

            int val = Random.Range(0, totalLevels);

            doorToOpen = NewDoorController.GetListOfSideOpen(val);
        }

        for (int i = 0; i < Doors.Length; i++)
        {

            if (doorToOpen[i] == 0)
            {
                Doors[i].SetActive(false);
                switch (i)
                {
                    case 0:

                        AllNodes[i].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i+3].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        break;
                    case 1:

                        AllNodes[i].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i + 3].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        break;
                    case 2:

                        AllNodes[i].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i + 3].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        break;
                    case 3:

                        AllNodes[i].GetComponent<NodeBehaviour>().SetReferencenull("right");
                        AllNodes[i + 1].GetComponent<NodeBehaviour>().SetReferencenull("left");
                        break;
                    case 4:

                        AllNodes[i].GetComponent<NodeBehaviour>().SetReferencenull("right");
                        AllNodes[i + 1].GetComponent<NodeBehaviour>().SetReferencenull("left");
                        break;
                    case 5:

                        AllNodes[i - 2].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i + 1].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        break;
                    case 6:

                        AllNodes[i-2].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i + 1].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        Debug.Log(i);
                        break;
                    case 7:

                        AllNodes[i - 2].GetComponent<NodeBehaviour>().SetReferencenull("down");
                        AllNodes[i + 1].GetComponent<NodeBehaviour>().SetReferencenull("up");
                        break;
                    case 8:

                        AllNodes[i - 2].GetComponent<NodeBehaviour>().SetReferencenull("right");
                        AllNodes[i - 1].GetComponent<NodeBehaviour>().SetReferencenull("left");
                        break;

                    case 9:

                        AllNodes[i - 2].GetComponent<NodeBehaviour>().SetReferencenull("right");
                        AllNodes[i - 1].GetComponent<NodeBehaviour>().SetReferencenull("left");
                        break;

                }

            }
        }

    }

}
