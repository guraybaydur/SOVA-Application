(function () {
    requirejs.config({
        baseUrl: 'scripts',
        paths: {
            knockout: 'lib/knockout-3.4.0',
            jquery: 'lib/jquery-2.2.3.min',
            text: 'lib/text',
            bootstrap: 'lib/bootstrap.min'
        }
    });
})();

require(['knockout', 'app/viewmodel', 'app/config'], function (ko, vm, config) {

    ko.components.register(config.menuComponent, {
        viewModel: { require: 'app/components/menu/menuViewmodel' },
        template: { require: 'text!app/components/menu/menu.html' }
    });

    ko.components.register(config.marksComponent, {
        viewModel: { require: 'app/components/marks/marksViewmodel' },
        template: { require: 'text!app/components/marks/marks.html' }
    });

    ko.components.register(config.historiesComponent, {
        viewModel: { require: 'app/components/histories/historiesViewmodel' },
        template: { require: 'text!app/components/histories/histories.html' }
    });

    ko.components.register(config.postsComponent, {
        viewModel: { require: 'app/components/posts/postsViewmodel' },
        template: { require: 'text!app/components/posts/posts.html' }
    });

    ko.components.register(config.commentsComponent, {
        viewModel: { require: 'app/components/comments/commentsViewmodel' },
        template: { require: 'text!app/components/comments/comments.html' }
    });

    ko.components.register(config.relatedpostComponent, {
        viewModel: { require: 'app/components/relatedpost/relatedpostViewmodel' },
        template: { require: 'text!app/components/relatedpost/relatedpost.html' }
    });

    ko.applyBindings(vm);
});