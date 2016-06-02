define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var marks = ko.observableArray();
        var postId = ko.observable();
        var onclick = function (postId) {
            ns.postbox.notify({ component: "relatedpost", postId: postId }, "changeToRelatedPost");
        }
        dataservice.getMarks(marks);
        var deleteSingleMark = dataservice.deleteSingleMark;
        var deleteAllMark = dataservice.deleteAllMark;

        return {
            deleteAllMark:deleteAllMark,
            postId:postId,
            onclick:onclick,
            marks: marks,
            deleteSingleMark: deleteSingleMark
        }

    };
});