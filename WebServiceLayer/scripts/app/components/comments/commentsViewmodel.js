define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        //var postId = ko.observable(params.postId);
        var comments = ko.observableArray([]);

      

        var postId = params.postId();
       if (postId != undefined) {
           dataservice.getCommentsOfAPost(comments, postId);
           console.log(comments().length);
       }
       
       else {
           console.log(postId);
       }


        return {
            //searchStatement: searchStatement,
            comments:comments,
           
            postId:postId
            //searchResults: dataservice.getSearchResults(this.searchStatement)
            //getSearchResults:getSearchResults
        }

    };
});