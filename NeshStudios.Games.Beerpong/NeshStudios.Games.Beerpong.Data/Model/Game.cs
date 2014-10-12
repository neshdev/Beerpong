using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public enum GameStatus
    {
        Created,
        InProgress,
        Completed,
    }

    public enum GameMode
    {
        OneOnOne,
        TwoOnTwo,
    }

    public class Game
    {
        public int GameID { get; set; }

        private GameStatus _status;
        private string _gameStatus;
        private GameMode _mode;
        private string _gameMode;

        [NotMapped]
        public GameStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                GameStatus = value.ToString();
            }
        }

        
        protected internal string GameStatus
        {
            get
            {
                return _gameStatus;
            }
            set
            {
                _gameStatus = value;
                _status = (GameStatus)Enum.Parse(typeof(GameStatus), value);
            }
        }

        

        [NotMapped]
        public GameMode Mode
        {
            get
            { 
                return _mode; 
            }
            set
            {
                _mode = value;
                GameMode = value.ToString();
            }
        }

        protected internal string GameMode
        {
           
            get 
            { return _gameMode; 
            }
            set
            {
                _gameMode = value;
                _mode = (GameMode)Enum.Parse(typeof(GameMode), value);
            }
        }
        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ICollection<Shot> Shots { get; set; }
        public virtual ICollection<GameResult> GameResults { get; set; }

    }
}
