using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class SaloonTblBase
    {
        private int? _Id = null;
        private string _SaloonName = null;
        private string _SaloonFeature = null;
        private string _SaloonAddress = null;   

        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string SaloonName 
        { 
            get => _SaloonName; 
            set => _SaloonName = value; 
        }
        public string SaloonFeature 
        { 
            get => _SaloonFeature; 
            set => _SaloonFeature = value; 
        }
        public string SaloonAddress 
        { 
            get => _SaloonAddress; 
            set => _SaloonAddress = value; 
        }
    }
}

