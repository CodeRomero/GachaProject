using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GachaDatabase;
using GachaDatabase.Models;

namespace GachaMainBusinessMethods
{
    public interface IBusiness
    {
        public Dictionary<PokemonCard, bool> rollLootbox(User currentUser, int boxType); //tested

        public Dictionary<string, bool> buyFromPost(Post post, User currentUser); //tested

        public List<Post> getDisplayBoard(); //test

        public Dictionary<CardCollection, PokemonCard> getUserCollection(User currentUser);//tested

        public bool newPost(Post newPost, User currentUser); //test

        public User login(string username, string password); //tested

        public bool signUp(User newUser); //tested

        public bool incrementUserBalance(User currentUser, int coinsToAdd); //tested

        public PokemonCard getPokemonById(int id); //tested

        public User GetUserById(int id); //tested
        public MessageUser GetMessageUserById(int id);
        public MessageUser GetMessageUserByUsername(string username);

        public bool RemoveUser(int id); //tested

        public DisplayBoard getPostInfo(int id); //tested

        public Post getPostById(int id); //tested

        public List<RarityType> GetRarityTypes(); //tested

        public bool hidePost(int PostID); //tested

        public bool editPrice(int postID, int newPrice); //tested

        public bool favoriteCard(int UserId, int Poke); //tested

        public List<FullFriend> GetFriends(int UserId); //tested

        public bool newPostComment(int userId, int postId, string content); //tested

        public List<Message> GetMessagesBetween(int senderId, int receiverId); //tested
        public bool PostMessage(Message newMessage); //tested
        public bool DeleteMessagesBetween(int user1Id, int user2Id); //tested
        public List<User> GetOngoingConversationUsers(int userId); //tested

        public Dictionary<PostComment, string> getCommentList(int postId);
        
        public string friendAction(int userid, int friendId); //tested
    }
}
