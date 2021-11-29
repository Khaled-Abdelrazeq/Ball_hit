using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private TextMeshPro text;
    private SpriteRenderer renderer;

    public int hitsRemaining;

     void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        renderer = GetComponent<SpriteRenderer>();

        hitsRemaining = GameManager.instance.blockNumber;
        setColorAndNumber();
    }

    private void Update()
    {
        if (hitsRemaining > 0)
            setColorAndNumber();
        else
            Destroy(gameObject);
    }

    private void setColorAndNumber()
    {
        text.text = hitsRemaining.ToString();
        renderer.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 10f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("LastBall"))
        {
            hitsRemaining--;
        }
    }
}
