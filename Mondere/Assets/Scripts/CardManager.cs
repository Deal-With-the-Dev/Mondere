using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CardManager : MonoBehaviour
    {
        public int Height = 5;
        public int Width = 5;
        public GameObject PrefabCard;
        public CardData[] Deck;
        public bool PlayerTurn = true;
        public bool EmptyField = true;

        [SerializeField]
        private RectTransform hand;
        [SerializeField]
        private RectTransform field;

        // Start is called before the first frame update
        void Start()
        {
            ClearField();

            AddCardToHand(Deck[0]);
            AddCardToHand(Deck[0]);
        }

        public void AddCardToHand(CardData d)
        {
            var go = Instantiate(PrefabCard, hand);
            var card = go.GetComponent<Card>();
            card.RenderData(d);
            var button = go.GetComponent<Button>();
            button.onClick.AddListener(() => ClickedOn(card)); 
        }

        public void ClickedOn(Card card)
        {
            Debug.Log("Clicked on " + card);

            if(EmptyField)
            {
                var middle = GetCardAt(Height / 2, Width / 2);
                middle.RenderData(card.Data);
                EmptyField = false;
                Destroy(card.gameObject);
            }
            else
            {
                //need to render possible moves
                ShowValidMoves(card);
            }

        }

        private void ShowValidMoves(Card card)
        {
            for (int i = 0; i < field.childCount; i++)
            {

            }
        }

        public Card GetCardAt(int row, int col)
        {
            int i = row * Width + col;
            return field.GetChild(i).GetComponent<Card>();
        }

        private void ClearField()
        {
            foreach (RectTransform child in field)
            {
                var card = child.GetComponent<Card>();
                card.GoMini();
                card.Clear();
            }
        }

        void Update()
        {


        }
    }
}
