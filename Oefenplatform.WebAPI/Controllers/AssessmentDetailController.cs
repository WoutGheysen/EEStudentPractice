﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.DTO;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentDetailController : ControllerCrudBase<AssessmentDetail, AssessmentDetailRepository>
    {
        public AssessmentDetailController(AssessmentDetailRepository assessmentDetailRepository) : base(assessmentDetailRepository)
        {

        }

        public override async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetByIdInclusive(id));
        }
    }
}