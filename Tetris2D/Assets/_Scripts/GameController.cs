using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private bool gameOver;

    private float score;
    public float level;

    private GameObject[,] points = new GameObject[12, 19];
    private bool lockMovingShape = true;

    public GameObject blocks;

    private GameObject[] movingBlock = new GameObject[4];


    private int movingX;
    private int movingY;
    private int movingType;
    private int direction;

    public Material[] colors;

    public GameObject boundary;


    void Start()
    {

        score = 0;
        level = 1;
        gameOver = false;

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                points[i, j] = null;
            }
        }
        for (int i = 0; i < 12; i++)
        {
            points[i, 18] = boundary;
        }
        for (int i = 0; i < 19; i++)
        {
            points[0, i] = boundary;
        }
        for (int i = 0; i < 19; i++)
        {
            points[11, i] = boundary;
        }

    }


    void Update()
    {

        if (lockMovingShape)
        {
            GenerateBlock();
        }



        CheckMoveAble();
        CheckEliminate();


        if (score > (level * (level + 1) * 500))
        {
            level++;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeDirection();
        }


    }


    public void changeDirection()
    {
        if (movingType == 1)
        {
            if (direction == 1)
            {
                if (movingY > 0)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-1.0f, 0, 0);
                    UnlockAll();
                    movingX++;
                    movingY--;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (points[movingX + 1, movingY + 2] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position -= new Vector3(0.5f, 0.5f, 0);
                    movingBlock[1].transform.position -= new Vector3(0, 0, 0);
                    movingBlock[2].transform.position -= new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[3].transform.position -= new Vector3(-1.0f, 0, 0);
                    UnlockAll();
                    movingX--;
                    movingY++;
                    direction = 1;
                }
            }
        }
        if (movingType == 2)
        {
            if (direction == 1)
            {
                if (movingY > 1 && points[movingX + 2, movingY + 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(1.0f, -0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0.5f, 0, 0);
                    movingBlock[2].transform.position += new Vector3(0, -0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-0.5f, 0, 0);
                    UnlockAll();
                    movingX++;
                    movingX++;
                    movingY++;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (points[movingX - 2, movingY + 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position -= new Vector3(1.0f, -0.5f, 0);
                    movingBlock[1].transform.position -= new Vector3(0.5f, 0, 0);
                    movingBlock[2].transform.position -= new Vector3(0, -0.5f, 0);
                    movingBlock[3].transform.position -= new Vector3(-0.5f, 0, 0);
                    UnlockAll();
                    movingX--;
                    movingX--;
                    movingY--;
                    direction = 1;
                }
            }
        }
        if (movingType == 3)
        {
            ///do nothing
        }
        if (movingType == 4)
        {
            if (direction == 1)
            {
                if (movingY > 0 && points[movingX - 1, movingY - 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-1.0f, 1.0f, 0);
                    UnlockAll();
                    movingX--;
                    movingY++;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (points[movingX - 1, movingY] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(0.5f, -0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-1.0f, -1.0f, 0);
                    UnlockAll();
                    movingX++;
                    movingY++;
                    direction = 3;
                }
            }
            else if (direction == 3)
            {
                if (points[movingX + 1, movingY - 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(0.5f, -0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(1.0f, -1.0f, 0);
                    UnlockAll();
                    movingX++;
                    movingY--;
                    direction = 4;
                }
            }
            else if (direction == 4)
            {
                if (points[movingX + 1, movingY] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(1.0f, 1.0f, 0);
                    UnlockAll();
                    movingX--;
                    movingY--;
                    direction = 1;
                }
            }
        }
        if (movingType == 5)
        {
            if (direction == 1)
            {
                if (points[movingX + 2, movingY + 2] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(1.0f, -1.0f, 0);
                    movingBlock[1].transform.position += new Vector3(0.5f, -0.5f, 0);
                    movingBlock[2].transform.position += new Vector3(0, 0, 0);
                    movingBlock[3].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    UnlockAll();
                    movingX++;
                    movingX++;
                    movingY++;
                    movingY++;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (points[movingX + 2, movingY-2] == null&& points[movingX+1,movingY-2]==null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(1.0f, 1.0f, 0);
                    movingBlock[1].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[2].transform.position += new Vector3(0, 0, 0);
                    movingBlock[3].transform.position += new Vector3(0.5f, -0.5f, 0);
                    UnlockAll();
                    movingX++;
                    movingX++;
                    movingY--;
                    movingY--;
                    direction = 3;
                }
            }
            else if (direction == 3)
            {

                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-1.0f, 1.0f, 0);
                    movingBlock[1].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[2].transform.position += new Vector3(0, 0, 0);
                    movingBlock[3].transform.position += new Vector3(0.5f, 0.5f, 0);
                    UnlockAll();
                    movingX--;
                    movingX--;
                    movingY--;
                    movingY--;
                    direction = 4;

            }
            else if (direction == 4)
            {
                if (movingX > 1 && points[movingX - 2, movingY + 2] == null && points[movingX - 1, movingY + 2] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-1.0f, -1.0f, 0);
                    movingBlock[1].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[2].transform.position += new Vector3(0, 0, 0);
                    movingBlock[3].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    UnlockAll();
                    movingX--;
                    movingX--;
                    movingY++;
                    movingY++;
                    direction = 1;
                }
            }
        }
        if (movingType == 6)
        {
            if (direction == 1)
            {
                if ( points[movingX - 1, movingY + 1] == null&&points[movingX+1,movingY+1]==null&&points[movingX+2,movingY+1]==null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(1.0f, 1.0f, 0);
                    UnlockAll();
                    movingX--;
                    movingY++;
                    direction = 2;
                }
            }
            else if (direction == 2)
            {
                if (points[movingX +1, movingY + 2] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position -= new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[1].transform.position -= new Vector3(0, 0, 0);
                    movingBlock[2].transform.position -= new Vector3(0.5f, 0.5f, 0);
                    movingBlock[3].transform.position -= new Vector3(1.0f, 1.0f, 0);
                    UnlockAll();
                    movingX++;
                    movingY--;
                    direction = 1;
                }
            }
        }
        if (movingType == 7)
        {
            if (direction == 1)
            {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(0.5f, -0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    UnlockAll();
                    movingX++;
                    movingY++;
                    direction = 2;
                
            }
            else if (direction == 2)
            {
                if (points[movingX + 1, movingY - 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(-0.5f, -0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(0.5f, -0.5f, 0);
                    UnlockAll();
                    movingX++;
                    movingY--;
                    direction = 3;
                }
            }
            else if (direction == 3)
            {
                LockAll();
                movingBlock[0].transform.position += new Vector3(-0.5f, 0.5f, 0);
                movingBlock[1].transform.position += new Vector3(0, 0, 0);
                movingBlock[2].transform.position += new Vector3(0.5f, -0.5f, 0);
                movingBlock[3].transform.position += new Vector3(0.5f, 0.5f, 0);
                UnlockAll();
                movingX--;
                movingY--;
                direction = 4;

            }
            else if (direction == 4)
            {
                if (points[movingX - 1, movingY + 1] == null)
                {
                    LockAll();
                    movingBlock[0].transform.position += new Vector3(-0.5f,-0.5f, 0);
                    movingBlock[1].transform.position += new Vector3(0, 0, 0);
                    movingBlock[2].transform.position += new Vector3(0.5f, 0.5f, 0);
                    movingBlock[3].transform.position += new Vector3(-0.5f, 0.5f, 0);
                    UnlockAll();
                    movingX--;
                    movingY++;
                    direction = 1;
                }
            }
        }
    }

    void OnGUI()
    {
        if (gameOver)
        {
            GUILayout.Window(1, new Rect(200, 300, 100, 50), DrawPannal, "游戏结束");
        }
        GUILayout.Label("score:" + score);
        GUILayout.Label("level:" + level);
    }

    private void DrawPannal(int id)
    {
        if (id == 1)
        {
            if (GUILayout.Button("重新开始"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUILayout.Button("退出"))
            {
                Application.Quit();
            }
        }
    }



    public void CheckEliminate()
    {
        for (int j = 0; j < 18; j++)
        {
            int countLine = 0;
            for (int i = 1; i < 11; i++)
            {
                if (points[i, j] != null)
                {
                    countLine++;
                }
            }
            if (countLine == 10)
            {
                for (int i = 1; i < 11; i++)
                {
                    Destroy(points[i, j]);
                    points[i, j] = null;
                    score += 10 * level;
                }
                MoveDownRestBlocks(j);
            }
        }
    }

    private void MoveDownRestBlocks(int line)
    {
        for (int j = line; j > 0; j--)
        {
            for (int i = 1; i < 11; i++)
            {
                if (points[i, line - 1] != null)
                {
                    points[i, line] = points[i, line - 1];
                    points[i, line].transform.position -= new Vector3(0, 0.5f, 0);
                    points[i, line - 1] = null;
                }
            }
            line--;
        }
    }



    private void GenerateBlock()
    {
        if (gameOver == false)
        {
            lockMovingShape = false;
            movingType = Random.Range(1, 8);
            direction = 1;
            //movingType = 1;
            switch (movingType)
            {
                ///左Z形
                case 1:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.75f, 3.75f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[0];
                    }
                    movingX = 5;
                    movingY = 0;
                    // points[movingX, movingY] = movingShape;
                    break;

                ///右Z形
                case 2:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.75f, 4.25f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[1];
                    }
                    movingX = 5;
                    movingY = 1;
                    break;
                ///方形
                case 3:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[2];
                    }
                    movingX = 5;
                    movingY = 0;
                    break;
                ///左L
                case 4:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.75f, 3.75f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[3];
                    }
                    movingX = 5;
                    movingY = 0;
                    break;
                ///右L
                case 5:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(0.75f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.75f, 4.25f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[4];
                    }
                    movingX = 5;
                    movingY = 1;
                    break;
                ////竖条
                case 6:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(-0.25f, 3.25f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(-0.25f, 2.75f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[5];
                    }
                    movingX = 5;
                    movingY = 0;
                    break;
                ///丁字形
                case 7:
                    movingBlock[0] = Instantiate(blocks, new Vector3(-0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[1] = Instantiate(blocks, new Vector3(0.25f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[2] = Instantiate(blocks, new Vector3(0.75f, 3.75f, 0), transform.rotation) as GameObject;
                    movingBlock[3] = Instantiate(blocks, new Vector3(0.25f, 4.25f, 0), transform.rotation) as GameObject;
                    for (int i = 0; i < 4; i++)
                    {
                        movingBlock[i].GetComponent<MeshRenderer>().material = colors[6];
                    }
                    movingX = 5;
                    movingY = 1;
                    break;
            }

        }
    }

    public void LockAll()
    {
        movingBlock[0].GetComponent<ShapeController>().LockBlock();
        movingBlock[1].GetComponent<ShapeController>().LockBlock();
        movingBlock[2].GetComponent<ShapeController>().LockBlock();
        movingBlock[3].GetComponent<ShapeController>().LockBlock();
    }

    public void UnlockAll()
    {
        movingBlock[0].GetComponent<ShapeController>().UnlockBlock();
        movingBlock[1].GetComponent<ShapeController>().UnlockBlock();
        movingBlock[2].GetComponent<ShapeController>().UnlockBlock();
        movingBlock[3].GetComponent<ShapeController>().UnlockBlock();
    }

    public void CheckAllLeft(bool check)
    {
        movingBlock[0].GetComponent<ShapeController>().CanMoveLeft(check);
        movingBlock[1].GetComponent<ShapeController>().CanMoveLeft(check);
        movingBlock[2].GetComponent<ShapeController>().CanMoveLeft(check);
        movingBlock[3].GetComponent<ShapeController>().CanMoveLeft(check);
    }

    public void CheckAllRight(bool check)
    {
        movingBlock[0].GetComponent<ShapeController>().CanMoveRight(check);
        movingBlock[1].GetComponent<ShapeController>().CanMoveRight(check);
        movingBlock[2].GetComponent<ShapeController>().CanMoveRight(check);
        movingBlock[3].GetComponent<ShapeController>().CanMoveRight(check);
    }


    public void CheckMoveAble()
    {
        if (movingType == 1)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 2] != null || points[movingX + 2, movingY + 2] != null)
                {
                    //if (points[movingX, movingY + 1] != null)
                    //{
                    //    Debug.Log(points[movingX, movingY + 1].name+"1"+movingY);
                    //}
                    //if (points[movingX + 1, movingY + 2] != null)
                    //{
                    //    Debug.Log(points[movingX + 1, movingY + 2].name+"2+"+movingY);
                    //}
                    //if (points[movingX + 2, movingY + 2] != null)
                    //{
                    //Debug.Log(points[movingX + 2, movingY + 2].name+"3+"+movingY);
                    //}
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX + 1, movingY] = movingBlock[1];
                    points[movingX + 1, movingY + 1] = movingBlock[2];
                    points[movingX + 2, movingY + 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX, movingY + 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 3, movingY + 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX - 1, movingY + 3] != null || points[movingX, movingY + 2] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY + 1] = movingBlock[1];
                    points[movingX - 1, movingY + 1] = movingBlock[2];
                    points[movingX - 1, movingY + 2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 2, movingY + 1] != null || points[movingX - 2, movingY + 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY + 1] != null || points[movingX, movingY + 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }

        if (movingType == 2)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 2, movingY] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX + 1, movingY] = movingBlock[1];
                    points[movingX + 1, movingY - 1] = movingBlock[2];
                    points[movingX + 2, movingY - 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX, movingY - 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 2, movingY] != null || points[movingX + 3, movingY - 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX - 1, movingY] != null || points[movingX, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY - 1] = movingBlock[1];
                    points[movingX - 1, movingY - 1] = movingBlock[2];
                    points[movingX - 1, movingY - 2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 2, movingY - 1] != null || points[movingX - 2, movingY - 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY - 1] != null || points[movingX, movingY - 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }

        if (movingType == 3)
        {
            if (points[movingX, movingY + 2] != null || points[movingX + 1, movingY + 2] != null)
            {
                LockAll();
                points[movingX, movingY] = movingBlock[0];
                points[movingX + 1, movingY] = movingBlock[1];
                points[movingX, movingY + 1] = movingBlock[2];
                points[movingX + 1, movingY + 1] = movingBlock[3];
                lockMovingShape = true;
                CheckGameOver();
            }
            if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY + 1] != null)
            {
                CheckAllLeft(false);
            }
            else
            {
                CheckAllLeft(true);
            }
            if (points[movingX + 2, movingY] != null || points[movingX + 2, movingY + 1] != null)
            {
                CheckAllRight(false);
            }
            else
            {
                CheckAllRight(true);
            }
        }

        if (movingType == 4)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 2] != null || points[movingX + 1, movingY + 2] != null || points[movingX + 2, movingY + 2] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY + 1] = movingBlock[1];
                    points[movingX + 1, movingY + 1] = movingBlock[2];
                    points[movingX + 2, movingY + 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY + 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 3, movingY + 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX + 1, movingY] = movingBlock[1];
                    points[movingX + 1, movingY - 1] = movingBlock[2];
                    points[movingX + 1, movingY - 2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX, movingY - 1] != null || points[movingX, movingY - 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 2, movingY] != null || points[movingX + 2, movingY - 1] != null || points[movingX + 2, movingY - 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 3)
            {
                if (points[movingX, movingY + 1] != null || points[movingX - 1, movingY] != null || points[movingX - 2, movingY] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY - 1] = movingBlock[1];
                    points[movingX - 1, movingY - 1] = movingBlock[2];
                    points[movingX - 2, movingY - 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 3, movingY - 1] != null || points[movingX - 1, movingY] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY - 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 4)
            {
                if (points[movingX, movingY + 1] != null || points[movingX - 1, movingY + 3] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX -1, movingY] = movingBlock[1];
                    points[movingX - 1, movingY +1] = movingBlock[2];
                    points[movingX - 1, movingY +2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 2, movingY] != null || points[movingX-2, movingY + 1] != null || points[movingX-2, movingY +2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX, movingY + 1] != null || points[movingX, movingY + 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }


        if (movingType == 5)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 2, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX + 1, movingY] = movingBlock[1];
                    points[movingX + 2, movingY] = movingBlock[2];
                    points[movingX + 2, movingY - 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY - 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 3, movingY] != null || points[movingX + 3, movingY - 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX, movingY + 1] != null || points[movingX - 1, movingY - 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX , movingY-1] = movingBlock[1];
                    points[movingX , movingY-2] = movingBlock[2];
                    points[movingX -1, movingY - 2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY - 1] != null || points[movingX - 2, movingY - 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY - 1] != null || points[movingX + 1, movingY - 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 3)
            {
                if (points[movingX, movingY + 1] != null || points[movingX - 1, movingY + 1] != null || points[movingX - 2, movingY + 2] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX -1, movingY] = movingBlock[1];
                    points[movingX - 2, movingY] = movingBlock[2];
                    points[movingX - 2, movingY + 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 3, movingY] != null || points[movingX - 3, movingY + 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX - 1, movingY + 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 4)
            {
                if (points[movingX, movingY + 3] != null || points[movingX +1, movingY +3] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY + 1] = movingBlock[1];
                    points[movingX, movingY + 2] = movingBlock[2];
                    points[movingX + 1, movingY + 2] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY + 1] != null || points[movingX - 1, movingY + 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 2, movingY + 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }


        if (movingType == 6)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 4] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY + 1] = movingBlock[1];
                    points[movingX, movingY + 2] = movingBlock[2];
                    points[movingX, movingY + 3] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY + 1] != null || points[movingX - 1, movingY + 2] != null || points[movingX - 1, movingY + 3] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 1, movingY + 2] != null || points[movingX + 1, movingY + 3] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 2, movingY + 1] != null || points[movingX + 3, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX+1, movingY] = movingBlock[1];
                    points[movingX+2, movingY ] = movingBlock[2];
                    points[movingX+3, movingY ] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 4, movingY] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }


        if (movingType == 7)
        {
            if (direction == 1)
            {
                if (points[movingX, movingY + 1] != null || points[movingX + 1, movingY + 1] != null || points[movingX + 2, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX + 1, movingY] = movingBlock[1];
                    points[movingX + 2, movingY] = movingBlock[2];
                    points[movingX + 1, movingY - 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX, movingY - 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 3, movingY] != null || points[movingX + 2, movingY - 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 2)
            {
                if (points[movingX, movingY + 1] != null || points[movingX - 1, movingY] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY-1] = movingBlock[1];
                    points[movingX, movingY-2] = movingBlock[2];
                    points[movingX -1, movingY - 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 2, movingY - 1] != null || points[movingX - 1, movingY - 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 1, movingY - 1] != null || points[movingX + 1, movingY - 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 3)
            {
                if (points[movingX, movingY + 1] != null || points[movingX -1, movingY + 2] != null || points[movingX - 2, movingY + 1] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX - 1, movingY] = movingBlock[1];
                    points[movingX - 2, movingY] = movingBlock[2];
                    points[movingX - 1, movingY + 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 3, movingY] != null || points[movingX-2, movingY + 1] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX, movingY + 1] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
            else if (direction == 4)
            {
                if (points[movingX, movingY + 3] != null || points[movingX + 1, movingY+2] != null)
                {
                    LockAll();
                    points[movingX, movingY] = movingBlock[0];
                    points[movingX, movingY + 1] = movingBlock[1];
                    points[movingX, movingY+ 2] = movingBlock[2];
                    points[movingX + 1, movingY + 1] = movingBlock[3];
                    lockMovingShape = true;
                    CheckGameOver();
                }
                if (points[movingX - 1, movingY] != null || points[movingX - 1, movingY + 1] != null || points[movingX - 1, movingY + 2] != null)
                {
                    CheckAllLeft(false);
                }
                else
                {
                    CheckAllLeft(true);
                }
                if (points[movingX + 1, movingY] != null || points[movingX + 2, movingY + 1] != null || points[movingX + 1, movingY + 2] != null)
                {
                    CheckAllRight(false);
                }
                else
                {
                    CheckAllRight(true);
                }
            }
        }

    }

    private void CheckGameOver()
    {
        for (int i = 1; i < 11; i++)
        {
            if (points[i, 0] != null)
            {
                gameOver = true;
                break;
            }
        }
    }

    int countLeft = 0;
    public void MoveLeft()
    {
        //   points[movingX, movingY] = null;
        countLeft++;
        if (countLeft == 4)
        {
            movingX--;
            countLeft = 0;
        }
        //  points[movingX, movingY] = movingShape;
    }

    int countRight = 0;
    public void MoveRight()
    {
        //  points[movingX, movingY] = null;
        countRight++;
        if (countRight == 4)
        {
            movingX++;
            countRight = 0;
        }
        //  points[movingX, movingY] = movingShape;
    }

    int countDown = 0;
    public void MoveDown()
    {
        //   points[movingX, movingY] = null;
        countDown++;
        if (countDown == 4)
        {
            movingY++;
            countDown = 0;
        }
        //  points[movingX, movingY] = movingShape;
    }

}
