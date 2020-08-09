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
        public bool Selectable = false;

        [SerializeField]
        private Image[,] indicators;
        private Image background;

        [SerializeField]
        private Text title;
        [SerializeField]
        private Text description;

        private void Awake()
        {
            background = GetComponent<Image>();
            indicators = new Image[4, 3];
            GetIndicators();
        }

        private void GetIndicators()
        {
            //TODO: this is terrible
            // top right bottom left
            // left mid right
            indicators[0, 0] = this.transform.GetChild(0).GetComponent<Image>();
            indicators[0, 1] = this.transform.GetChild(1).GetComponent<Image>();
            indicators[0, 2] = this.transform.GetChild(2).GetComponent<Image>();
            indicators[1, 0] = this.transform.GetChild(3).GetComponent<Image>();
            indicators[1, 1] = this.transform.GetChild(4).GetComponent<Image>();
            indicators[1, 2] = this.transform.GetChild(5).GetComponent<Image>();
            indicators[3, 2] = this.transform.GetChild(6).GetComponent<Image>();
            indicators[3, 1] = this.transform.GetChild(7).GetComponent<Image>();
            indicators[3, 0] = this.transform.GetChild(8).GetComponent<Image>();
            indicators[2, 2] = this.transform.GetChild(9).GetComponent<Image>();
            indicators[2, 1] = this.transform.GetChild(10).GetComponent<Image>();
            indicators[2, 0] = this.transform.GetChild(11).GetComponent<Image>();
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
            background.color = Color.black;
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
