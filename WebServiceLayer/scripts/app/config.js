define([], function () {
    var server = 'http://localhost:57487';
    var menuElements = ["Marks", "Histories"];
    return {
        // backend routes
        markurl: server + "/api/mark/",
        historyurl: server + "/api/history/",
        searchurl: server + "/api/search/",
        commenturl: server + "/api/comment/GetCommentsOfAPost/",
        relatedPostUrl: server + "/api/post/GetRelatedPosts/",
        userUrl: server + "/api/post/GetRelatedPosts/",
        // menu
        menuElements: menuElements,
        defaultMenu: menuElements[1].toLowerCase(),

        // components
        menuComponent: "menu",
        marksComponent: menuElements[0].toLowerCase(),
        historiesComponent: menuElements[1].toLowerCase(),
        postsComponent: "posts",
        commentsComponent: "comments",
        relatedpostComponent: "relatedpost",
        userComponent:"user"
    }
});