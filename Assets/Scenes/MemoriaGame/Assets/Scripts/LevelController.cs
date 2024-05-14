using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.Mathematics;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CardController _cardPrefab;

    private List<CardController> _cards = new List<CardController>();

    [SerializeField] private int _columns = 4;

    [SerializeField] private int _rows = 4;

    [SerializeField] private int _difficulty = 4;

    [SerializeField] private int _movements = 12;    // cantidad de movimientos 

    private int _movementsUsed = 0;
    private bool _blockInput = true;
    private CardController _activeCard;
    void Start()
    {
        StartLevel();
    }


    public void StartLevel()
    {
        if(_difficulty > _cardPrefab.MaxCardType)
        {
            _difficulty = math.min(_difficulty, _cardPrefab.MaxCardType); // regula la dificultad
            Debug.Assert(false);

        }
        Debug.Assert((_rows*_columns)%2 ==0);

        _cards.ForEach(c => Destroy(c.gameObject));
        _cards.Clear();

        List<int> allTypes = new List<int>();
        for(int i =0;i<_cardPrefab.MaxCardType;i++ )
        {
            allTypes.Add(i);
        }


        List<int> gameTypes = new List<int> ();
        for(int i = 0; i<_difficulty;i++)
        {
            int chosenType = allTypes[UnityEngine.Random.Range(0,allTypes.Count)];
            allTypes.Remove(chosenType);
            gameTypes.Add(chosenType);
        }

        List<int> chosenTypes = new List<int>();
        for (int i = 0; i < (_rows*_columns)/2 ; i++)
        {
            int chosenType = gameTypes[UnityEngine.Random.Range(0, gameTypes.Count)];
            chosenTypes.Add(chosenType);
            chosenTypes.Add(chosenType);
    
        }

        Vector3 offset = new Vector3((_columns - 1) * _cardPrefab.Cardsize, (_rows - 1) * _cardPrefab.Cardsize, 0f) * 0.5f;


        for(int y =0;y<_rows;y++)
        {
            for(int x =0;x<_columns;x++)
            {
                Vector3 position = new Vector3(x * _cardPrefab.Cardsize, y * _cardPrefab.Cardsize, 0f);

                var card = Instantiate(_cardPrefab, position - offset, 
                    Quaternion.identity);
                card.CardType = chosenTypes[UnityEngine.Random.Range(0, chosenTypes.Count)];
                chosenTypes.Remove(card.CardType);
                card.OnClicked.AddListener(OnCardClicked);
                _cards.Add(card);

            }
        }
        _blockInput = false;
        _movementsUsed = 0;  

    } 

    private void OnCardClicked(CardController card)
    {
        if (_blockInput)
        {
            return;
        }
        _blockInput = true;
        if (_activeCard == null)
        {
            StartCoroutine(SelectCard(card));
            return;
        }
        _movementsUsed++;
        if (card.CardType==_activeCard.CardType) 
        {
            StartCoroutine(Score(card));
            return; 
        }
        StartCoroutine(Fail(card));
    }

    private IEnumerator SelectCard(CardController card) 
    {
        _activeCard = card;
        _activeCard.reveal();
        yield return new WaitForSeconds(0.1f);
        _blockInput=false;
    }

    private IEnumerator Score(CardController card)
    {
        card.reveal();
        yield return new WaitForSeconds(0.5f);
        _cards.Remove(_activeCard);
        _cards.Remove(card);
        Destroy(card.gameObject);
        Destroy(_activeCard.gameObject);
        _activeCard=null;
        _blockInput = false;
        if(_cards.Count <1)
        {
            win();
        }
    }
    
    private IEnumerator Fail(CardController card) 
    {
        card.reveal();
        yield return new WaitForSeconds(0.5f);
        _activeCard.hide();
        card.hide();
        _activeCard = null;
        yield return new WaitForSeconds(0.1f);
        _blockInput = false;
        if (_movementsUsed >= _movements)
        {
            lose();
            yield break;
        }
    }

    private void win()
    {
        Debug.Log("ganaste");
    }

    private void lose()
    {
        Debug.Log("perdiste");
    }
}
