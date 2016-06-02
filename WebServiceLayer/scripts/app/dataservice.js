define(['jquery', 'app/config','knockout'], function ($, conf,ko) {
    return {

        getRelatedPosts: function(callback,id) {
            var url = conf.relatedPostUrl + id;
            $.getJSON(url, function(data) {
                function RelatedPost(title, body, userId, creationDate, url, id, isChecked, tags) {
                    this.Title = title;
                    this.Body = body;
                    this.UserId = userId;
                    this.CreationDate = creationDate;
                    this.Url = url;
                    this.Id = ko.observable(id);
                    this.Tags = tags;
                    this.isChecked = isChecked;
                };

                for (var i = 0; i < data.length; i++) {
                    var searchItem = data[i];
                    var isChecked = ko.observable(false);
                    var searchObj = new RelatedPost(searchItem.title, searchItem.body, searchItem.userId, searchItem.creationDate, searchItem.url, searchItem.id, isChecked, searchItem.tags);
                    callback.push(searchObj);
                }
            });
        },

        getCommentsOfAPost:function(callback,id) {
            var url = conf.commenturl + id;

            
                //function SearchedPost(title, body, userId, creationDate, url, id, isMarked, tags) {
                //    this.Title = title;
                //    this.Body = body;
                //    this.UserId = userId;
                //    this.CreationDate = creationDate;
                //    this.Url = url;
                //    this.Id = id;
                //    this.Tags = tags;
                //    this.IsMarked = isMarked;
                //};
                //for (var i = 0; i < data.data.length; i++) {
                //    var searchItem = data.data[i];
                //    var isMarked = ko.observable(false);
                //    var searchObj = new SearchedPost(searchItem.title, searchItem.body, searchItem.userId, searchItem.creationDate, searchItem.url, searchItem.id, isMarked, searchItem.tags);
                //    callback.push(searchObj);
                //}
                $.getJSON(url, function (data) {
                    callback(data.data);
                });
            //console.log(callback().length);
        },

        //addToHistory: function (stmt) {
        //    $.ajax({
        //        type: 'POST',
        //        url: conf.historyurl + stmt,
        //        data: {
        //            statement: stmt
        //        },
        //        success: function () {
        //            console.log("History added to History List");
        //        },
        //        error: function () {
        //            alert("History cannot be added");
        //        }
        //    });
        //},

        deleteAllHistory: function () {
            $.ajax({
                type: 'DELETE',
                url: conf.historyurl,
                success: function () {
                    console.log("All History successfully deleted");
                    location.reload();
                },
                error: function () {
                    alert("Histories cannot be deleted");
                }
            });
        },

        deleteSingleHistory: function (id) {
            $.ajax({
                type: 'DELETE',
                url: conf.historyurl + id,
                success: function () {
                    console.log("The History successfully deleted");
                    location.reload();
                },
                error: function () {
                    alert("History cannot be deleted");
                }
            });
        },

        getHistories: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.historyurl;
            }
            $.getJSON(url, function (data) {
                callback(data.data);
            });
        },

        deleteSingleMark: function (id) {
            $.ajax({
                type: 'DELETE',
                url: config.markurl + id,
                success: function () {
                    console.log("Mark successfully deleted");
                    //conf.defaultMenu = "marks";

                    //location.reload();
                    alert("Mark successfully deleted");
                },
                error: function () {
                    alert("Mark cannot be deleted");
                }
            });

        },

        deleteAllMark: function () {
            $.ajax({
                type: 'DELETE',
                url: conf.markurl,
                success: function () {
                    console.log("All Mark successfully deleted");
                    location.reload();
                },
                error: function () {
                    alert("Histories cannot be deleted");
                }
            });
        },

        getMarks: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.markurl;
            }
            $.getJSON(url, function (data) {
                callback(data.data);
            });
        },
        addMarkedPost : function (postId, note) {
            $.ajax({
                type: 'POST',
                url: config.markurl,
                data: {
                    postId: postId,
                    Note: note
                },
                success: function () {
                    alert("Post added to Mark List with Annotation");
                }
            });
        },
        getSearchResults: function (callback, stmt) {
            //var $searchStatement = $('#searchValues');
            //var searchStatement = $('#link').val();
            //console.log(searchStatement);

            var url = conf.searchurl + stmt;

            $.getJSON(url, function (data) {
                function SearchedPost(title, body, userId, creationDate, url, id, isMarked,tags) {
                    this.Title = title;
                    this.Body = body;
                    this.UserId = userId;
                    this.CreationDate = creationDate;
                    this.Url = url;
                    this.Id = id;
                    this.Tags = tags;
                    this.IsMarked = isMarked;
                };
                for (var i = 0; i < data.data.length; i++) {
                    var searchItem = data.data[i];
                    var isMarked = ko.observable(false);
                    var searchObj = new SearchedPost(searchItem.title, searchItem.body, searchItem.userId, searchItem.creationDate, searchItem.url, searchItem.id, isMarked,searchItem.tags);
                    callback.push(searchObj);
                }
               
            }).error(function () { alert("Error! No search results found!!"); location.reload(); });;
        }
    }
});