using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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

            GetCardAt(0, 0).RenderData(Deck[0]);
            GetCardAt(1, 1).RenderData(Deck[1]);
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
