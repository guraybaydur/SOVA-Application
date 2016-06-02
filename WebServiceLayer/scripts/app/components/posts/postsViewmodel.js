define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var statement = params.statement;

        var isSelected = ko.observable(false);
        var onclick = function (id) {
            ns.postbox.notify({postId : id, component: "relatedpost"}, "changeToSinglePost");
        }

        var searchStatement = ko.observable();
        var searchResults = ko.observableArray();
        var noteToAdd = ko.observable();
        //var i = ko.observable(0);
        var addMarkedPost = function (id, note) {
            dataservice.addMarkedPost(id, note);
        }

        var anyMarked = ko.computed(function () {
            //return false;
            return ko.utils.arrayFirst(searchResults(), function (item) { return item.IsMarked() === true }) !== null;
        });

        if (params.statement == undefined) {
            dataservice.getSearchResults(searchResults, searchStatement());
            //dataservice.addToHistory(searchStatement());
        } else {

            dataservice.getSearchResults(searchResults, statement);
           
            //params.statement = undefined;
            //dataservice.addToHistory(statement);
        }
        


        return {
            //i:i,
            statement: statement,
            onclick: onclick,
            //searchStatement: searchStatement,
            isSelected: isSelected,
            anyMarked: anyMarked,
            addMarkedPost: addMarkedPost,
            noteToAdd: noteToAdd,
            searchResults: searchResults
            //searchResults: dataservice.getSearchResults(this.searchStatement)
            //getSearchResults:getSearchResults
        }

    };
});