using DomainModel;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRepository
    {

        List<Comment> GetCommentsOfAPost(int postId, int limit, int offset);
        int GetNumberOfCommentsOfAPost(int postId);

        List<History> GetAllHistory(int limit, int offset);
        int GetNumberOfHistories();
        History GetAHistory(int? id);
        void AddToHistory(History history);
        void DeleteFromHistory(int? id);
        void DeleteAllHistory();

        User GetUserById(int id);

        List<Mark> GetMarkedPosts(int limit, int offset);
        int GetNumberOfMarkedPosts();
        void Mark(Mark mark);
        void Unmark(int id);
        void DeleteAllMarks();
        Mark GetAMark(int markId);

        Post GetAPost(int postId);
        List<Post> GetAllRelatedPosts(int postId);

        WordIdf GetIDFOfWord(string word);
        List<WordTf> GetTFsOfWord(int wordId);
    }
}