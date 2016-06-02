define(['knockout', 'app/config'], function (ko, config) {
    return function (params) {
        var currentComponent = params.currentComponent;
        var currentParams = params.currentParams;
        var isMenuSelected = function (content) {
            return content && currentComponent() === content.toLowerCase();
        };

        var changeContent = function (content) {
            currentComponent(content.toLowerCase());
        };

        

        var searchStatement = ko.observable();

        var changeToSearchContent = function () {
            
           // if (currentComponent() === "posts") {
                //currentComponent("comments");
           /////     currentComponent("posts");
            // }
            currentParams({ statement: searchStatement() });
            currentComponent("posts");
            
        };

        var changeToCommentsContent = function () {


            currentComponent("comments");

        };

        var changeToUserContent = function () {


            currentComponent("user");

        };


        changeContent(config.defaultMenu);

        //var searchStatement = ko.observable();

        //var getSearchResults = function (){return function (statement){pvm.getSearchResults(statement);}}

        return {
            //getSearchResults:getSearchResults,
            // searchStatement:searchStatement,
            changeToUserContent:changeToUserContent,
            changeToCommentsContent:changeToCommentsContent,
            searchStatement:searchStatement,
            changeToSearchContent: changeToSearchContent,
            menuElements: config.menuElements,
            currentComponent: currentComponent,
            changeContent: changeContent,
            isMenuSelected: isMenuSelected
            //currentViewModel: currentViewModel
        }
    };
});