using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.LessonQuestionServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.LessonQuestionServices
{
    public class LessonQuestionService : ILessonQuestionService
    {
        private readonly ILessonQuestionAnswerRepo _lessonQuestionAnswerRepo;
        private readonly ILessonQuestionRepo _lessonQuestionRepo;
        private readonly IFileHandler _FileHandler;
        public LessonQuestionService(ILessonQuestionRepo lessonQuestionRepo, IFileHandler fileHandler, ILessonQuestionAnswerRepo lessonQuestionAnswerRepo)
        {
            _lessonQuestionRepo = lessonQuestionRepo;
            _lessonQuestionAnswerRepo = lessonQuestionAnswerRepo;
            _FileHandler = fileHandler;
        }



        public async Task<List<LessonQuestionDto>> LessonQuestions(Guid lessonId)
        {
            List<LessonQuestion> dbQuestions = await _lessonQuestionRepo.LessonQuestions(lessonId);

            if (dbQuestions == null || dbQuestions.Count == 0) throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايوجد أسئله لهذا الدرس" });

            List<LessonQuestionDto> questions = dbQuestions.Select(q => new LessonQuestionDto()
            {
                LessonQuestionId = q.Id,
                LessonId = q.LessonId,
                ContentType = q.ContentType,
                Question = q.Question,
                Index = q.Index,
                Answers = q.LessonQuestionAnswers.Where(q => !q.Deleted).Select(q => new lessonQuestionAnswerDto()
                {
                    lessonQuestionAnswerId = q.Id,
                    ContentType = q.ContentType,
                    Answer = q.Answer,
                    IsRight = q.IsRight,
                    Index = q.Index,
                }).OrderBy(q => q.Index).ToList()

            }).OrderBy(q => q.Index).ToList();

            return questions;
        }



        public async Task<Guid> AddLessonQuestion(AddLessonQuestionDto lessonQuestion)
        {
            LessonQuestion newLessonQuestion = new LessonQuestion()
            {
                Id = Guid.NewGuid(),
                LessonId = lessonQuestion.LessonId,
                ContentType = (lessonQuestion.Question == null && lessonQuestion.QuestionFile != null) ? FileType.Image.ToString() : FileType.Text.ToString(),
                Question = (lessonQuestion.Question == null && lessonQuestion.QuestionFile != null) ? await _FileHandler.SaveImageConverter(lessonQuestion.QuestionFile, FolderName.LessonQuestions.ToString()) : lessonQuestion.Question,
                Index = lessonQuestion.Index,

            };

            await _lessonQuestionRepo.AddAsync(newLessonQuestion);

            int result = await _lessonQuestionRepo.SaveChangesAsync();


            if (result < 1) throw new RestException(HttpStatusCode.BadRequest, new { message = $"لم تتم إضافة السؤال" });


            return newLessonQuestion.Id;

        }



        public async Task EditLessonQuestion(EditLessonQuestionDto lessonQuestion)
        {
            LessonQuestion oldQessonQuestion = (await _lessonQuestionRepo.FindAsync(q => q.Id == lessonQuestion.LessonQuestionId)).FirstOrDefault();

            if (oldQessonQuestion == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $"السؤال غير موجود" });

            oldQessonQuestion.Index = lessonQuestion.Index;
            oldQessonQuestion.LessonId = lessonQuestion.LessonId;

            if (lessonQuestion.Question == null && lessonQuestion.QuestionFile != null)
            {
                if (oldQessonQuestion.ContentType == FileType.Image.ToString())
                {
                    _FileHandler.DeleteFile(oldQessonQuestion.Question, FolderName.LessonQuestions.ToString());
                }

                oldQessonQuestion.Question = await _FileHandler.SaveImageConverter(lessonQuestion.QuestionFile, FolderName.LessonQuestions.ToString());
            }

            else
            {      
                oldQessonQuestion.Question = lessonQuestion.Question;
            }

            int result = await _lessonQuestionRepo.SaveChangesAsync();

            if (result < 1) throw new RestException(HttpStatusCode.BadRequest, new { message = $"لم يتم تعديل السؤال" });

        }



        public async Task DeleteLessonQuestion(Guid questionId)
        {
            LessonQuestion lessonQuestion = await _lessonQuestionRepo.LessonQuestionWithAnswers(questionId);

            if (lessonQuestion != null)
            {
                lessonQuestion.Deleted = true;
                if (lessonQuestion.ContentType == FileType.Image.ToString())
                {
                    _FileHandler.DeleteFile(lessonQuestion.Question, FolderName.LessonQuestions.ToString());
                }

                if (lessonQuestion.LessonQuestionAnswers != null && lessonQuestion.LessonQuestionAnswers.Count() != 0)
                {
                    foreach (LessonQuestionAnswer answer in lessonQuestion.LessonQuestionAnswers)
                    {
                        answer.Deleted = true;
                        if (answer.ContentType == FileType.Image.ToString())
                        {
                            _FileHandler.DeleteFile(answer.Answer, FolderName.LessonQuestionAnswers.ToString());
                        }
                    }
                }
            }
            else
            {

            }

        }

        public async Task<Guid> AddLessonQuestionAnswer(AddLessonQuestionAnswerDto lessonQuestionAnswer)
        {
            List<LessonQuestionAnswer> lessonQuestionAnswers = (await _lessonQuestionAnswerRepo.FindAsync(q => !q.Deleted && q.LessonQuestionId == lessonQuestionAnswer.lessonQuestionId)).ToList();

            if (lessonQuestionAnswers.Count() >= 4)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $"لا يمكن إضافة أكثر من 4 إجابات لكل سؤال" });
            }

            LessonQuestionAnswer rightAnswer = lessonQuestionAnswers.FirstOrDefault(q => q.IsRight);
            if (lessonQuestionAnswers.Count() == 3 && !lessonQuestionAnswer.IsRight && rightAnswer == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $"يجب أن يكون هناك إجابة واحده صحيحه على الأقل من بين ال 4 أسئله" });
            }

            if (rightAnswer != null && lessonQuestionAnswer.IsRight)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $"لايمكن أن يكون هناك إجابتان صحيحتان" });
            }

            LessonQuestionAnswer newLessonQuestionAnswer = new LessonQuestionAnswer()
            {
                Id = Guid.NewGuid(),
                LessonQuestionId = lessonQuestionAnswer.lessonQuestionId,
                ContentType = (lessonQuestionAnswer.Answer == null && lessonQuestionAnswer.AnswerFile != null) ? FileType.Image.ToString() : FileType.Text.ToString(),
                Answer = (lessonQuestionAnswer.Answer == null && lessonQuestionAnswer.AnswerFile != null) ? await _FileHandler.SaveImageConverter(lessonQuestionAnswer.AnswerFile, FolderName.LessonQuestionAnswers.ToString()) : lessonQuestionAnswer.Answer,
                IsRight = lessonQuestionAnswer.IsRight,
                Index = lessonQuestionAnswer.Index,

            };

            await _lessonQuestionAnswerRepo.AddAsync(newLessonQuestionAnswer);

            int result = await _lessonQuestionAnswerRepo.SaveChangesAsync();

            if (result < 1) throw new RestException(HttpStatusCode.BadRequest, new { message = $"لم تتم إضافة الجواب" });

            return newLessonQuestionAnswer.Id;
        }



        public async Task DeleteLessonQuestionAnswer(Guid answerId)
        {
            LessonQuestionAnswer lessonQuestionAnswer = (await _lessonQuestionAnswerRepo.FindAsync(q => q.Id == answerId)).FirstOrDefault();

            if (lessonQuestionAnswer == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $"الجواب غير موجود" });

            lessonQuestionAnswer.Deleted = true;

            if (lessonQuestionAnswer.ContentType == FileType.Image.ToString())
            {
                _FileHandler.DeleteFile(lessonQuestionAnswer.Answer, FolderName.LessonQuestionAnswers.ToString());
            }
           
            int result = await _lessonQuestionAnswerRepo.SaveChangesAsync();

            if (result < 1) throw new RestException(HttpStatusCode.BadRequest, new { message = $"لم يتم حذف الإجابه" });
        }


    }
}
