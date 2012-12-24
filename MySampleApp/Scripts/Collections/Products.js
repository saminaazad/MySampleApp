Products = Backbone.Collection.extend({
    model: Product,

    initialize: function () {
        _.bindAll(this, "url");
    },

    url: function () {
        return "/items";
    }
});