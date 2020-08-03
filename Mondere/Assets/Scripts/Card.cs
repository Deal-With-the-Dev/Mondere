using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private Image TopLeft;

        [SerializeField]
        private Text title;
        [SerializeField]
        private Text description;
    }
}
