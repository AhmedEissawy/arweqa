using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Helpers;
using OA.Repo.Interfaces;
using OA.Service.Implementation.AnswerServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.AnswerServices
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepo _AnswerRepo;
        private readonly IAnswerAttachmentRepo _AnswerAttachmentRepo;
        private readonly IUserRepo _UserRepo;
        private readonly IFileHandler _FileHandler;
        private readonly IStudentRepo _StudentRepo;
        private readonly IRequestRepo _RequestRepo;
        private readonly IMapper _Mapper;
        public AnswerService(IAnswerRepo answerRepo, IMapper mapper, IRequestRepo requestRepo, IUserRepo userRepo, IStudentRepo studentRepo, IAnswerAttachmentRepo answerAttachmentRepo, IFileHandler fileHandler)
        {
            _AnswerRepo = answerRepo;
            _RequestRepo = requestRepo;
            _Mapper = mapper;
            _UserRepo = userRepo;
            _StudentRepo = studentRepo;
            _AnswerAttachmentRepo = answerAttachmentRepo;
            _FileHandler = fileHandler;
        }



        public async Task<(AnswerResponseDto, Guid)> AddAnswerToRequest(CreateAnswerDto answer)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser user = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            // for uploading purpose only after that we will uncomment it ###
            if (user.IsActive == false) throw new RestException(HttpStatusCode.BadRequest, new { message = $"برجاء التواصل مع الدعم الفني لتفعيل حسابك" });

            Request request = await _RequestRepo.GetRequestById(answer.RequestId);

            if ((request == null) || (request.Deleted)) throw new RestException(HttpStatusCode.BadRequest, new { message = $"هذا الطلب غير موجود" });

            if (request.Replied == true) throw new RestException(HttpStatusCode.BadRequest, new { message = $"لقد تم الإجابه على هذا الطلب من قبل" });

            request.Replied = true;

            TimeSpan timeDifference = Helper.kuwaitTimeNow().Subtract(request.Date);

            if (timeDifference.TotalHours < 1)
            {
                request.RepliedInTime = true;
            }

            Answer newAnswer = _Mapper.Map<Answer>(answer);

            newAnswer.Id = Guid.NewGuid();
            newAnswer.Date = Helper.kuwaitTimeNow();
            newAnswer.StudentId = request.StudentId;
            newAnswer.TeacherId = request.TeacherId;
            newAnswer.SubjectId = request.SubjectId;

            await _AnswerRepo.AddAsync(newAnswer);

            Student student = (await _StudentRepo.FindAsync(q => q.Id == newAnswer.StudentId)).FirstOrDefault();

            int result = await _AnswerRepo.SaveChangesAsync();

            var Response = _Mapper.Map<AnswerResponseDto>(newAnswer);

            Response.SubjectName = request.Subject.SubjectName;

            return (Response, student.Id);

        }



        public async Task<(string, Guid)> DeleteAnswerFromRequest(Guid answerId)
        {
            Answer answer = await _AnswerRepo.GetTeacherAnswerById(answerId);

            // What Will Happen On Remove dbAnswer
            //Answer dbAnswer = (await _AnswerRepo.FindAsync(q => q.Id == answerId)).FirstOrDefault();!!!!!!!!!!!!????????????????????????????

            if (answer == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Answer with id = {answerId}  not found ...!" });

            Request request = (await _RequestRepo.FindAsync(q => q.Id == answer.RequestId)).FirstOrDefault();

            request.Replied = false;

            string subjectName = answer.Subject.SubjectName;
            Guid TeacherIdentityId = answer.Teacher.Id;

            List<AnswerAttachment> answerAttachment = (await _AnswerAttachmentRepo.FindAsync(q => q.AnswerId == answer.Id)).ToList();

            if (answerAttachment.Count != 0)
            {
                foreach (var image in answerAttachment)
                {
                    if (!(string.IsNullOrEmpty(image.File)) || !(string.IsNullOrWhiteSpace(image.File)))
                    {
                        bool deleted = _FileHandler.DeleteFile(image.File, "Answers");
                    }
                }
            }

            _AnswerAttachmentRepo.RemoveRange(answerAttachment);

            _AnswerRepo.Remove(answer);

            int result = await _AnswerRepo.SaveChangesAsync();

            if (result != 0)
            {
                return (subjectName, TeacherIdentityId);
            }

            throw new Exception("Error Deleting The Answer ...!");

        }




        public async Task<MobileFullAnswerResponseDto> GetAnswerWithRequestAttachmentByRequestId(Guid requestId)
        {
            Request dbRequest = await _RequestRepo.GetRequestAttachmentById(requestId);

            Answer dbAnswer = await _AnswerRepo.GetAnswerAttachmentByRequestId(requestId);

            MobileFullAnswerResponseDto fullAnswerRequest = new MobileFullAnswerResponseDto();
            fullAnswerRequest.Request = new RequestDto();
            fullAnswerRequest.Answer = new AnswerDto();
            fullAnswerRequest.Request.Attachments = new List<AttachmentDto>();
            fullAnswerRequest.Answer.Attachments = new List<AttachmentDto>();

            if (dbRequest != null)
            {
                fullAnswerRequest.Request.Discription = dbRequest.Description;

                if (dbRequest.RequestFiles != null && dbRequest.RequestFiles.Count() != 0)
                {
                    foreach (RequestAttachment attachment in dbRequest.RequestFiles)
                    {
                        AttachmentDto request = new AttachmentDto()
                        {
                            Content = attachment.File,
                            Type = attachment.Type
                        };
                        fullAnswerRequest.Request.Attachments.Add(request);

                    }
                }

            }

            if (dbAnswer != null)
            {
                fullAnswerRequest.Answer.Discription = dbAnswer.Description;

                if (dbAnswer.AnswerFiles != null && dbAnswer.AnswerFiles.Count() != 0)
                {
                    foreach (AnswerAttachment attachment in dbAnswer.AnswerFiles)
                    {
                        AttachmentDto answer = new AttachmentDto()
                        {
                            Content = attachment.File,
                            Type = attachment.Type
                        };
                        fullAnswerRequest.Answer.Attachments.Add(answer);
                    }
                }


            }

            return fullAnswerRequest;

        }



    }
}
