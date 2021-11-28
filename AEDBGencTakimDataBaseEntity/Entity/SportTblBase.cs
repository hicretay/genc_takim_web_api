using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class SportTblBase
    {
        private int? _Id = null;
        private string _SportName = null;
        private int? _MaxPlayerCount;
        private int? _MaxSubstituteCount;   

        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string SportName
        {
            get => _SportName;
            set => _SportName = value;
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
    }
}

