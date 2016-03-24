+(function ($, window) {
    var Item = function (element, options) {

        Item.fn._init(options);
        Item.fn.stopEventBubble();
    };

    Item.fn = Item.prototype = {
        //表单验证
        _validForm: function (element, rule) {

            this.$validForm = $(element).Validform({
                tiptype: function (msg, o, cssctl) { }
            });

            if (rule) {
                this.$validForm.addRule(rule);
            }

            return this;
        },
        js_item_add: function (element) {
            var that = this;
            var $element = $(element);
            that._validForm("#add_item_form");
            
            var formConfig = {
                ajaxpost: {
                    url: "/Subject/Step1",
                    data: that.$validForm.forms.serialize(),
                    success: function (data) {
                        if (data.code === 200) {
                            //_dialog.modal.close();
                            //that.noty(data.message, "information");
                            alert(data.message);
                            window.location.href = "/Subject/Step2_1";

                        }
                    },
                    error: function () {
                        that.noty("操作失败，请重新尝试！", "error");
                    }
                }
            }

            that.$validForm.config(formConfig);
            //ajax 提交表单
            that.$validForm.ajaxPost(false);

            //that.stopEventBubble();
        },
        //编辑用户
        js_item_edit: function (element) {
            var that = this;
            var $this = $(element);

            //初始化模块编辑数据
            that.$sidebar.find(".entry-well-content").html($("#item_edit").tmpl(that.data));

            that.$sidebar.find("input").iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red',
                increaseArea: '10%'
            });

            that._validForm(".item-add-form");

            //取消编辑
            that.$sidebar.find("#cancel").on("click", function () {
                that.$sidebarContent.html($("#item_detail").tmpl(that.data));
                that.customScrollbar(".content");
                return false;
            });

            //编辑保存模块
            that.$sidebar.find("#sure").on("click", function () {
                alert("OK");
                var formConfig = {
                    ajaxpost: {
                        url: "/Item/Step1",
                        data: that.$validForm.forms.serialize() + "&Id=" + that.data.Id,
                        success: function (data) {
                            if (data.code === 200) {
                                var item = $('[name="ItemName"]').val();
                                $("#item_item_" + that.data.Id).find("a.entry-item-title").html(item);
                                that.show(that.options);
                                that.noty(data.message, "information");
                            }
                        },
                        error: function () {
                            that.noty("操作失败，请重新尝试！", "error");
                        }
                    }
                }

                that.$validForm.config(formConfig);
                //ajax 提交表单
                that.$validForm.ajaxPost(false);
                return false;
            });
        }
    };

    window.locator = window.locator || {};
    window.locator.openItem = Item;
    window.uv = Item.fn;

})(jQuery, this);
