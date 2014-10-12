using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public enum GameOutcome
    {
        Win,
        Loss,
        Draw,
        Unfinished,
    }

    public class GameResult
    {
        [Key]
        public int GameResultID { get; set; }

        [ForeignKey("TeamMember")]
        public int TeamMemberID { get; set; }
        public virtual TeamMember TeamMember { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        private GameOutcome _outcome;

        [NotMapped]
        public GameOutcome Outcome
        {
            get { return _outcome; }
            set 
            { 
                _outcome = value;
                this.GameOutcome = _outcome.ToString();
            }
        }

        private string _gameOutcome;

        protected internal string GameOutcome
        {
            get
            { 
                return _gameOutcome; 
            }
            set
            { 
                _gameOutcome = value;
                _outcome = (GameOutcome)Enum.Parse(typeof(GameOutcome), value);
            }
        }
        
        
    }
}
