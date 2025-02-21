using UnityEngine;

public class text : MonoBehaviour
{
    public GameObject _text;
    void Awake()
    {
        _text.SetActive(false);
    }
    void Start()
    {
        _text.SetActive(true);
    }
}
