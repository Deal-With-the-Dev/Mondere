using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CardManager : MonoBehaviour
    {
        public int Height = 5;
        public int Width = 5;
        public Vector2 Spacing;
        public Card PrefabCard;
        public CardData[] Deck;

        [SerializeField]
        private RectTransform hand;
        [SerializeField]
        private RectTransform field;

        // Start is called before the first frame update
        void Start()
        {
            ClearField();
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}
