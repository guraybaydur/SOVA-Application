using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceLayer.Util
{
    public class Util
    {
        public static class Config
        {
            public const string CommentsRoute = "CommentApi";
            public const string PostsRoute = "PostApi";
            public const string SearchRoute = "SearchApi";
            public const string HistoriesRoute = "HistoryApi";
            public const string MarksRoute = "MarkApi";
            public const string UsersRoute = "UserApi";

            public const int DefaultPageSize = 30;
        }
    }
}