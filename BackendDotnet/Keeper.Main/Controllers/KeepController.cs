﻿using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Services.Services;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class KeepController : ControllerBase
    {
        private readonly IKeepService _keepService;
        public KeepController(IKeepService keepService)
        {
            _keepService = keepService;
        }
        [HttpPost("")]
        public async Task<ResponseModel<string>> Post(KeepVM keep)
        {
            return await _keepService.SaveAsync(keep);
        }
        [HttpGet("")]
        public async Task<ResponseModel<List<KeepModel>>> GetAll(Guid ProjectId)
        {
            return await _keepService.GetAllAsync(ProjectId);

        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ResponseModel<KeepModel>> GetById(Guid Id)
        {
            return await _keepService.GetByIdAsync(Id);

        }
        [HttpPut]
        public async Task<ResponseModel<string>> Update(KeepVM keep)
        {
            return await _keepService.UpdatedAsync(keep);
        }
        [HttpDelete("{Id}")]
        public async Task<ResponseModel<string>> Delete(Guid Id)
        {
            return await _keepService.DeleteByIdAsync(Id);
        }

    }
}
