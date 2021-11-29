using UnityEngine;
using TMPro;

public class GenerateBlocks : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public static GenerateBlocks instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void GenerateRawOfBlock()
    {
        GameManager.instance.SpawnObj();

        int rand = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(rand != i)
            {
                GameObject block = Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                //block.transform.parent = spawnPoints[i];
                block.GetComponentInChildren<TextMeshPro>().text = GameManager.instance.blockNumber.ToString();

                GameManager.instance.spawnList.Add(block.GetComponent<Block>());
            }
        }
    }
}
