using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Model
{
    public enum TrajectoryType
    {
        Projectile,
        Bounce,
    }

    public enum BallStatus
    {
        None,
        Air,
        Rim,
        Hit,
        Defended,
        Invalid,
    }

    public class OffensiveShotResult
    {
        private string _ballStatus;
        private BallStatus _status;
        private TrajectoryType _trajectory;
        private string _trajectoryType;
        
        [NotMapped]
        public BallStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                BallStatus = value.ToString();

            }
        }

        protected internal string BallStatus
        {
            get 
            { 
                return _ballStatus; 
            }
            set
            {
                _ballStatus = value;
                _status = (BallStatus)Enum.Parse(typeof(BallStatus), value);
            }
        }

        [NotMapped]
        public TrajectoryType Trajectory
        {
            get
            { 
                return _trajectory;
            }
            set
            { 
                _trajectory = value;
                this.TrajectoryType = _trajectory.ToString();
            }
        }

        protected internal string TrajectoryType
        {
            get
            { 
                return _trajectoryType;
            }
            set
            {
                _trajectoryType = value;
                _trajectory = (TrajectoryType)Enum.Parse(typeof(TrajectoryType), value);
            }
        }

        public int ShotID { get; set; }

        public virtual Shot Shot { get; set; }

        [ForeignKey("TeamMember")]
        public int TeamMemberID { get; set; }

        public virtual TeamMember TeamMember { get; set; }
    }
}
