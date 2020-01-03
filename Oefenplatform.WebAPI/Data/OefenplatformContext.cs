using Microsoft.EntityFrameworkCore;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Data
{
    public class OefenplatformContext : DbContext
    {
        public OefenplatformContext(DbContextOptions<OefenplatformContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Questions
            //Questions: Splitsoefeningen
            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 1,
                    QuestionTitle = "Trek af 5 - 3 = ",
                    QuestionCategoryId = 1,
                    StartNumber = 5,
                    AnswerId = 1,
                    Attempts = 0,
                    AssessmentId = 1,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 2,
                    QuestionTitle = "Trek af 8 - 2 = ",
                    QuestionCategoryId = 1,
                    StartNumber = 8,
                    AnswerId = 2,
                    Attempts = 0,
                    AssessmentId = 1,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 3,
                    QuestionTitle = "Trek af 4 - 1 = ",
                    QuestionCategoryId = 1,
                    StartNumber = 4,
                    AnswerId = 3,
                    Attempts = 0,
                    AssessmentId = 1,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 4,
                    QuestionTitle = "Trek af 10 - 5 = ",
                    QuestionCategoryId = 1,
                    StartNumber = 10,
                    AnswerId = 4,
                    Attempts = 0,
                    AssessmentId = 1,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 5,
                    QuestionTitle = "Trek af 9 - 3 = ",
                    QuestionCategoryId = 1,
                    StartNumber = 9,
                    AnswerId = 5,
                    Attempts = 0,
                    AssessmentId = 1,
                }
                );

            //Questions: Fotoselectie
            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 6,
                    QuestionTitle = "Wat staat er op de Foto?",
                    FileName = "KIP.png",
                    QuestionCategoryId = 2,
                    AnswerId = 6,
                    Attempts = 0,
                    AssessmentDetailId = 1,
                    AssessmentId = 2,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 7,
                    QuestionTitle = "Wat staat er op de Foto?",
                    FileName = "BOS.png",
                    QuestionCategoryId = 2,
                    AnswerId = 7,
                    AssessmentDetailId = 1,
                    Attempts = 0,
                    AssessmentId = 2,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 8,
                    QuestionTitle = "Wat staat er op de Foto?",
                    FileName = "PET.png",
                    QuestionCategoryId = 2,
                    AnswerId = 8,
                    AssessmentDetailId = 1,
                    Attempts = 0,
                    AssessmentId = 2,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 9,
                    QuestionTitle = "Wat staat er op de Foto?",
                    FileName = "GROT.png",
                    QuestionCategoryId = 2,
                    AnswerId = 9,
                    Attempts = 0,
                    AssessmentId = 2,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 10,
                    QuestionTitle = "Wat staat er op de Foto?",
                    FileName = "VLOT.png",
                    QuestionCategoryId = 2,
                    AnswerId = 10,
                    Attempts = 0,
                    AssessmentId = 2,
                }
                );

            //Questions: Begrijpend Lezen
            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 11,
                    QuestionTitle = "Vul het juiste woord in.",
                    Description = "De ... heeft een ei gelegd.",
                    QuestionCategoryId = 4,
                    AnswerId = 11,
                    Attempts = 0,
                    AssessmentId = 4,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 12,
                    QuestionTitle = "Vul het juiste woord in.",
                    Description = "De boom staat in het ... .",
                    QuestionCategoryId = 4,
                    AnswerId = 12,
                    Attempts = 0,
                    AssessmentId = 4,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 13,
                    QuestionTitle = "Vul het juiste woord in.",
                    Description = "Hij had zijn ... op.",
                    QuestionCategoryId = 4,
                    AnswerId = 13,
                    Attempts = 0,
                    AssessmentId = 4,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 14,
                    QuestionTitle = "Vul het juiste woord in.",
                    Description = "De schat lag verborgen in de ... .",
                    QuestionCategoryId = 4,
                    AnswerId = 14,
                    Attempts = 0,
                    AssessmentId = 4,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 15,
                    QuestionTitle = "Vul het juiste woord in.",
                    Description = "Hij stak de zee over op het ... .",
                    QuestionCategoryId = 4,
                    AnswerId = 15,
                    Attempts = 0,
                    AssessmentId = 4,
                }
                );

            //Questions: Klanken
            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 16,
                    QuestionTitle = "Geef de juiste vorm van het woord 'Zwak' weer in de volgende zin.",
                    Description = "Hij gaf een ... prestatie.",
                    QuestionCategoryId = 5,
                    AnswerId = 16,
                    Attempts = 0,
                    AssessmentId = 5,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 17,
                    QuestionTitle = "Geef de juiste vorm van het woord 'Tam' weer in de volgende zin.",
                    Description = "Hij had een heel ... kat.",
                    QuestionCategoryId = 5,
                    AnswerId = 17,
                    Attempts = 0,
                    AssessmentId = 5,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 18,
                    QuestionTitle = "Geef de juiste vorm van het woord 'Nat' weer in de volgende zin.",
                    Description = "De ... was hing aan de waslijn.",
                    QuestionCategoryId = 5,
                    AnswerId = 18,
                    Attempts = 0,
                    AssessmentId = 5,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 19,
                    QuestionTitle = "Geef de juiste vorm van het woord 'Zuur' weer in de volgende zin.",
                    Description = "Dat was een erg ... citroen.",
                    QuestionCategoryId = 5,
                    AnswerId = 19,
                    Attempts = 0,
                    AssessmentId = 5,
                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 20,
                    QuestionTitle = "Geef de juiste vorm van het woord 'Noot' weer in de volgende zin.",
                    Description = "De kastanje... hingen nog aan de boom.",
                    QuestionCategoryId = 5,
                    AnswerId = 20,
                    Attempts = 0,
                    AssessmentId = 5,

                }
                );

            modelBuilder.Entity<Question>()
                .HasData(
                new
                {
                    Id = 21,
                    QuestionTitle = "3 x 7 = ",
                    StartNumber = 7,
                    QuestionCategoryId = 3,
                    AnswerId = 21,
                    Attempts = 0,
                    AssessmentId = 3,
                }
                );

            
            #endregion
            #region AssessmentDetails
            modelBuilder.Entity<AssessmentDetail>()
                .HasData(
                new
                {
                    Id = 1,
                    AssessmentTitle = "Test Detail",
                    AssessmentId = 2
                }
                );
            #endregion
            #region Answers
            //Answers: Splitsoefeningen
            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 1,
                    MathAnswer = 2,
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 2,
                    MathAnswer = 2,
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 3,
                    MathAnswer = 3,
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 4,
                    MathAnswer = 5,
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 5,
                    MathAnswer = 6,
                }
                );

            //Answers: Fotoselectie
            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 6,
                    LangAnswer = "Kip"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 7,
                    LangAnswer = "Bos"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 8,
                    LangAnswer = "Pet"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 9,
                    LangAnswer = "Grot"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 10,
                    LangAnswer = "Vlot"
                }
                );

            //Answers: Begrijpend Lezen
            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 11,
                    LangAnswer = "Kip"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 12,
                    LangAnswer = "Bos"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 13,
                    LangAnswer = "Pet"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 14,
                    LangAnswer = "Grot"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 15,
                    LangAnswer = "Vlot"
                }
                );

            //Answers: Klanken
            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 16,
                    LangAnswer = "Zwakke"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 17,
                    LangAnswer = "Tamme"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 18,
                    LangAnswer = "Natte"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 19,
                    LangAnswer = "Zure"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 20,
                    LangAnswer = "Noten"
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 21,
                    MathAnswer = 21
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 22,
                    MathAnswer = 9
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 23,
                    MathAnswer = 15
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 24,
                    MathAnswer = 27
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 25,
                    MathAnswer = 30
                }
                );

            modelBuilder.Entity<Answer>()
                .HasData(
                new
                {
                    Id = 26,
                    MathAnswer = 1
                }
                );
            #endregion
            #region Assessments
            //Assessment: Splitsoefeningen
            modelBuilder.Entity<Assessment>()
                .HasData(
                new
                {
                    Id = 1,
                    AssessmentTitle = "Splitsingen",
                    CourseCategoryId = 1,
                    YearGradeId = 1
                });

            //Assessment: Fotoherkenning
            modelBuilder.Entity<Assessment>()
                .HasData(
                new
                {
                    Id = 2,
                    AssessmentTitle = "Herken de Foto's",
                    CourseCategoryId = 2,
                    YearGradeId = 1
                });

            //Assessment: Tafels
            modelBuilder.Entity<Assessment>()
                .HasData(
                new
                {
                    Id = 3,
                    AssessmentTitle = "Tafels",
                    CourseCategoryId = 1,
                    YearGradeId = 2
                });

            //Assessment: Begrijpend Lezen
            modelBuilder.Entity<Assessment>()
                .HasData(
                new
                {
                    Id = 4,
                    AssessmentTitle = "Begrijpend Lezen",
                    CourseCategoryId = 2,
                    YearGradeId = 2
                });


            //Assessment: Klanken
            modelBuilder.Entity<Assessment>()
                .HasData(
                new
                {
                    Id = 5,
                    AssessmentTitle = "Klanken",
                    CourseCategoryId = 2,
                    YearGradeId = 3
                });

           
            #endregion
            #region Feedback
            //Feedback: Fotoselectie
            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 6,
                    Reference = 1,
                    Description = "Kap",
                    QuestionId = 6
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 7,
                    Reference = 2,
                    Description = "Kop",
                    QuestionId = 6
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 8,
                    Reference = 1,
                    Description = "Mos",
                    QuestionId = 7
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 9,
                    Reference = 2,
                    Description = "Mes",
                    QuestionId = 7
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 10,
                    Reference = 1,
                    Description = "Pad",
                    QuestionId = 8
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 11,
                    Reference = 2,
                    Description = "Pot",
                    QuestionId = 8
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 12,
                    Reference = 1,
                    Description = "Grap",
                    QuestionId = 9
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 13,
                    Reference = 2,
                    Description = "Gek",
                    QuestionId = 9
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 14,
                    Reference = 1,
                    Description = "Vlek",
                    QuestionId = 10
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 15,
                    Reference = 2,
                    Description = "Fles",
                    QuestionId = 10
                }
                );

            //Feedback: Begrijpend Lezen
            //SAME AS Fotoselectie
            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 16,
                    Reference = 1,
                    Description = "Kap",
                    QuestionId = 11
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 17,
                    Reference = 2,
                    Description = "Kop",
                    QuestionId = 11
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 18,
                    Reference = 1,
                    Description = "Mos",
                    QuestionId = 12
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 19,
                    Reference = 2,
                    Description = "Mes",
                    QuestionId = 12
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 20,
                    Reference = 1,
                    Description = "Pad",
                    QuestionId = 13
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 21,
                    Reference = 2,
                    Description = "Pot",
                    QuestionId = 13
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 22,
                    Reference = 1,
                    Description = "Grap",
                    QuestionId = 14
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 23,
                    Reference = 2,
                    Description = "Gek",
                    QuestionId = 14
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 24,
                    Reference = 1,
                    Description = "Vlek",
                    QuestionId = 15
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 25,
                    Reference = 2,
                    Description = "Fles",
                    QuestionId = 15
                }
                );

            //Feedback: Klanken
            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 26,
                    Reference = 1,
                    Description = "Probeer de zin luidop te zeggen.",
                    QuestionId = 16
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 27,
                    Reference = 2,
                    Description = "Denk na is het een lange of korte klinker?",
                    QuestionId = 16
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 28,
                    Reference = 1,
                    Description = "Probeer de zin luidop te zeggen.",
                    QuestionId = 17
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 29,
                    Reference = 2,
                    Description = "Denk na is het een lange of korte klinker?",
                    QuestionId = 17
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 30,
                    Reference = 1,
                    Description = "Probeer de zin luidop te zeggen.",
                    QuestionId = 18
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 31,
                    Reference = 2,
                    Description = "Denk na is het een lange of korte klinker?",
                    QuestionId = 18
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 32,
                    Reference = 1,
                    Description = "Probeer de zin luidop te zeggen.",
                    QuestionId = 19
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 33,
                    Reference = 2,
                    Description = "Denk na is het een lange of korte klinker?",
                    QuestionId = 19
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 34,
                    Reference = 1,
                    Description = "Probeer de zin luidop te zeggen.",
                    QuestionId = 20
                }
                );

            modelBuilder.Entity<Feedback>()
                .HasData(
                new
                {
                    Id = 35,
                    Reference = 2,
                    Description = "Denk na is het een lange of korte klinker?",
                    QuestionId = 20
                }
                );
            #endregion
            #region QuestionCategory
            //Question Categories
            modelBuilder.Entity<QuestionCategory>()
                .HasData(
                new QuestionCategory
                {
                    Id = 1,
                    CategoryQuestion = QuestionCategories.MathQuestionFirstGrade //"Splitsen"
                }
                );

            modelBuilder.Entity<QuestionCategory>()
                .HasData(
                new QuestionCategory
                {
                    Id = 2,
                    CategoryQuestion = QuestionCategories.LangQuestionFirstGrade //"Fotoselectie"
                }
                );
            modelBuilder.Entity<QuestionCategory>()
                .HasData(
                new QuestionCategory
                {
                    Id = 3,
                    CategoryQuestion = QuestionCategories.MathQuestionSecondGrade //"Tafels"
                }
                );

            modelBuilder.Entity<QuestionCategory>()
                .HasData(
                new QuestionCategory
                {
                    Id = 4,
                    CategoryQuestion = QuestionCategories.LangQuestionSecondGrade //"Begrijpend Lezen"
                }
                );

            modelBuilder.Entity<QuestionCategory>()
                .HasData(
                new QuestionCategory
                {
                    Id = 5,
                    CategoryQuestion = QuestionCategories.LangQuestionThirdGrade //"Klanken"
                }
                );
            #endregion
            #region CourseCategory
            //Course Categories
            modelBuilder.Entity<CourseCategory>()
                .HasData(
                new CourseCategory
                {
                    Id = 1,
                    Category = "Math"
                }
                );

            modelBuilder.Entity<CourseCategory>()
                .HasData(
                new CourseCategory
                {
                    Id = 2,
                    Category = "Language"
                }
                );
            #endregion
            #region SchoolUserCategory
            modelBuilder.Entity<SchoolUserCategory>()
                .HasData(
                new SchoolUserCategory
                {
                    Id = 1,
                    Category = "Admin"
                }
                );

            modelBuilder.Entity<SchoolUserCategory>()
                .HasData(
                new SchoolUserCategory
                {
                    Id = 2,
                    Category = "Teacher"
                }
                );

            modelBuilder.Entity<SchoolUserCategory>()
                .HasData(
                new SchoolUserCategory
                {
                    Id = 3,
                    Category = "Student"
                }
                );
            #endregion
            #region ClassGroup
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "1A",
                    Id = 1,
                    YearGradeId = 1
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "1B",
                    Id = 2,
                    YearGradeId = 1
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "2A",
                    Id = 3,
                    YearGradeId = 1
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "2B",
                    Id = 4,
                    YearGradeId = 1
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "3A",
                    Id = 5,
                    YearGradeId = 2
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "3B",
                    Id = 6,
                    YearGradeId = 2
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "4A",
                    Id = 7,
                    YearGradeId = 2
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "4B",
                    Id = 8,
                    YearGradeId = 2
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "5A",
                    Id = 9,
                    YearGradeId = 3
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "5B",
                    Id = 10,
                    YearGradeId = 3
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "6A",
                    Id = 11,
                    YearGradeId = 3
                });
            modelBuilder.Entity<ClassGroup>()
                .HasData(
                new
                {
                    ClassGroupName = "6B",
                    Id = 12,
                    YearGradeId = 3
                });
            #endregion
            #region YearGrade
            //Yeargrades
            modelBuilder.Entity<YearGrade>()
                .HasData(
                new YearGrade
                {
                    Id = 1,
                    Grade = 1
                });

            modelBuilder.Entity<YearGrade>()
                .HasData(
                new YearGrade
                {
                    Id = 2,
                    Grade = 2
                });

            modelBuilder.Entity<YearGrade>()
                .HasData(
                new YearGrade
                {
                    Id = 3,
                    Grade = 3
                });
            #endregion
            #region SchoolUsers
            modelBuilder.Entity<SchoolUser>()
                .HasData(
                new
                {
                    FirstName = "first",
                    LastName = "testSchoolUser",
                    ClassGroupId = 1,
                    Password = "test",
                    Id = Guid.Parse(Guid.NewGuid().ToString()),
                    SchoolUserCategoryId = 1,
                    IdentityReference = "00000000-0000-0000-0000-000000000001"
                });
            #endregion


            modelBuilder.Entity<Question>()
            .HasOne(q => q.Answer);

            modelBuilder.Entity<Question>()
            .HasOne(q => q.QuestionCategory);

            modelBuilder.Entity<Question>()
            .HasMany(q => q.Feedback)
            .WithOne(f => f.Question);
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<SchoolUser> SchoolUsers { get; set; }
        public DbSet<YearGrade> YearGrades { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<WrongAnswer> WrongAnswer { get; set; }
        public DbSet<AssessmentDetail> AssessmentDetails { get; set; }
    }
}
