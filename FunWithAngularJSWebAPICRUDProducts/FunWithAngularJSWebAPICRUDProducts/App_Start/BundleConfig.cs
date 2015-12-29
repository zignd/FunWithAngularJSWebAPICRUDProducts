using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace FunWithAngularJSWebAPICRUDProducts
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/app.js",
                "~/Scripts/app/app.config.js",
                "~/Scripts/app/app.constants.js",
                "~/Scripts/app/base/products.service.js",
                "~/Scripts/app/base/categories.service.js",
                "~/Scripts/app/base/root.controller.js",
                "~/Scripts/app/base/user.service.js",
                "~/Scripts/app/main/main.controller.js",
                "~/Scripts/app/account/signin.controller.js",
                "~/Scripts/app/account/signup.controller.js",
                "~/Scripts/app/products/product-edit.controller.js",
                "~/Scripts/app/products/product-new.controller.js",
                "~/Scripts/app/categories/list.controller.js",
                "~/Scripts/app/categories/category-edit.controller.js",
                "~/Scripts/app/categories/category-new.controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
        }
    }
}
