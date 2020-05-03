using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public GameObject boxCollider;
    public float offset = 1.0f;
    public Vector3 start = Vector3.zero;
    public Vector3 trans = Vector3.zero;
    public List<GameObject> cells;
    public List<int> path_1_list;
    [TextArea(15, 20)]
    public string path_1_ids;
    public int lastID;
    public AudioSource goodSound;
    public AudioSource badSound;
    public GameObject player;
    public Vector3 lastCorrect = Vector3.zero;

    void Start()
    {
        start = boxCollider.transform.position;
        trans = start;

        for (int i = 0; i < 40; i++)
        {
            Instantiate(boxCollider, new Vector3(trans.x, trans.y, trans.z + i * offset), Quaternion.identity);
            for (int j = 0; j < 40; j++)
            {
                GameObject newCell = Instantiate(boxCollider, new Vector3(trans.x + j * offset, trans.y, trans.z + i * offset), Quaternion.identity);
                cells.Add(newCell);
                newCell.GetComponent<Cell>().id = i + j * 40;
            }
        }
        path_1_list.AddRange(path_1_ids.Split(',').Select(i => int.Parse(i)));
    }

    public void PathCheck(int cellID, GameObject cellObject)
    {
        var index = path_1_list.IndexOf(lastID) + 1;
        float offset = 0.0f;

        if (path_1_list.Contains(cellID))
        {
            if (path_1_list[index] == cellID)
            {
                //print("correct");
                goodSound.volume = 1.0f;
                badSound.volume = 0.0f;
                lastCorrect = cellObject.transform.position;
            }
            else
            {
                //print("incorrect");          
                offset = Vector3.Distance(player.transform.position, lastCorrect);
                goodSound.volume = 1 - (offset/10);
                badSound.volume = offset / 10;
            }
        }
        else
        {
            //print("incorrect");
            offset = (lastCorrect - player.transform.position).magnitude;
            goodSound.volume = 1 - (offset / 10);
            badSound.volume = offset / 10;
        }

    }

    private void Update()
    {
        print("Good sound volume = " + goodSound.volume + ", Bad sound volume = " + badSound.volume);
    }
}
