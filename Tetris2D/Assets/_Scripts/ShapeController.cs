using UnityEngine;
using System.Collections;

public class ShapeController : MonoBehaviour {

    private float nextDrop;
    private bool blockLocked;
    private bool canMoveLeft;
    private bool canMoveRight;

    private float speed;

    private GameController gameController;


	void Start () {

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        blockLocked = false;
        canMoveLeft = true;
        canMoveRight = true;
        nextDrop = Time.time + 0.5f;

        speed =0.5f;
        //speed = 10;
	}


    void Update()
    {
        if (!blockLocked)
        {
            if (canMoveLeft)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    gameController.MoveLeft();
                    this.transform.position -= new Vector3(0.5f, 0, 0);
                }

            }
            if (canMoveRight)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    gameController.MoveRight();
                    this.transform.position += new Vector3(0.5f, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                speed *= 8;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {

                speed = gameController.level * 0.5f;
            }

            if (Time.time > nextDrop)
            {
                gameController.MoveDown();
                this.transform.position -= new Vector3(0, 0.5f, 0);
                nextDrop = Time.time + 0.5f / speed;
            }

            
        }
    }

    public void LockBlock()
    {
        blockLocked = true;
    }

    public void UnlockBlock()
    {
        blockLocked = false;
    }


    public void CanMoveLeft(bool adjust)
    {
        canMoveLeft = adjust;
    }
    public void CanMoveRight(bool adjust)
    {
        canMoveRight = adjust;
    }


}

