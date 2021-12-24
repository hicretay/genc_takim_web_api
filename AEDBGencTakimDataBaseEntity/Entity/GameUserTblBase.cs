using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class GameUserTblBase   
    {
        private int? _Id = null;
        private int? _UserId = null;
        private int? _GameId = null;
        private bool? _IsSubstitute = false;
        private int? _UserLocation = null;

        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int? UserId 
        { 
            get => _UserId; 
            set => _UserId = value; 
        }
        public int? GameId 
        { 
            get => _GameId;
            set => _GameId = value; 
        }
        public bool? IsSubstitute 
        { 
            get => _IsSubstitute; 
            set => _IsSubstitute = value; 
        }
        public int? UserLocation 
        {
            get => _UserLocation; 
            set => _UserLocation = value; 
        }
    }
}

