using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerCrudBase<Question, QuestionRepository>
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public QuestionController(QuestionRepository questionRepository, IHostingEnvironment hostingEnvironment) : base(questionRepository)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllInclusive());
        }

        #region AutoMapper Methods
        //Get MathQuestions for FirstGrade
        [HttpGet]
        [Route("MathFirstGradeQuestions")]
        public async Task<IActionResult> GetMathFirstGradeQuestions()
        {
            return Ok(await _repository.ListMathFirstGradeQuestions());
        }

        //Get MathQuestions for FirstGrade
        [HttpGet]
        [Route("MathSecondGradeQuestions")]
        public async Task<IActionResult> GetMathSecondGradeQuestions()
        {
            return Ok(await _repository.ListMathSecondGradeQuestions());
        }

        //Get First Grade language Questions (And Answers)
        [HttpGet]
        [Route("LangFirstGradeQuestions")]
        public async Task<IActionResult> GetLangFirstGradeQuestions()
        {
            return Ok(await _repository.ListLangFirstGradeQuestions());
        }

        //Get Second Grade Language Questions (And Answers)
        [HttpGet]
        [Route("LangSecondGradeQuestions")]
        public async Task<IActionResult> GetLangSecondGradeQuestions()
        {
            return Ok(await _repository.ListLangSecondGradeQuestions());
        }

        //Get Third Grade Language Questions (And Answers)
        [HttpGet]
        [Route("LangThirdGradeQuestions")]
        public async Task<IActionResult> GetLangThirdGradeQuestions()
        {
            return Ok(await _repository.ListLangThirdGradeQuestions());
        }
        #endregion
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put([FromRoute] int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != question.Id)
            {
                return BadRequest();
            }

            Question updatedEntity = await _repository.UpdateAllInclusive(question);
            if (updatedEntity == null)
            {
                return NotFound();
            }
            return Ok(updatedEntity);
        }

        [HttpPost]
        [Route("Image")]
        public async Task<IActionResult> Image(IFormFile formFile)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images/Questions", formFile.FileName);

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            return Ok(new { count = 1, formFile.Length });

        }
    }
}