﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GachaDatabase.Models
{
    public partial class User
    {
        public User()
        {
            CardCollections = new HashSet<CardCollection>();
            DisplayBoards = new HashSet<DisplayBoard>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CoinBalance { get; set; }
        public int AccountLevel { get; set; }
        public int TotalCoinsEarned { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<CardCollection> CardCollections { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DisplayBoard> DisplayBoards { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<FriendsList> FriendsListRecievedRequestNavigations { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<FriendsList> FriendsListSentRequestNavigations { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Message> MessageReceivers { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Message> MessageSenders { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
