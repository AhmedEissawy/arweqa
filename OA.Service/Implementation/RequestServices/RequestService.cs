using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Helpers;
using OA.Repo.Interfaces;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.RequestServices
{
    public class RequestService : IRequestService
    {
        private readonly IFileHandler _FileHandler;
        private readonly IAnswerRepo _AnswerRepo;
        private readonly IAnswerAttachmentRepo _AnswerAttachmentRepo;
        private readonly IRequestAttachmentRepo _RequestAttachmentRepo;
        private readonly IMapper _Mapper;
        private readonly IRequestRepo _RequestRepo;
        private readonly IStudentRepo _StudentRepo;
        private readonly IUserRepo _UserRepo;
        private readonly ITeacherRepo _TeacherRepo;
        private readonly IExtraRequestRepo _ExtraRequestRepo;
        public RequestService(IMapper mapper, IRequestRepo requestRepo, IUserRepo userRepo, IStudentRepo studentRepo, ITeacherRepo teacherRepo, IExtraRequestRepo extraRequestRepo, IAnswerRepo answerRepo, IAnswerAttachmentRepo answerAttachmentRepo, IRequestAttachmentRepo requestAttachmentRepo, IFileHandler fileHandler)
        {
            _Mapper = mapper;
            _RequestRepo = requestRepo;
            _UserRepo = userRepo;
            _StudentRepo = studentRepo;
            _TeacherRepo = teacherRepo;
            _ExtraRequestRepo = extraRequestRepo;
            _AnswerRepo = answerRepo;
            _AnswerAttachmentRepo = answerAttachmentRepo;
            _RequestAttachmentRepo = requestAttachmentRepo;
            _FileHandler = fileHandler;

        }

        
        public async Task<RequestResponseDto> GetRequestById(Guid requestId)
        {
            Request request = await _RequestRepo.GetRequestById(requestId);

            return _Mapper.Map<RequestResponseDto>(request);
        }




        public async Task<MobileTeacherRequestResponseDto> GetTeacherRequestById(Guid requestId)
        {
            List<RequestAttachment> request = await _RequestRepo.GetTeacherRequestById(requestId);

            MobileTeacherRequestResponseDto teacherRrequest = new MobileTeacherRequestResponseDto();

            if (request.Count == 0) throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايوجد مرفقات لهاذ الطلب" });

            teacherRrequest.Images = request.Select(q => q.File).ToList();
            teacherRrequest.StageName = request.FirstOrDefault().Request.Subject.Grade.Stage.StageName;
            teacherRrequest.GradeName = request.FirstOrDefault().Request.Subject.Grade.GradeName;
            teacherRrequest.RequestNo = request.FirstOrDefault().Request.RequestNo;
            teacherRrequest.Description = request.FirstOrDefault().Request.Description;

            return teacherRrequest;

        }





        public async Task<List<MobileRequestResponseDto>> GetStudentRequests()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Student student = (await _StudentRepo.FindAsync(q => q.Id == Guid.Parse(userId))).FirstOrDefault();

            List<Request> requests = await _RequestRepo.GetStudentRequests(student.Id);

            return _Mapper.Map<List<MobileRequestResponseDto>>(requests);
        }


        public async Task<List<MobileRequestResponseDto>> GetTeacherRequests()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Teacher student = (await _TeacherRepo.FindAsync(q => q.Id == Guid.Parse(userId))).FirstOrDefault();

            List<Request> requests = await _RequestRepo.GetTeacherRequests(student.Id);

            return _Mapper.Map<List<MobileRequestResponseDto>>(requests);
        }



        public async Task<(RequestResponseDto, Guid)> AddRequest(CreateRequestDto request)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser studentIdentity = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            Student student = (await _StudentRepo.FindAsync(q => q.Id == Guid.Parse(userId))).FirstOrDefault();

            // for uploading purpose only after that we will uncomment it ###
            if (studentIdentity.IsActive == false) throw new RestException(HttpStatusCode.BadRequest, new { message = $"برجاء إبلاغ الدعم الفني لتفعيل حسابك" });


            List<Request> recentRequests = await _RequestRepo.CheckRequestAvailability(student.Id, request.SubjectId);

            if (!student.PremiumSubscription)
            {

                if (recentRequests.Count != 0)
                {
                    Request recentRequest = recentRequests.OrderByDescending(q => q.Date).FirstOrDefault();

                    TimeSpan timeDifference = Helper.kuwaitTimeNow().Date.Subtract(recentRequest.Date.Date);

                    // for uploading purpose only after that we will uncomment it ###
                    if (timeDifference.TotalDays == 0)
                    {
                        ExtraRequest studentExtraRequest = await _ExtraRequestRepo.GetStudentExtraRequest(student.Id, request.SubjectId);

                        if (studentExtraRequest != null && studentExtraRequest.RequestCount != 0)
                        {
                            studentExtraRequest.RequestCount -= 1;
                        }
                        else
                        {
                            throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفوا لقد تجاوزت حد إرسال طلبات في نفس الماده لهذا اليوم برجاء التواصل مع الدعم الفني  لزيادة عدد الطلبات أو الإنظار لليوم التالي" });
                        }
                    }
                }
            }


            Request newRequest = _Mapper.Map<Request>(request);

            TeacherSubject teacher = await _RequestRepo.GetTeacherInRole(request.SubjectId);

            newRequest.Id = Guid.NewGuid();
            newRequest.RequestNo = await _RequestRepo.GenerateRquesrtNumber();
            newRequest.Date = Helper.kuwaitTimeNow();
            newRequest.Replied = false;
            newRequest.TeacherId = teacher.TeacherId;
            newRequest.StudentId = student.Id;

            await _RequestRepo.AddAsync(newRequest);


            var Response = _Mapper.Map<RequestResponseDto>(newRequest);

            Response.SubjectName = teacher.Subject.SubjectName;

            return (Response, teacher.Teacher.Id);


        }


        public async Task<(Guid studentId, Guid teacherId, int RequestNo, string SubjectName)> DeleteRequest(Guid requestId)
        {
            Request request = await _RequestRepo.GetRequestById(requestId);

            if (request == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The request with id = {requestId}  not found ...!" });

            if (request.Replied) throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايمكن حذف طلب تمت الإجابه عليه" });

            request.Deleted = true;

            int result = await _RequestRepo.SaveChangesAsync();
                     
            if (result == 0)
            {
                throw new Exception("Error saving The data ...!");
            }
           
            return (request.StudentId , request.TeacherId , request.RequestNo , request.Subject.SubjectName);

        }




        public async Task RequestRedirect(RequestRedirectDto requestRedirect)
        {
            Request request = await _RequestRepo.GetRequestById(requestRedirect.RequestId);

            if ((request == null) || (request.Deleted)) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The request with id = {requestRedirect.RequestId}  not found ...!" });

            if (request.Replied) throw new RestException(HttpStatusCode.BadRequest, new { message = $"عفواا لايمكن تحويل طلب تمت الإجابه عليه" });

            request.TeacherId = requestRedirect.NewTeacherId;

            int result = await _RequestRepo.SaveChangesAsync();

            if (result == 0)
            {
                throw new Exception("Error saving The data ...!");
            }
        }



        public async Task DeleteFullRequest(Guid requestId)
        {
            Request request = (await _RequestRepo.FindAsync(q => q.Id == requestId)).FirstOrDefault();

            if ((request == null) || (request.Deleted)) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The request with id = {requestId}  not found ...!" });

            bool replied = request.Replied;

            List<RequestAttachment> requestAttachment = (await _RequestAttachmentRepo.FindAsync(q => q.RequestId == requestId)).ToList();

            if (requestAttachment.Count != 0)
            {
                foreach (var image in requestAttachment)
                {
                    if (!(string.IsNullOrEmpty(image.File)) || !(string.IsNullOrWhiteSpace(image.File)))
                    {
                        bool deleted = _FileHandler.DeleteFile(image.File, "Requests");
                    }
                }
            }


            if (replied)
            {
                Answer answer = (await _AnswerRepo.FindAsync(q => q.RequestId == requestId)).FirstOrDefault();

                if (answer == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Answer with request id = {requestId}  not found ...!" });

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

            }

            _RequestAttachmentRepo.RemoveRange(requestAttachment);

            _RequestRepo.Remove(request);


            int result = await _RequestRepo.SaveChangesAsync();

            if (result == 0)
            {
                throw new Exception($" Error Deleting  Request ...!");
            }

        }


    }
}