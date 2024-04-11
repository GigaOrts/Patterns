using System.Collections;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] coins;
    [SerializeField] private float delay;

    private Coin[] pickedCoins;

    private void Start()
    {
        StartCoroutine(SpawnRepeating());
    }

    private IEnumerator SpawnRepeating()
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            pickedCoins = coins.Where(coin => coin.IsPicked).ToArray();

            if (pickedCoins.Length == 0)
                continue;

            Coin coin = pickedCoins[Random.Range(0, pickedCoins.Length)];
            coin.ResetState();
        }
    }
}
