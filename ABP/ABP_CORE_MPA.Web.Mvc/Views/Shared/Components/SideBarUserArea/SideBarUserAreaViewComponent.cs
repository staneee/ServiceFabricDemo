﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Configuration.Startup;
using ABP_CORE_MPA.Sessions;

namespace ABP_CORE_MPA.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewComponent : ABP_CORE_MPAViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public SideBarUserAreaViewComponent(ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig)
        {
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
            };

            return View(model);
        }
    }
}
