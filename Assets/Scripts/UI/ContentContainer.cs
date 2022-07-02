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
    public class ContentContainer : MonoBehaviour
    {
        [SerializeField] private Text _bestScore;
        [SerializeField] private Text _currentScore;
        private Player _player;


        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _player.OnScoreChanged += UpdateScore;
            UpdateScore();
        }
        public void UpdateScore()
        {
            _currentScore.text = _player.Current.ToString();
            _bestScore.text = _player.Max.ToString();
        }

        private void OnDestroy()
        {
            _player.OnScoreChanged -= UpdateScore;
        }


    }
}
