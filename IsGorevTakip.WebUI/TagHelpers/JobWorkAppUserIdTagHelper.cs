using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsGorevTakip.WebUI.TagHelpers
{
    [HtmlTargetElement("getJobWorkAppUserId")]
    public class JobWorkAppUserIdTagHelper : TagHelper
    {
        private readonly IJobWorkService _jobWorkService;
        public JobWorkAppUserIdTagHelper(IJobWorkService jobWorkService)
        {
            _jobWorkService = jobWorkService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<JobWork> jobWorks = _jobWorkService.GetAppUserId(AppUserId);
            int is_satatus_Ok_Count = jobWorks.Where(x => x.Is_Active_Status).Count();
            int is_status_NotOk_Count = jobWorks.Where(x => !x.Is_Active_Status).Count();

            string htmlString = $"<strong> Tamamlanan görev sayısı : </strong>{is_satatus_Ok_Count} <br> <strong> Üstünde çalıştığı görev sayısı : </strong>{is_status_NotOk_Count}";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
