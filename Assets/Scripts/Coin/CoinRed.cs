using UnityEngine;

public class CoinRed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Data.coin += 7;
            Destroy(gameObject);
        }
    }
}
