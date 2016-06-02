using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using System.Data.Entity;
using DataAccessLayer;

namespace MySqlDatabase
{
    public class MySqlRepository : IRepository
    {


        public WordIdf GetIDFOfWord(string word)
        {
            using (var db = new SovaContext())
            {
                return db.WordIdfs.Where(w => w.Word == word).First();
            }
        }

        public List<WordTf> GetTFsOfWord(int wordId)
        {
            using (var db = new SovaContext())
            {
                return db.WordTfs.Where(w => w.WordId == wordId).ToList();
            }
        }


        public int GetNumberOfMarkedPosts()
        {
            using (var db = new SovaContext())
            {
                return db.Marks.Count();
            }
        }

        public int GetNumberOfCommentsOfAPost(int postId)
        {
            using (var db = new SovaContext())
            {
                return db.Comments.Where(c => c.PostId == postId).Count();
            }
        }



        public int GetNumberOfHistories()
        {
            using (var db = new SovaContext())
            {
                return db.Histories.Count();
            }
        }








        // Comment Methods

        public List<Comment> GetCommentsOfAPost(int postid, int limit, int offset)
        {
            using (var db = new SovaContext())
            {
                return db.Comments.Include("User").Where(p => p.PostId == postid)
                    .OrderBy(c => c.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList(); ;

            }
        }




        // Mark Methods
        public Mark GetAMark(int markId)
        {
            using (var db = new SovaContext())
            {
                return db.Marks.Where(m => m.Id == markId).First();

            }
        }

        public void Mark(Mark mark)
        {
            using (var db = new SovaContext())
            {
                db.Marks.Add(mark);
                db.SaveChanges();
            }
        }

        public void Unmark(int markId)
        {
            using (var db = new SovaContext())
            {
                db.Marks.RemoveRange(db.Marks.Where(x => x.Id == markId));
                db.SaveChanges();
            }
        }

        public void DeleteAllMarks()
        {
            using (var db = new SovaContext())
            {

                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Mark");
                db.SaveChanges();
            }
        }



        public List<Mark> GetMarkedPosts(int limit, int offset)
        {
            using (var db = new SovaContext())
            {

                return db.Marks.Include("Post").OrderBy(m => m.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        // User Methods

        public User GetUserById(int id)
        {
            using (var db = new SovaContext())
            {
                return db.Users.Where(u => u.Id == id).First();

            }
        }








        // History Methods
        public void AddToHistory(History history)
        {
            using (var db = new SovaContext())
            {
                history.Id = db.Histories.Max(c => c.Id) + 1;
                db.Histories.Add(history);
                db.SaveChanges();
            }
        }

        public History GetAHistory(int? id)
        {
            using (var db = new SovaContext())
            {
                return db.Histories.FirstOrDefault(u => u.Id == id);

            }
        }

        public void DeleteFromHistory(int? id)
        {
            using (var db = new SovaContext())
            {
                db.Histories.RemoveRange(db.Histories.Where(x => x.Id == id));
                db.SaveChanges();
            }
        }

        public void DeleteAllHistory()
        {
            using (var db = new SovaContext())
            {

                db.Database.ExecuteSqlCommand("TRUNCATE TABLE History");
                db.SaveChanges();
            }
        }

        public List<History> GetAllHistory(int limit, int offset)
        {
            using (var db = new SovaContext())
            {
                /* List<History> history = new List<History>();
                 var _history = db.Set<History>();
                 foreach (var historyEntity in _history)
                 {
                     history.Add(historyEntity);
                 }

                 return history;*/

                return db.Histories.OrderBy(h => h.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }

        }

        // Post methods
        public Post GetAPost(int postId)
        {
            using (var db = new SovaContext())
            {
                var post =  db.Posts.Where(p => p.Id == postId).First();
                //post.Comments = GetCommentsOfAPost(postId);
                return post;


            }
        }

        public List<Post> GetAllRelatedPosts(int postId)
        {
            List<Post> posts = new List<Post>();
            Post post = GetAPost(postId);

            using (var db = new SovaContext())
            {
                if (GetAPost(postId).ParentId == null)
                {
                    posts = db.Posts.Where(p => p.ParentId == postId).ToList();
                    posts.Add(post);
                    posts.OrderBy(p => p.CreationDate);
                    posts.Reverse();
                    return posts;
                }
                else
                {

                    posts = db.Posts.Where(p => p.ParentId == post.ParentId).ToList();
                    posts.Add(post);
                    posts.Add(GetAPost(post.ParentId.Value));
                    posts.OrderBy(p => p.CreationDate);
                    posts.Reverse();
                    return posts;

                }



            }
        }
    }

}

