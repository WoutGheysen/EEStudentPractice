using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerCrudBase<Question, QuestionRepository>
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly QuestionCategoryRepository _questionCategoryRepo;
        private readonly AnswerRepository _answerRepo;
        private readonly FeedbackRepository _feedBackRepo;
        public QuestionController(QuestionRepository questionRepository, QuestionCategoryRepository qcRepo, AnswerRepository aRepo, FeedbackRepository fRepo, IHostingEnvironment hostingEnvironment) : base(questionRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _questionCategoryRepo = qcRepo;
            _answerRepo = aRepo;
            _feedBackRepo = fRepo;
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllInclusive());
        }

        [HttpGet]
        [Route("{id}")]
        public override async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetIdInclusive(id));
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

        //Get First Grade language Questions (With Answer and Feedback)
        [HttpGet]
        [Route("LangFirstGradeQuestions")]
        public async Task<IActionResult> GetLangFirstGradeQuestions()
        {
            return Ok(await _repository.ListLangFirstGradeQuestions());
        }

        //Create First Grade language Questions (With Answer and Feedback)
        [HttpPost]
        [Route("LangFirstGradeQuestions")]
        public async Task<IActionResult> CreateLangFirstGradeQuestions(LangFirstGradeQuestionDto fullQuestion)
        {
            if (ModelState.IsValid)
            {
                var category = await _questionCategoryRepo.GetById(fullQuestion.QuestionCategory);
                var answer = new Answer()
                {
                    LangAnswer = fullQuestion.Answer
                };
                await _answerRepo.Add(answer);

                var question = new Question()
                {
                    QuestionTitle = fullQuestion.QuestionTitle,
                    FileName = fullQuestion.FileName,
                    Answer = answer,
                    QuestionCategory = category
                };
                await _repository.Add(question);

                foreach (var item in fullQuestion.Feedback)
                {
                    var feedback = new Feedback()
                    {
                        Description = item.Description,
                        Question = question
                    };
                    await _feedBackRepo.Add(feedback);
                }
                return Ok();
            }
            return BadRequest();
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
        public override async Task<IActionResult> Put([FromRoute] int id, Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != question.Id)
            {
                return BadRequest();
            }

            Question updatedEntity = await _repository.Update(question);
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

        
        [HttpPost]
        public override async Task<IActionResult> Post([FromBody]  Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            Answer answer = question.Answer;
            if (answer != null)
            {
                answer = await _answerRepo.Add(answer);
                question.AnswerId = answer.Id;
                question.Answer = null;
            }

            QuestionCategory questionCategory = question.QuestionCategory;
            if (questionCategory != null)
            {
                questionCategory = await _questionCategoryRepo.AddOrUpdate(questionCategory);
                question.QuestionCategoryId = questionCategory.Id;
                question.QuestionCategory = null;
            };

            ICollection<Feedback> feedbackCollection = question.Feedback;
            question.Feedback = null;

            Question createdEntity = await _repository.AddOrUpdate(question);

            if (createdEntity == null)
            {   
                return NotFound();
            }
            
            if (feedbackCollection != null)
            {
                foreach (Feedback item in feedbackCollection)
                {
                    item.QuestionId = createdEntity.Id;
                }

                feedbackCollection = await _feedBackRepo.AddOrUpdateCollection(feedbackCollection);
            }

            question.Feedback = feedbackCollection;

            return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
        }
        
    }
}