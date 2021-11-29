using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuanchBall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float moveSpeed = 100;


    private Vector3 movePosition;
    private Vector3 startPos, endPos;


    private void Start()
    {
        CreateBall();
    }

    public void BallReturn()
    {
        if(GameManager.instance.numberOfBalls == GameManager.instance.spawnListBall.Count)
        {
            // Every ball is return 
            GameManager.instance.isSpawn = true;
            CreateBall();
            GameManager.instance.isPlayed = true;
        }
        
    }

    void Update()
    {
        movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(movePosition);            
        }else if (Input.GetMouseButton(0))
        {
            ContinueWithDragging(movePosition);
        }else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        StartCoroutine(launchBalls());

        ShowPreview.instance.setFirstPoint(Vector3.zero);
        ShowPreview.instance.setLastPoint(Vector3.zero);
    }


    private IEnumerator launchBalls()
    {
        if (GameManager.instance.isPlayed)
        {
            Vector3 direction = (startPos - endPos).normalized;

            foreach (var Ball in GameManager.instance.spawnListBall)
            {
                Ball.transform.position = transform.position;
                Ball.gameObject.SetActive(true);
                Ball.GetComponent<Rigidbody2D>().AddForce(direction * moveSpeed);
                Ball.transform.tag = "Player";

                yield return new WaitForSeconds(0.1f);
            }
            GameManager.instance.spawnListBall[GameManager.instance.spawnListBall.Count - 1].tag = "LastBall";
            GameManager.instance.numberOfBalls = 0;

            GameManager.instance.isPlayed = false;
        }
    }

    public void CreateBall()
    {        
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.SetActive(false);
     
        GameManager.instance.spawnListBall.Add(ball.GetComponent<Ball>());
        GameManager.instance.numberOfBalls++;
    }

    private void ContinueWithDragging(Vector3 movePosition)
    {
        if (GameManager.instance.isPlayed)
        {
            endPos = movePosition;


            Vector3 lastPreviewPoint = (startPos - endPos) * -1;
            lastPreviewPoint.y = -1f;
            lastPreviewPoint.x *= -1;
            lastPreviewPoint.z = 0;
            ShowPreview.instance.setLastPoint(lastPreviewPoint);
        }
    }

    private void StartDrag(Vector3 movePos)
    {
        if (GameManager.instance.isPlayed)
        {
            startPos = movePos;
            ShowPreview.instance.setFirstPoint(transform.position);
        }
    }
}
