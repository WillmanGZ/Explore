using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    public int CardType=-1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        if(CardType<0)
        {
            CardType=UnityEngine.Random.Range(0, prefabs.Count);
        }
        Instantiate(prefabs[CardType], Vector3.zero, Quaternion.identity, transform);
    }

    void Update()
    {
        
    }

    public void reveal()
    {
        _animator.SetBool("revealed",true);
    }
    public void hide()
    {
        _animator.SetBool("revealed", false);
    }
}
