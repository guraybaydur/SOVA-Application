using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using AutoMapper;
using DomainModel;
using WebServiceLayer.Models;
using WebServiceLayer.Util;

namespace WebServiceLayer.Models
{
    public static class ModelFactory
    {
        private static readonly IMapper HistoryMapper;
        private static readonly IMapper CommentMapper;
        private static readonly IMapper MarkMapper;
        private static readonly IMapper PostMapper;
        private static readonly IMapper UserMapper;
        private static readonly IMapper SearchMapper;

        static ModelFactory()
        {
            var searchCfg = new MapperConfiguration(cfg => cfg.CreateMap<Search, SearchModel>());
            SearchMapper = searchCfg.CreateMapper();

            var historyCfg = new MapperConfiguration(cfg => cfg.CreateMap<History, HistoryModel>());
            HistoryMapper = historyCfg.CreateMapper();

            var userCfg = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            UserMapper = userCfg.CreateMapper();

            var markCfg = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkModel>());
            MarkMapper = markCfg.CreateMapper();

            var postCfg = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostModel>());
            PostMapper = postCfg.CreateMapper();

            var commentCfg = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            //.ForMember(d => d.PostId, opt => opt.MapFrom(s => s.PostId)));
            CommentMapper = commentCfg.CreateMapper();
        }


        public static SearchModel Map(Search post, UrlHelper urlHelper)
        {
            if (post == null) return null;

            var searchModel = SearchMapper.Map<SearchModel>(post);
            searchModel.Url = urlHelper.Link(Util.Util.Config.SearchRoute, new { post.Id });

            return searchModel;
        }

        public static HistoryModel Map(History history, UrlHelper urlHelper)
        {
            if (history == null) return null;

            var historyModel = HistoryMapper.Map<HistoryModel>(history);
            historyModel.Url = urlHelper.Link(Util.Util.Config.HistoriesRoute, new { history.Id });

            return historyModel;
        }

        public static UserModel Map(User user, UrlHelper urlHelper)
        {
            if (user == null) return null;

            var userModel = UserMapper.Map<UserModel>(user);
            userModel.Url = urlHelper.Link(Util.Util.Config.UsersRoute, new { user.Id });

            return userModel;
        }

        public static MarkModel Map(Mark mark, UrlHelper urlHelper)
        {
            if (mark == null) return null;

            var markModel = MarkMapper.Map<MarkModel>(mark);
            markModel.Url = urlHelper.Link(Util.Util.Config.MarksRoute, new { mark.Id });

            return markModel;
        }

        public static PostModel Map(Post post, UrlHelper urlHelper)
        {
            if (post == null) return null;

            var postModel = PostMapper.Map<PostModel>(post);
            postModel.Url = urlHelper.Link(Util.Util.Config.PostsRoute, null);

            return postModel;
        }

        public static CommentModel Map(Comment comment, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Util.Util.Config.CommentsRoute, new { comment.PostId });

            return commentModel;
        }
    }
}