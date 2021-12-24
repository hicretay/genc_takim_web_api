using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class GameUserViewBase  
    {
        private int? _Id = null;
        private string _GameNote = null;
        private int? _GamePlayerCount = null;
        private int? _GameSubstituteCount = null;
        private DateTime? _GameTime = null;
        private int? _SaloonId = null;
        private int? _UserId = null;
        private int? _MaxPlayerCount;   
        private int? _MaxSubstituteCount;
        private string _SportName = null;
        private string _SaloonAddress = null;
        private string _SaloonFeature = null;
        private string _SaloonName = null;
        private bool? _IsPassed = false;
        private int? _UserLocation = null;
        private bool? _IsSubstitute = false;
        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string GameNote
        { 
            get => _GameNote; 
            set => _GameNote = value; 
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
        public DateTime? GameTime
        {
            get => _GameTime;
            set => _GameTime = value;
        }
        public int? SaloonId 
        { 
            get => _SaloonId; 
            set => _SaloonId = value; 
        }
        public int? UserId
        {
            get => _UserId;
            set => _UserId = value;
        }

        public int? MaxPlayerCount 
        { 
            get => _MaxPlayerCount; 
            set => _MaxPlayerCount = value; 
        }
        public int? MaxSubstituteCount 
        { 
            get => _MaxSubstituteCount; 
            set => _MaxSubstituteCount = value; 
        }
        public string SportName 
        { 
            get => _SportName; 
            set => _SportName = value; 
        }
        public string SaloonAddress 
        { 
            get => _SaloonAddress; 
            set => _SaloonAddress = value; 
        }
        public string SaloonFeature 
        { 
            get => _SaloonFeature; 
            set => _SaloonFeature = value; 
        }
        public string SaloonName 
        { 
            get => _SaloonName; 
            set => _SaloonName = value; 
        }
        public bool? IsPassed
        {
            get => _IsPassed;
            set => _IsPassed = value;
        }
        public int? UserLocation 
        { 
            get => _UserLocation; 
            set => _UserLocation = value; 
        }
        public bool? IsSubstitute 
        { 
            get => _IsSubstitute; 
            set => _IsSubstitute = value; 
        }
    }
}

