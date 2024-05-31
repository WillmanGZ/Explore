using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Renderer fondo;
    [SerializeField] private CardController _cardPrefab;
    [SerializeField] private GameObject MensajeCorrecto;
    [SerializeField] private GameObject MensajeIncorrecto;
    [SerializeField] private GameObject Desenfoque;

    [Header("levelData")]
    [SerializeField] private int _columns = 4;
    [SerializeField] private int _rows = 4;
    [SerializeField] private int _difficulty = 4;
    [SerializeField] private int _movements = 12;

    [Header("UI")]
    [SerializeField] private Text _movtext;

    static private CardController _firstCard;
    static private CardController _secondCard;
    private int _movementsUsed = 0;
    private static bool _blockInput = false;
    private List<CardController> _cards = new List<CardController>();

    public static bool IsInputBlocked => _blockInput;

    public void StartLevel()
    {
        if (_difficulty > _cardPrefab.MaxCardType)
        {
            _difficulty = Math.Min(_difficulty, _cardPrefab.MaxCardType);
            Debug.Assert(false);
        }
        Debug.Assert((_rows * _columns) % 2 == 0);

        _cards.ForEach(c => Destroy(c.gameObject));
        _cards.Clear();

        List<int> allTypes = new List<int>();
        for (int i = 0; i < _cardPrefab.MaxCardType; i++)
        {
            allTypes.Add(i);
        }

        List<int> gameTypes = new List<int>();
        for (int i = 0; i < _difficulty; i++)
        {
            int chosenType = allTypes[UnityEngine.Random.Range(0, allTypes.Count)];
            allTypes.Remove(chosenType);
            gameTypes.Add(chosenType);
        }

        List<int> chosenTypes = new List<int>();
        for (int i = 0; i < (_rows * _columns) / 2; i++)
        {
            int chosenType = gameTypes[UnityEngine.Random.Range(0, gameTypes.Count)];
            gameTypes.Remove(chosenType);
            chosenTypes.Add(chosenType);
            chosenTypes.Add(chosenType);
        }

        Vector3 offset = new Vector3((_columns - 1) * _cardPrefab.Cardsize, (_rows - 1) * _cardPrefab.Cardsize, 0f) * 0.5f;

        for (int y = 0; y < _rows; y++)
        {
            for (int x = 0; x < _columns; x++)
            {
                Vector3 position = new Vector3(x * _cardPrefab.Cardsize, y * _cardPrefab.Cardsize, 0f);

                var card = Instantiate(_cardPrefab, position - offset, Quaternion.identity);
                card.CardType = chosenTypes[UnityEngine.Random.Range(0, chosenTypes.Count)];
                chosenTypes.Remove(card.CardType);
                card.OnClicked.AddListener(OnCardClicked);
                _cards.Add(card);
            }
        }
        _blockInput = false;
        _movementsUsed = 0;
        _movtext.text = $"Movimientos disponibles: {_movements}";
    }

    private void OnCardClicked(CardController card)
    {
        if (_blockInput || card == _firstCard || card == _secondCard)
        {
            return;
        }

        if (_firstCard == null)
        {
            _firstCard = card;
            _firstCard.Reveal();
        }
        else if (_secondCard == null)
        {
            _secondCard = card;
            _secondCard.Reveal();
            StartCoroutine(ProcessCardSelection());
        }
    }

    private IEnumerator ProcessCardSelection()
    {
        _blockInput = true;
        yield return new WaitForSeconds(0.5f);

        if (_firstCard.CardType == _secondCard.CardType)
        {
            StartCoroutine(Score(_firstCard, _secondCard));
        }
        else
        {
            StartCoroutine(Fail(_firstCard, _secondCard));
        }
        _movementsUsed += 1;
        _movtext.text = $"Movimientos disponibles: {_movements - _movementsUsed}";
    }

    private IEnumerator Score(CardController firstCard, CardController secondCard)
    {
        yield return new WaitForSeconds(0.5f);
        _cards.Remove(firstCard);
        Destroy(firstCard.gameObject);
        _cards.Remove(secondCard);
        Destroy(secondCard.gameObject);

        _firstCard = null;
        _secondCard = null;
        _blockInput = false;

        if (_cards.Count < 1)
        {
            Win();
        }
        else if (_movementsUsed >= _movements)
        {
            Lose();
        }
    }

    private IEnumerator Fail(CardController firstCard, CardController secondCard)
    {
        yield return new WaitForSeconds(0.5f);
        firstCard.Hide();
        secondCard.Hide();

        _firstCard = null;
        _secondCard = null;
        _blockInput = false;

        if (_movementsUsed >= _movements)
        {
            Lose();
        }
    }

    void Start()
    {
        _rows = PlayerPrefs.GetInt("_rows");
        _columns = PlayerPrefs.GetInt("_columns");
        _movements = PlayerPrefs.GetInt("_movements");
        _difficulty = PlayerPrefs.GetInt("_difficulty");
        StartLevel();
         fondo.GetComponent<Renderer>().sortingOrder = -3;
    }

    private void Update() {
        //Hace que el objeto 3D se mueva 0.02f unidades en el eje X por segundo
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0)* Time.deltaTime;
    }

    private void Win()
    {
        Desenfoque.SetActive(true);
        MensajeCorrecto.SetActive(true);
    }

    private void Lose()
    {
        Desenfoque.SetActive(true);
        MensajeIncorrecto.SetActive(true);
    }

    public void Back()
    {
        SceneManager.LoadScene(7);
    }
}








