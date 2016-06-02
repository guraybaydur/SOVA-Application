define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var histories = ko.observableArray();

        dataservice.getHistories(histories);

        var onclick = function (statement) {
            ns.postbox.notify({ component: "posts", statement: statement }, "changeToPosts");
        }

        var deleteAllHistory = dataservice.deleteAllHistory;
        var deleteSingleHistory = dataservice.deleteSingleHistory;
     
        return {
            onclick:onclick,
            histories: histories,
            deleteAllHistory: deleteAllHistory,
            deleteSingleHistory: deleteSingleHistory
        }

    };
});