using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardController : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;

    public int MaxCardType => prefabs.Count;
    public UnityEvent<CardController> OnClicked;

    public int CardType = -1;
    public float Cardsize = 2f;
    private Animator _animator;

   

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (CardType < 0)
        {
            CardType = UnityEngine.Random.Range(0, prefabs.Count);
        }
        Instantiate(prefabs[CardType], transform.position, Quaternion.identity, transform);
    }

    private void OnMouseUpAsButton()
    {
        if (!LevelController.IsInputBlocked)
        {
            OnClicked.Invoke(this);
        }
    }

    public void Reveal()
    {
        _animator.SetBool("revealed", true);
    }

    public void Hide()
    {
        _animator.SetBool("revealed", false);
    }
}
