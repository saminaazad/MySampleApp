var ProductListView = Backbone.View.extend({
    initialize: function () {
        var self = this;
        this.listItemViews = [];

        this.collection.each(function (donut) {
            self.listItemViews.push(new ProductListItemView({
                model: donut
            }));
        });
    },

    render: function () {
        var self = this;
        $(this.el).empty();

        _(this.listItemViews).each(function (itemView) {
            $(self.el).append(itemView.render().el);
        });
    }
});

var ProductListItemView = Backbone.View.extend({
    tagName: "div",

    initialize: function () {
        this.render();
    },

    render: function () {
        var url = '/products/' + this.model.get("ProductId");
        var link = $("<a></a>").attr("href", url).html(this.model.get("ProductName"));
        $(this.el).html(link);
        return this;
    }
});