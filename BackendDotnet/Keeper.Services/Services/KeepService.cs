﻿using Keeper.Common.Enums;
using Keeper.Common.Response;
using Keeper.Common.View_Models;
using Keeper.Common.ViewModels;
using Keeper.Context.Model;
using Keeper.Repos.Interfaces;
using Keeper.Repos.Repositories.Interfaces;
using Keeper.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Services.Services
{
    public class KeepService:IKeepService
    {
        private readonly IKeepRepo _repo;
        private readonly ITagService _tagService;
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        public KeepService(IKeepRepo repo, ITagService tagService,IUserRepo userRepo, IMailService mailService)
        {
            _repo = repo;
            _tagService = tagService;
            _userRepo = userRepo;
            _mailService = mailService;
        }

        public async Task<ResponseModel<string>> DeleteByIdAsync(Guid Id)
        {
            await _repo.DeleteByIdAsync(Id); 
            return new ResponseModel<string>()
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "keep Deleted",
            };
        }

        public async Task<ResponseModel<List<KeepModel>>> GetAllAsync(Guid ProjectId)
        {
            var result = await _repo.GetAllAsync(ProjectId);

            return new ResponseModel<List<KeepModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Message = "All Keeps",
                Data = result
            };
        }

        public async Task<ResponseModel<KeepModel>> GetByIdAsync(Guid Id)
        {
            var result = await _repo.GetByIdAsync(Id);

            return new ResponseModel<KeepModel>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };
        }

        public async Task<ResponseModel<List<KeepModel>>> GetByTagAsync(Guid userId, Guid tagId)
        {
            var result = await _repo.GetByTagAsync(userId, tagId);
            return new ResponseModel<List<KeepModel>>
            {
                StatusName = StatusType.SUCCESS,
                IsSuccess = true,
                Data = result
            };
        }
        public async Task<ResponseModel<string>> SaveAsync(KeepVM keep)
            {
            List<UserModel> users = new();
            List<KeepModel> keeps = new();

            var tagId = Guid.NewGuid();
            if (keep.TagTitle != null && keep.TagTitle!="") 
            {
                var tagdata = await _tagService.GetByTitleAsync(keep.TagTitle);
                if (tagdata.Data == null)
                {
                    TagModel tag = new TagModel()
                    {
                        Id = tagId,
                        Title = keep.TagTitle,
                        Type = TagType.KEEP
                    };
                    await _tagService.SaveAsync(tag);
                }
                else
                {
                    tagId = tagdata.Data.Id;
                }
            }
            else
            {
                tagId=Guid.Empty;
            }
            KeepModel model = new KeepModel();
            {
                model.Title=keep.Title;
                model.CreatedOn = DateTime.Now;
                model.CreatedBy= keep.CreatedBy;
                model.ProjectId = keep.ProjectId;
                model.TagId = tagId;
            };
            UserModel user= await _userRepo.GetByIdAsync(model.CreatedBy);
            users.Add(user);
            keeps.Add(model);
            model.Users = users;
            user.Keeps = keeps;
            _userRepo.UpdateUser(user);
            var response=await _repo.SaveAsync(model);
            if (keep.mail != null)
            {
                MailRequest mail = keep.mail;
                foreach(var mailid in mail.ToEmail)
                {
                    UserModel userdata= await _userRepo.GetByEmailAsync(mailid);
                    users.Add(userdata);
                    response.Users= users;
                    userdata.Keeps= keeps;
                    _repo.UpdatedAsync(response);
                    _userRepo.UpdateUser(userdata);

                }
                mail.TypeId = response.Id;
                await _mailService.SendEmailAsync(mail);
            }
            {
                return new ResponseModel<string>
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "keep Created SuccessFully",
                };
            }
        }

        public async Task<ResponseModel<string>> UpdatedAsync(KeepVM keep)
        {
            var tagid = Guid.NewGuid();
            if (keep.TagTitle != null && keep.TagTitle != "")
            {
                var tagdata = await _tagService.GetByTitleAsync(keep.TagTitle);
                if (tagdata.Data == null)
                {
                    TagModel tag = new TagModel()
                    {
                        Id = tagid,
                        Title = keep.TagTitle,
                        Type = TagType.PROJECT
                    };
                    await _tagService.SaveAsync(tag);
                }
                else
                {
                    tagid = tagdata.Data.Id;

                }
            }
            else
            {
                tagid = Guid.Empty;
            }
            KeepModel existingModel = await _repo.GetByIdAsync((Guid)keep.Id!);
            existingModel.Id = (Guid)keep.Id!;
            existingModel.Title = keep.Title;
            existingModel.UpdatedOn = DateTime.Now;
            existingModel.UpdatedBy = (Guid)keep.UpdatedBy!;
            existingModel.TagId=tagid;
            await _repo.UpdatedAsync(existingModel);
            {
                return new ResponseModel<string>()
                {
                    StatusName = StatusType.SUCCESS,
                    IsSuccess = true,
                    Message = "keep Updated SuccessFully",
                };
            }

        }
    }
}
