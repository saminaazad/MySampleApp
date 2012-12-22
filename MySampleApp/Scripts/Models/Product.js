Product = Backbone.Model.extend({
    idAttribute: "ProductId",

    url: function () {
        if (this.isNew())
            return "/items";
        else
            return "/items/" + this.get('ProductId');
    },

    initialize: function () {
        _.bindAll(this, "url");
    }
});