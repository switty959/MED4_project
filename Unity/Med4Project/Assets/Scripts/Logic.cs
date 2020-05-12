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
    public AK.Wwise.Event goodSound,badSound;
    private bool goodPlayed, badPlayed = true;
    


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
        var index = path_1_list.IndexOf(lastID);

        if (path_1_list.Contains(cellID) && path_1_list.Contains(lastID) && cellID != 19 && cellID != 0)
        {
            if (path_1_list[index + 1] == cellID)
            {

                if (!goodPlayed)
                {
                    PlayGood();
                }
                goodPlayed = true;
                badPlayed = false;
            }

            else
            {

                if (!badPlayed)
                {
                    PlayBad();
                }
                goodPlayed = false;
                badPlayed = true;
            }
        }

        else if (!path_1_list.Contains(cellID) || !path_1_list.Contains(lastID))
        {
            if (!badPlayed)
            {
                PlayBad();
            }
            goodPlayed = false;
            badPlayed = true;

            CheckMinorChoices(cellID);
        }
    }

    private void CheckMinorChoices(int cell) {

   
        if (cell == 48 || cell == 89)//Wrong cells
        {  
            if (lastID == 49)
            {
                PlayBad();
            }
        }
        else if(cell == 50 && lastID == 49)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if ((cell == 1094 || cell == 1135) && lastID == 1095)//Wrong cells
        {
                PlayBad();
        }
        else if (cell == 1055 && lastID == 1095)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if ((cell == 1094 || cell == 1135) && lastID == 1095)//Wrong cells
        {
            PlayBad();
        }
        else if (cell == 1055 && lastID == 1095)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if (cell == 1539 && lastID == 1579)//Wrong cells
        {
            PlayBad();
        }
        else if ((cell == 1578 || cell == 1580) && lastID == 1579)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if (cell == 1309 && lastID == 1269)//Wrong cells
        {
            PlayBad();
        }
        else if ((cell == 1268 || cell == 1229) && lastID == 1269)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if ((cell == 1038 || cell == 1079) && lastID == 1039)//Wrong cells
        {
            PlayBad();
        }
        else if (cell == 999 && lastID == 1039)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if ((cell == 956 || cell == 954) && lastID == 955)//Wrong cells
        {
            PlayBad();
        }
        else if (cell == 915 && lastID == 955)//Correct cells
        {
            PlayGood();
        }
        //////////////////////////////////////////////
        if ((cell == 279 || cell == 359) && lastID == 319)//Wrong cells
        {
            PlayBad();
        }
        else if (cell == 318 && lastID == 319)//Correct cells
        {
            PlayGood();
        }
        //else if (cell == 1095)
        //{

        //    localBadPlayed = false;

        //    if (lastID == 1094 || lastID == 1135)
        //    {
        //        PlayGood();
        //    }
        //}

        //else if (cell == 1579 && (lastID == 1539))
        //{
        //        PlayGood();
        //    localBadPlayed = false;
        //}

        //else if (cell == 1269)
        //{

        //    localBadPlayed = false;

        //    if (lastID == 1309)
        //    {
        //        PlayGood();
        //    }
        //}

        //else if (cell == 1039)
        //{
        //    localBadPlayed = false;
        //    if (lastID == 1079 || lastID == 1038)
        //    {
        //        PlayGood();
        //    }
        //}

        //else if (cell == 955)
        //{
        //    localBadPlayed = false;
        //    if (lastID == 954 || lastID == 956)
        //    {
        //        PlayGood();
        //    }
        //}

        //else if (cell == 319)
        //{
        //    localBadPlayed = false;
        //    if (lastID == 279 || lastID == 359)
        //    {
        //        PlayGood();
        //    }
        //}

        //else
        //{
        //    if ((!localBadPlayed))
        //    {
        //        PlayBad();
        //        localBadPlayed = true;
        //    }   
        //}
    }





    //else if (path_1_list.Contains(lastID) && !path_1_list.Contains(cellID) && cellID != 19)
    //{
    //    print("Incorrect");
    //    badSound.Post(gameObject);
    //}

    //else
    //{
    //    if (path_1_list[index] != cellID)
    //    {
    //        badSound.Post(gameObject);
    //    }
    //}

    //if (path_1_list.Contains(cellID))
    //{
    //    if (path_1_list[index] == cellID)
    //    {
    //        //print("correct");
    //        //goodSound.volume = 1.0f;
    //        //badSound.volume = 0.0f;
    //        goodSound.Post(gameObject);
    //        lastCorrect = cellObject.transform.position;
    //    }
    //    else
    //    {
    //        //print("incorrect");          
    //        offset = Vector3.Distance(player.transform.position, lastCorrect);
    //        badSound.Post(gameObject);
    //        //goodSound.volume = 1 - (offset/10);
    //        //badSound.volume = offset / 10;
    //    }
    //}
    //else
    //{
    //    //print("incorrect");
    //    badSound.Post(gameObject);
    //    offset = (lastCorrect - player.transform.position).magnitude;
    //    //goodSound.volume = 1 - (offset / 10);
    //    //badSound.volume = offset / 10;
    //}



    private void PlayGood()
    {
        goodSound.Post(gameObject);
    }

    private void PlayBad()
    {
        badSound.Post(gameObject);
    }
}

