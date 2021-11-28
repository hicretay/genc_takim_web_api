﻿using System;
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
        private DateTime? _GamePlayTime;
        private bool? _IsSubstitute = false;

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
        public DateTime? GamePlayTime 
        { 
            get => _GamePlayTime; 
            set => _GamePlayTime = value; 
        }
        public bool? IsSubstitute 
        { 
            get => _IsSubstitute; 
            set => _IsSubstitute = value; 
        }
    }
}

