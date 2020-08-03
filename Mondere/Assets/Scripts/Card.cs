using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Card : MonoBehaviour
    {
        public CardData Data;
        public Vector2 Pos;
        public bool Selectable = false;

        [SerializeField]
        private Image[,] indicators;
        private Image background;

        [SerializeField]
        private Text title;
        [SerializeField]
        private Text description;

        private void Start()
        {
            background = GetComponent<Image>();
        }

        public void GoMini()
        {
            title.enabled = false;
            description.enabled = false;
        }

        public void GoInvisible()
        {
            background.color = new Color(0, 0, 0, 0);
            foreach (var i in indicators)
            {
                i.enabled = false;
            }
        }

        public void ShowSelection()
        {
            GoInvisible();
            background.color = new Color(0, 0.1f, 1, 0.4f);
        }

        public void RenderData(CardData data)
        {
            this.Data = data;
            this.description.text = data.Description;
            this.title.text = data.name;
            SetIndicators(Side.Top, data.Top);
            SetIndicators(Side.Right, data.Right);
            SetIndicators(Side.Bottom, data.Bottom);
            SetIndicators(Side.Left, data.Left);
        }

        public void Clear()
        {
            this.description.text = "";
            this.title.text = "";
            this.Data = null;
            GoInvisible();
        }

        private void SetIndicators(Side side, int code)
        {
            int i = (int)side;
            foreach (Flag f in Enum.GetValues(typeof(Flag)))
            {
                int j = (int)f;
                int bitstring = 1 << j;
                indicators[i, j].enabled = (code & bitstring) != 0; // check if flag set
            }
        }

        public enum Side
        {
            Top = 0,
            Right = 1,
            Bottom = 2,
            Left = 3
        }

        public enum Flag
        {
            Left = 0,
            Mid = 1,
            Right = 2
        }
    }
}
