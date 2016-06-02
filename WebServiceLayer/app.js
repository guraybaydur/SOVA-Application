(function () {
    function History(url, id, statement, searchdate) {
        this.Url = url;
        this.Id = id;
        this.Statement = statement;
        this.SearchDate = searchdate;
    };

    function SearchedPost(title, body, userId, creationDate, url, id, isMarked) {
        this.Title = title;
        this.Body = body;
        this.UserId = userId;
        this.CreationDate = creationDate;
        this.Url = url;
        this.Id = id;
        this.IsMarked = isMarked;
    };

    function Mark(url, id, postId, postTitle, note) {
        this.PostId = postId;
        this.PostTitle = postTitle;
        this.Note = note;
        this.Url = url;
        this.Id = id;


    };

    var model = (function () {
        var self = this;
        var searchResults = ko.observableArray([]);
        var histories = ko.observableArray([]);
        var currentView = ko.observable("welcomePage");
        var searchStmt = ko.observable("");
        var singlePost = ko.observable([]);
        var marks = ko.observableArray([]);
        var noteToAdd = ko.observable("");

        var anyMarked = ko.computed(function () {
            //return false;
            return ko.utils.arrayFirst(searchResults(), function (item) { return item.IsMarked() === true }) !== null;
        });

        var deleteAllHistory = function () {
            $.ajax({
                type: 'DELETE',
                url: 'api/history/',
                success: function () {
                    console.log("All History successfully deleted");
                    location.reload();
                },
                error: function () {
                    alert("Histories cannot be deleted");
                }
            });
            currentView("welcomePage");

        }


        var deleteSingleHistory = function (id) {
            $.ajax({
                type: 'DELETE',
                url: 'api/history/' + id,
                success: function () {
                    console.log("History successfully deleted");
                    getHistories();
                    
                },
                error: function () {
                    alert("History cannot be deleted");
                }

            });
            
        }

        var deleteSingleMark = function (id) {
            $.ajax({
                type: 'DELETE',
                url: 'api/mark/' + id,
                success: function () {
                    console.log("Mark successfully deleted");
                    //location.reload();
                    getMarks();
                },
                error: function () {
                    alert("Mark cannot be deleted");
                }
            });

        }

        var searchAndAddToHistory = function () {
            addToHistory(searchStmt());
            return search();
        }

        var addToHistory = function (stmt) {
            $.ajax({
                type: 'POST',
                url: 'api/history/' + stmt,
                data: {
                    statement: stmt
                },
                success: function () {
                    console.log("History added to History List");
                },
                error: function () {
                    alert("History cannot be added");
                }
            });
        }


        var addMarkedPost = function (postId, note) {
            $.ajax({
                type: 'POST',
                url: 'api/mark',
                data: {
                    postId: postId,
                    Note: note
                },
                success: function () {
                    alert("Post added to Mark List with Annotation");
                }
            });
        }


        var search = function () {
            $.getJSON("api/search/" + searchStmt(), function(data) {
                    console.log(data);
                    for (var i = 0; i < data.data.length; i++) {
                        var searchItem = data.data[i];
                        var isMarked = ko.observable(false);
                        var searchObj = new SearchedPost(searchItem.title, searchItem.body, searchItem.userId, searchItem.creationDate, searchItem.url, searchItem.id, isMarked);
                        searchResults.push(searchObj);
                    }


                    return searchResults;
                })
                .error(alert("No search results found!");
            location.reload(););


    }

        var searchAfterClick = function (stmt) {
            //var $searchStatement = $('#searchValues');
            //var searchStatement = $('#link').val();
            //console.log(searchStatement);
            $.getJSON("api/search/" + stmt, function (data) {
                console.log(data);
                for (var i = 0; i < data.data.length; i++) {
                    var searchItem = data.data[i];
                    var isMarked = ko.observable(false);
                    var searchObj = new SearchedPost(searchItem.title, searchItem.body, searchItem.userId, searchItem.creationDate, searchItem.url, searchItem.id, isMarked);
                    searchResults.push(searchObj);
                }


                return searchResults;
            }).error(function () { alert("error"); location.reload(); });
            currentView("searchTable");

        }
        /* var getSingleHistory = function(url) 
         {
             $.getJSON(url.concat(url.indexOf("api"), url.length), function (data) {
                 while (histories.length>0) {
                     histories.pop();
                 }
                 var history = new History(data.url, data.id, data.statement, data.searchDate);
                 histories.push(history);
                 return histories;
             });
             currentView("aHistoryView");
         }*/

        //var getPost = function () {

        //}


        var getSinglePost = function (Id) {
            //var hasAMark = false;
            $.getJSON("api/post/GetAPost/" + Id, function (data) {

                //for (var i = 0; i < marks.length; i++) {
                //    if (marks[i].PostId === Id)
                //        hasAMark = true;
                //};

                var post = new SearchedPost(data.title, data.body, data.userId, data.creationDate, data.url, data.id);
                return singlePost(post);

            });
            currentView("singlePostTable");
        }

        //var getSingleMarkedPost = function (Id) {
        //    //var hasAMark = false;
        //    $.getJSON("api/post/GetAPost/" + Id, function (data) {

        //        //for (var i = 0; i < marks.length; i++) {
        //        //    if (marks[i].PostId === Id)
        //        //        hasAMark = true;
        //        //};
        //        var markedPost;
        //        for (var i = 0; i < data.length; i++) {
        //            if (marks[i].id === data.id)
        //                markedPost = marks[i];
        //        }

        //        return singlePost(markedPost);

        //    });
        //    currentView("singleMarkedPostTable");
        //}



        var getHistories = function () {
            $.getJSON("api/history", function (data) {
                //console.log(data.data[0].id);
                for (var i = 0; i < data.data.length; i++) {
                    var item = data.data[i];
                    var history = new History(item.url, item.id, item.statement, item.searchDate);
                    histories.push(history);
                }
                return histories;
            });

            currentView("historyTable");
        }

        var getMarks = function () {
            $.getJSON("api/mark", function (data) {
                //console.log(data.data[0].id);
                for (var i = 0; i < data.data.length; i++) {
                    var item = data.data[i];
                    var mark = new Mark(item.url, item.id, item.postId, item.post.title, item.note);
                    marks.push(mark);
                }
                return marks;
            });
            currentView("markTable");
        }
        //var markAPost = function() {

        //}

        return {

            //updateMark:updateMark,
            //isMarked:isMarked,
            //self:self,
            //getSingleMarkedPost:getSingleMarkedPost,
            deleteSingleMark:deleteSingleMark,
            deleteAllHistory: deleteAllHistory,
            deleteSingleHistory: deleteSingleHistory,
            addToHistory: addToHistory,
            searchAndAddToHistory: searchAndAddToHistory,
            noteToAdd: noteToAdd,
            addMarkedPost: addMarkedPost,
            anyMarked: anyMarked,
            marks: marks,
            getMarks: getMarks,
            histories: histories,
            currentView: currentView,
            getHistories: getHistories,
            getSinglePost: getSinglePost,
            singlePost: singlePost,
            searchStmt: searchStmt,
            searchResults: searchResults,
            search: search,
            searchAfterClick: searchAfterClick
        }
    });

    ko.bindingHandlers.enterkey = {
        init: function (element, valueAccessor, allBindings, viewModel) {
            var callback = valueAccessor();
            $(element).keypress(function (event) {
                var keyCode = (event.which ? event.which : event.keyCode);
                if (keyCode === 13) {
                    callback.call(viewModel);
                    return false;
                }
                return true;
            });
        }
    };

    ko.applyBindings(new model());
})();