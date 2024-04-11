using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject view;
    
    public bool IsPicked => gameObject.activeSelf == false;

    private void Awake()
    {
        view = gameObject;
        view.SetActive(false);
    }

    public void Pick()
    {
        view.SetActive(false);
    }

    public void ResetState()
    {
        view.SetActive(true);
    }
}
