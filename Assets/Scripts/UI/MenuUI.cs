using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Text _bestScore;
        private Player _player;


        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _bestScore.text = "Best score :"+ _player.Max.ToString();
        }
    }
}
