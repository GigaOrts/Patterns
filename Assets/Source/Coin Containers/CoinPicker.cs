using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            coin.Pick();
        }
    }
}
