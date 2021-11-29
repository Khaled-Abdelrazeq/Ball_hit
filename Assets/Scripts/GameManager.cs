using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int blockNumber;
    public bool isSpawn = false;
    public bool isPlayed = true;

    public int numberOfBalls;

    public List<Block> spawnList = new List<Block>();
    public List<Ball> spawnListBall = new List<Ball>();

    private void Awake()
    {
        if (instance == null)
            instance = this;

        blockNumber = 1;
    }

    private void Start()
    {
        GenerateBlocks.instance.GenerateRawOfBlock();
    }

    private void Update()
    {
        if (isSpawn)
        {
            blockNumber++;
            GenerateBlocks.instance.GenerateRawOfBlock();
            isSpawn = false;
        }
    }


    public void SpawnObj()
    {
        foreach (Block block in spawnList)
        {
            if (block != null)
            {
                Vector3 startPos = block.transform.position;
                
                block.transform.position = new Vector3(startPos.x, startPos.y - 0.8f, startPos.z);
            }
        }
    }
}
