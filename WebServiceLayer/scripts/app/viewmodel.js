var ns = ns || {};

ns.postbox = {
    subscribers: [],
    subscribe: function (callback, topic) {
        this.subscribers.push({ topic: topic, callback: callback });
    },
    notify: function (value, topic) {
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].topic === topic) {
                this.subscribers[i].callback(value);
            }
        }
    }
}

define(['knockout', 'app/config'], function (ko, config) {
    return (function () {
        var currentComponent = ko.observable(config.defaultMenu);
        var currentParams = ko.observable({});
        var postId = ko.observable();
        var statement = ko.observable();
        var changeComponent = function (value) {
            currentParams({ postId: value.postId });
            currentComponent(value.component);
            
        }

        var changeToRelatedPostComponent = function (value) {
            //statement(value[1]);
            currentParams({ postId: value.postId });
            currentComponent(value.component);
            //statement();
        }

        var changeToPostsComponent = function (value) {
            //statement(value[1]);
            currentParams({ statement: value.statement });
            currentComponent(value.component);
            //statement();
        }
        ns.postbox.subscribe(function (value) {
            changeComponent(value);
        }, "changeToSinglePost");

        ns.postbox.subscribe(function (value) {
            changeToPostsComponent(value);
        }, "changeToPosts");
        ns.postbox.subscribe(function (value) {
            changeToRelatedPostComponent(value);
        }, "changeToRelatedPost");

        

        return {
            currentParams:currentParams,
            statement:statement,
            postId: postId,
            changeComponent: changeComponent,
            currentComponent: currentComponent,
            menuComponent: config.menuComponent
        }
    });
});