using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class GameTblBase
    {
        private int? _Id = null;
        private int? _SportId = null;
        private int? _UserId = null;
        private int? _SaloonId = null;
        private string _GameNote = null;
        private bool? _GamePassed = false;
        private DateTime? _GameTime;
        private int? _GamePlayerCount;   
        private int? _GameSubstituteCount;

        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int? SportId 
        { 
            get => _SportId; 
            set => _SportId = value; 
        }
        public int? UserId 
        { 
            get => _UserId; 
            set => _UserId = value; 
        }
        public int? SaloonId 
        { 
            get => _SaloonId; 
            set => _SaloonId = value; 
        }
        public string GameNote 
        { 
            get => _GameNote; 
            set => _GameNote = value; 
        }
        public bool? GamePassed 
        { 
            get => _GamePassed; 
            set => _GamePassed = value; 
        }
        public DateTime? GameTime 
        { 
            get => _GameTime; 
            set => _GameTime = value; 
        }
        public int? GamePlayerCount 
        { 
            get => _GamePlayerCount; 
            set => _GamePlayerCount = value; 
        }
        public int? GameSubstituteCount 
        { 
            get => _GameSubstituteCount; 
            set => _GameSubstituteCount = value; 
        }
    }
}

