Product = Backbone.Model.extend({
    idAttribute: "ProductId",

    url: function () {
        if (this.isNew())
            return "/item";
        else
            return "/item/" + this.get('ProductId');
    },

    initialize: function () {
        _.bindAll(this, "url");
    }
});