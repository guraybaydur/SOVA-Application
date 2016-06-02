define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var postId = params.postId;
        var relatedPosts = ko.observableArray();
        dataservice.getRelatedPosts(relatedPosts, postId);


        var commentsOfThisPostExists = ko.observable(false);

       // var comments = ko.observableArray();

        //var commentsExists = function (id) {
        //    dataservice.getCommentsOfAPost(comments(), id);
        //    if (comments().length === 0)
        //        return false;
        //    return true;
        //}


        //var isSelected = ko.observable(false);
        //var onclick = function () {
        //    ns.postbox.notify("comments", "changeToSinglePost");
        //}

        //var searchStatement = $('#searchInput').val();
        //var searchResults = ko.observableArray();
        //var noteToAdd = ko.observable();
        //var addMarkedPost = function (id, note) {
        //    dataservice.addMarkedPost(id, note);
        //}

        //var anyMarked = ko.computed(function () {
        //    //return false;
        //    return ko.utils.arrayFirst(searchResults(), function (item) { return item.IsMarked() === true }) !== null;
        //});

        //dataservice.getSearchResults(searchResults, searchStatement);
        //dataservice.addToHistory(searchStatement);


        return {
            postId: postId,
            relatedPosts: relatedPosts,
            commentsOfThisPostExists: commentsOfThisPostExists,
            //checkCommentsExists: checkCommentsExists
            //onclick: onclick,
            ////searchStatement: searchStatement,
            //isSelected: isSelected,
            //anyMarked: anyMarked,
            //addMarkedPost: addMarkedPost,
            //noteToAdd: noteToAdd,
            //searchResults: searchResults
            //searchResults: dataservice.getSearchResults(this.searchStatement)
            //getSearchResults:getSearchResults
        }

    };
});