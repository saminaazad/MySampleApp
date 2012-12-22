var ProductView = Backbone.View.extend({
    template: "#product-detail-template",

    events: {
        "click #save": "save",
        "click #new": "add",
        "click #delete": "remove"
    },

    initialize: function () {
        _.bindAll(this, "save", "add", "remove", "operationSuccess");
    },

    render: function () {
        var html = $(this.template).html();
        $(this.el).html(html);

        var self = this;
        $(this.el).find("input").each(function (index, element) {
            element.value = self.model.get(element.id);
        });
    },

    save: function () {
        if (this.model.isNew()) {
            this.model.set({ PropertyId: 0 });
        }
        var self = this;
        $(this.el).find("input").each(function (index, element) {
            if (element.id != "ProductId") {
                var map = {};
                map[element.id] = element.value;
                self.model.set(map);
            }
        });
        this.model.save({},{ success: this.operationSuccess });
    },

    operationSuccess: function () {
        location.href = "/";
    },

    add: function () {
        this.model = new Product();
        $(this.el).find("input").each(function (index, element) {
            element.value = "";
        });
    },

    remove: function () {
        this.model.destroy({ success: this.operationSuccess });
    }
});