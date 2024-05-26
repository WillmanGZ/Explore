using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private CardController _cardPrefab;

    //-----------------------------------------------------------------------//
    [Header("levelData")]                                                    //
                                                                             //
    [SerializeField] private int _columns = 4;                               //
    [SerializeField] private int _rows = 4;                                  //
    [SerializeField] private int _difficulty = 4;                            //
    [SerializeField] private int _movements = 12;                            //
    //-----------------------------------------------------------------------//

    [Header("UI")]
    [SerializeField] private TMPro.TMP_Text _movtext;

    ///////////////////////////////////////////////////////////////////////////////
    private CardController _activeCard;
    private int _movementsUsed = 0;
    private bool _blockInput=false;
    private List<CardController> _cards = new List<CardController>();
    ///////////////////////////////////////////////////////////////////////////////

    public void startlevel()
    {
if (_difficulty > _cardPrefab.MaxCardType)
        {
            _difficulty = Math.Min(_difficulty, _cardPrefab.MaxCardType); // regula la dificultad
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
        {                   // Ubica todo
            for(int x =0;x<_columns;x++)
            {
                Vector3 position = new Vector3(x * _cardPrefab.Cardsize, y * _cardPrefab.Cardsize, 0f);

                var card = Instantiate(_cardPrefab, position - offset, 
                    Quaternion.identity);
                card.CardType = chosenTypes[UnityEngine.Random.Range(0, chosenTypes.Count)];
                chosenTypes.Remove(card.CardType);
                card.OnClicked.AddListener(OncardClicked);
                _cards.Add(card);

            }
        }
        _blockInput = false;
        _movementsUsed = 0;
        _movtext.text = $"movimientos disponibles: {_movements}";
    }

    private void OncardClicked(CardController card)
    {
        //if (_blockInput)              // NO SIRVE, CAMBIA A TRUE SOLO Y NO DEJA JUGAR
        //{
        //    print(_blockInput);
        //    return;
        //}                             // para evitar q seleccione mas de 2 


        //_blockInput = true;   
        print(_blockInput + "s");

        if (_activeCard == null)
        {
            StartCoroutine(selectCard(card));
            return;
        }

        _movementsUsed++;
        _movtext.text = $"movimientos disponibles: {_movements - _movementsUsed}";
        //card.testAnimation();

        if (card.CardType == _activeCard.CardType)
        {
            StartCoroutine(score(card));
            return;
        }
        StartCoroutine(fail(card));
    }

    public IEnumerator selectCard(CardController card)
    {
        _activeCard = card;
        _activeCard.reveal();
       yield return new WaitForSeconds(0.5f);
        _blockInput = false;
    }

    void Start()
    {
        _rows = PlayerPrefs.GetInt("_rows");
        _columns = PlayerPrefs.GetInt("_columns");
        _movements = PlayerPrefs.GetInt("_movements");
        _difficulty = PlayerPrefs.GetInt("_difficulty");
        startlevel();

    }

    void Update()
    {
        
    }

    private IEnumerator score(CardController card)
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
            yield break;
        }
        if (_movementsUsed >= _movements)
        {
            lose();
            yield break;
        }
        _blockInput = false;
    }

    private IEnumerator fail(CardController card)
    {
        card.reveal();
        yield return new WaitForSeconds(1f);
        _activeCard.Hide();
        card.Hide();
        _activeCard = null;
        yield return new WaitForSeconds(0.5f);
        _blockInput = false;
        if (_movementsUsed >= _movements)
        {
            lose();
            yield break;
        }


    }
    private void win()
    {
        Debug.Log("ganaste");   // Mostrar un panel q diga q ganaste
    }

    private void lose()
    {
        Debug.Log("perdiste");
        //_gameOverButton.SetActive(true);

    }
}

// pendientes:
// 1) Arregla lo del booleano
// 2) mensaje de victoria y puntos 
// 3) UI
