using System.Collections;
using System.Collections.Generic;
using TalesofHivnir.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{

    public class UIManager : MonoBehaviour
    {
        private Player healthMan;

        public Slider healthBar;

        public Text hpText;
        // Start is called before the first frame update
        void Start()
        {
            healthMan = FindObjectOfType<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.maxValue = healthMan.Maxlife;
            healthBar.value = healthMan.Health;
            hpText.text = "HP: " + healthMan.Health + "/" + healthMan.Maxlife;
        }
    }
}
