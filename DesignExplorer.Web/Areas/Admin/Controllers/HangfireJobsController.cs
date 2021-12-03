using DesignExplorer.DataAccess;
using DesignExplorer.Web.Areas.Admin.Models;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignExplorer.Web.Areas.Admin.Controllers
{
    public class HangfireJobsController : BaseController
    {
        // GET: Admin/HangfireJobs
        public ActionResult Index()
        {
            return View(new Models.HangFireJobsViewModel());
        }

        [HttpPost]
        public ActionResult Index(List<int> selected)
        {
            if (selected != null && selected.Any())
            {
                foreach (var item in selected)
                {
                    // minutes, hours, days, months, days of week
                    switch ((HangFireJobsViewModel.JobEnum)item)
                    {
                        case HangFireJobsViewModel.JobEnum.SendEmail:
                            RecurringJob.AddOrUpdate<Function>("Send Email", ss => ss.SendEmail(), Cron.Hourly());
                            break;
                            //case HangFireJobsViewModel.JobEnum.SendEmail:
                            //    RecurringJob.AddOrUpdate<Functions>("Send Email", fs => fs.SendAlertNotificationAsync(), Cron.Hourly());
                            //    break;
                    }
                }

                return RedirectToAction("recurring", "hangfire", new { area = "" });
            }


            return Content("Completed");
        }
    }
}