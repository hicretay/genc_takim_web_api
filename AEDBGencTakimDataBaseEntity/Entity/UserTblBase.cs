using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AEDBGencTakimDataBaseEntity.Entities
{
    [Serializable]
    public abstract class UserTblBase
    {
        private int? _Id = null;
        private string _UserName = null;
        private string _UserEmail = null;
        private string _UserPassword = null;
        private bool? _Active = false;
        private string _UserTelephone = null;
        private int? _Birthdate;
        private DateTime? _RegistrationTime;
       
        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string UserName 
        { 
            get => _UserName; 
            set => _UserName = value; 
        }
        public string UserEmail { 
            get => _UserEmail; 
            set => _UserEmail = value; 
        }
        public string UserPassword { 
            get => _UserPassword; 
            set => _UserPassword = value; 
        }
        public bool? Active 
        { 
            get => _Active; 
            set => _Active = value; 
        }
        public string UserTelephone 
        { 
            get => _UserTelephone; 
            set => _UserTelephone = value; 
        }
        public int? Birthdate 
        { 
            get => _Birthdate; 
            set => _Birthdate = value; 
        }
        public DateTime? RegistrationTime 
        { 
            get => _RegistrationTime; 
            set => _RegistrationTime = value; 
        }
    }
}

