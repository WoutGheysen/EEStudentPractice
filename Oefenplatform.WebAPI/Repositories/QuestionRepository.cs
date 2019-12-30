using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Oefenplatform.Lib.DTO;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Constants;
using Oefenplatform.WebAPI.Data;
using Oefenplatform.WebAPI.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories
{
    public class QuestionRepository : RepositoryMapping<Question>
    {
        private readonly QuestionCategoryRepository _repo;
        public QuestionRepository(OefenplatformContext oefenplatformContext, IMapper mapper, QuestionCategoryRepository repo) :base (oefenplatformContext, mapper)
        {
            _repo = repo;
        }
        #region AutoMapper Methods
        /// <summary>
        /// Returns Math Questions First Grade
        /// </summary>
        public async Task<List<MathFirstGradeQuestionDto>> ListMathFirstGradeQuestions()
        {
            return await _oefenplatformContext.Questions.Where(a => a.QuestionCategory.CategoryQuestion == 
            QuestionCategories.MathQuestionFirstGrade)
            .ProjectTo<MathFirstGradeQuestionDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        /// <summary>
        /// Returns Math Questions Second Grade
        /// </summary>
        public async Task<List<MathSecondGradeQuestionDto>> ListMathSecondGradeQuestions()
        {
            return await _oefenplatformContext.Questions.Where(a => a.QuestionCategory.CategoryQuestion == 
            QuestionCategories.MathQuestionSecondGrade)
            .ProjectTo<MathSecondGradeQuestionDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        /// <summary>
        /// Returns Language Questions First Grade
        /// </summary>
        public async Task<List<LangFirstGradeQuestionDto>> ListLangFirstGradeQuestions()
        {
            return await _oefenplatformContext.Questions.Where(a => a.QuestionCategory.CategoryQuestion == 
            QuestionCategories.LangQuestionFirstGrade)
            .ProjectTo<LangFirstGradeQuestionDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        /// <summary>
        /// Returns Language Questions Second Grade
        /// </summary>
        public async Task<List<LangSecondGradeQuestionDto>> ListLangSecondGradeQuestions()
        {
            return await _oefenplatformContext.Questions.Where(a => a.QuestionCategory.CategoryQuestion == 
            QuestionCategories.LangQuestionSecondGrade)
            .ProjectTo<LangSecondGradeQuestionDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        /// <summary>
        /// Returns Language Questions Third Grade
        /// </summary>
        public async Task<List<LangThirdGradeQuestionDto>> ListLangThirdGradeQuestions()
        {
            return await _oefenplatformContext.Questions.Where(a => a.QuestionCategory.CategoryQuestion == 
            QuestionCategories.LangQuestionThirdGrade)
            .ProjectTo<LangThirdGradeQuestionDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        #endregion
        public async Task<List<Question>> GetAllInclusive()
        {
            return await GetAll()
               .Include(q => q.Answer)
               .Include(q => q.QuestionCategory)
               .ToListAsync();
        }

        public async Task<Question> UpdateAllInclusive(Question question)
        {
            var questionAnswer = question.Answer;

            _oefenplatformContext.Entry(questionAnswer).State = EntityState.Modified;
            _oefenplatformContext.Entry(question).State = EntityState.Modified;
            try
            {
                await _oefenplatformContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return question;
        }
    }
}
