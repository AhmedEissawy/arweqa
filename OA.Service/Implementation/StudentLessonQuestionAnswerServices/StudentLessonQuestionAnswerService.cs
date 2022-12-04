using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices
{
    public class StudentLessonQuestionAnswerService : IStudentLessonQuestionAnswerService
    {
        private readonly IStudentLessonQuestionAnswerRepo _studentLessonQuestionAnswerRepo;
        private readonly ILessonQuestionAnswerRepo _LessonQuestionAnswerRepo;
        private readonly ILessonQuestionRepo _lessonQuestionRepo;
        private readonly IUserRepo _UserRepo;
        public StudentLessonQuestionAnswerService(IUserRepo userRepo, IStudentLessonQuestionAnswerRepo studentLessonQuestionAnswerRepo, ILessonQuestionAnswerRepo lessonQuestionAnswerRepo, ILessonQuestionRepo lessonQuestionRepo)
        {
            _studentLessonQuestionAnswerRepo = studentLessonQuestionAnswerRepo;
            _LessonQuestionAnswerRepo = lessonQuestionAnswerRepo;
            _lessonQuestionRepo = lessonQuestionRepo;
            _UserRepo = userRepo;
        }


        public async Task<List<StudentLessonQuestionDto>> GetStudentLessonQuestions(Guid lessonId)
        {
            List<LessonQuestion> newLessonQuestions = new List<LessonQuestion>();

            List<StudentLessonQuestionAnswer> studentLessonQuestionAnswers = new List<StudentLessonQuestionAnswer>();

            List<StudentLessonQuestionDto> studentLessonQuestions = new List<StudentLessonQuestionDto>();

            newLessonQuestions = await _lessonQuestionRepo.GetRandomLessonQuestionsFromLesson(lessonId);

            if (newLessonQuestions != null && newLessonQuestions.Count() != 0)
            {
                newLessonQuestions = newLessonQuestions.OrderBy(r => Guid.NewGuid()).ToList();
                string userId = _UserRepo.GetUserClaims().Id;

                foreach (LessonQuestion lessonQuestion in newLessonQuestions)
                {
                    StudentLessonQuestionAnswer newStudentLessonQuestionAnswer = new StudentLessonQuestionAnswer()
                    {
                        Id = Guid.NewGuid(),
                        StudentId = Guid.Parse(userId),
                        LessonQuestionId = lessonQuestion.Id,
                    };
                    studentLessonQuestionAnswers.Add(newStudentLessonQuestionAnswer);

                    StudentLessonQuestionDto studentLessonQuestion = new StudentLessonQuestionDto()
                    {
                        QuestionId = newStudentLessonQuestionAnswer.Id,
                        ContentType = lessonQuestion.ContentType,
                        Question = lessonQuestion.Question
                    };
                    studentLessonQuestions.Add(studentLessonQuestion);

                    studentLessonQuestion.Answers = lessonQuestion.LessonQuestionAnswers.Select(a => new QuestionAnswerDto()
                    {
                        AnswerId = a.Id,
                        ContentType = a.ContentType,
                        Answer = a.Answer

                    }).ToList();
                }
                await _studentLessonQuestionAnswerRepo.AddRangeAsync(studentLessonQuestionAnswers);

                int result = await _studentLessonQuestionAnswerRepo.SaveChangesAsync();
            }
            else
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايوجد أسئله لهاذ الدرس" });
            }

            return studentLessonQuestions;
        }



        public async Task<List<StudentAnswerResultDto>> AnswerLessonQuestions(List<StudentLessonQuestionAnswerDto> lessonQuestionAnswers)
        {
            List<StudentLessonQuestionAnswer> studentLessonQuestionAnswers = await _studentLessonQuestionAnswerRepo.CheckLessonQuestionAnswers(lessonQuestionAnswers.Select(q => q.LessonQuestionAnswerId).ToList());

            List<StudentAnswerResultDto> studentAnswersResult = new List<StudentAnswerResultDto>();

            if (studentLessonQuestionAnswers != null && studentLessonQuestionAnswers.Count() != 0)
            {
                foreach (StudentLessonQuestionAnswer studentLessonQuestionAnswer in studentLessonQuestionAnswers)
                {
                    StudentLessonQuestionAnswerDto lessonQuestionAnswer = lessonQuestionAnswers.FirstOrDefault(q => q.LessonQuestionAnswerId == studentLessonQuestionAnswer.Id);

                    studentLessonQuestionAnswer.LessonQuestionAnswerId = lessonQuestionAnswer.AnswerId;

                    LessonQuestionAnswer questionAnswer = (await _LessonQuestionAnswerRepo.FindAsync(q => q.Id == lessonQuestionAnswer.AnswerId)).FirstOrDefault();

                    studentLessonQuestionAnswer.IsRight = questionAnswer.IsRight;

                    StudentAnswerResultDto studentAnswerResult = new StudentAnswerResultDto()
                    {
                        LessonQuestion = studentLessonQuestionAnswer.LessonQuestion.Question,
                        ContentType = studentLessonQuestionAnswer.LessonQuestion.ContentType,
                        Result = studentLessonQuestionAnswer.IsRight,
                        Message = studentLessonQuestionAnswer.IsRight ? "الإجابه صحيحه" : "الإجابه خاطئه",
                    };

                    studentAnswerResult.Answers = studentLessonQuestionAnswer.LessonQuestion.LessonQuestionAnswers.Select(q => new QuestionAnswersDto() 
                    {
                        ContentType = q.ContentType,
                        Answer = q.Answer,
                        IsRight = q.IsRight
                    }).ToList();

                    studentAnswersResult.Add(studentAnswerResult);
                }

                int result = await _studentLessonQuestionAnswerRepo.SaveChangesAsync();

            }

            else
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايوجد إجابه لهاذ السؤال" });
            }

            return studentAnswersResult;
        }


    }
}
