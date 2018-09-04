using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Posto_de_Combustivel.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                      "~/Content/TemplateADMIN/assets/vendor/jquery/jquery.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/pace/pace.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap-progressbar/js/bootstrap-progressbar.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/Flot/jquery.flot.js",
                      "~/Content/TemplateADMIN/assets/vendor/Flot/jquery.flot.resize.js",
                      "~/Content/TemplateADMIN/assets/vendor/Flot/jquery.flot.time.js",
                      "~/Content/TemplateADMIN/assets/vendor/flot.tooltip/jquery.flot.tooltip.js",
                      "~/Content/TemplateADMIN/assets/vendor/x-editable/bootstrap3-editable/js/bootstrap-editable.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery.maskedinput/jquery.maskedinput.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/moment/min/moment.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-sparkline/js/jquery.sparkline.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap-tour/js/bootstrap-tour.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/widget.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/data.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/scroll-parent.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/disable-selection.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/widgets/mouse.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-ui/ui/widgets/sortable.js",
                      "~/Content/TemplateADMIN/assets/vendor/datatables/js-main/jquery.dataTables.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/datatables/js-bootstrap/dataTables.bootstrap.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jquery-appear/jquery.appear.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jqvmap/jquery.vmap.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/jqvmap/maps/jquery.vmap.world.js",
                      "~/Content/TemplateADMIN/assets/vendor/jqvmap/maps/jquery.vmap.usa.js",
                      "~/Content/TemplateADMIN/assets/vendor/chart-js/Chart.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/raphael/raphael.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/justgage-toorshia/justgage.js",
                      "~/Content/TemplateADMIN/assets/scripts/klorofilpro-common.js",
                      "~/Content/TemplateADMIN/assets/vendor/datatables/js-main/jquery.dataTables.min.js",
                      "~/Content/TemplateADMIN/assets/vendor/datatables/js-main/jquery-3.3.1.js",
                      "~/Content/TemplateADMIN/assets/scripts/moment.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/TemplateADMIN/assets/vendor/font-awesome/css/font-awesome.css",
                      "~/Content/TemplateADMIN/assets/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/TemplateADMIN/assets/vendor/themify-icons/css/themify-icons.css",
                      "~/Content/TemplateADMIN/assets/vendor/pace/themes/orange/pace-theme-minimal.css",
                      "~/Content/TemplateADMIN/assets/css/vendor/animate/animate.min.css",
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                      "~/Content/TemplateADMIN/assets/vendor/x-editable/bootstrap3-editable/css/bootstrap-editable.css",
                      "~/Content/TemplateADMIN/assets/vendor/bootstrap-tour/css/bootstrap-tour.min.css",
                      "~/Content/TemplateADMIN/assets/vendor/jqvmap/jqvmap.min.css",
                      "~/Content/TemplateADMIN/assets/css/main.css",
                      "~/Content/TemplateADMIN/assets/css/skins/sidebar-nav-darkgray.css",
                      "~/Content/TemplateADMIN/assets/css/skins/navbar3.css",
                      "~/Content/TemplateADMIN/assets/css/demo.css",
                      "~/Content/TemplateADMIN/demo-panel/style-switcher.css",
                      "~/Content/TemplateADMIN/assets/vendor/datatables/css-main/jquery.dataTables.min.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}