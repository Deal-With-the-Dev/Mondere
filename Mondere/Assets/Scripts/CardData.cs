using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName ="Card", menuName ="Mondere/Card")]
    public class CardData : ScriptableObject
    {
        public string CardName = "";
        public string Description = "";

        //binary codes for connection data
        [Range(0,7)]
        public int Top = 7;
        [Range(0,7)]
        public int Right = 7;
        [Range(0,7)]
        public int Bottom = 7;
        [Range(0,7)]
        public int Left = 7;
    }
}
