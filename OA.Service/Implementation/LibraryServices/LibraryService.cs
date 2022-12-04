using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.LibraryServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.LibraryServices
{
    public class LibraryService : ILibraryService
    {
        private readonly IMapper _mapper;
        private readonly IFileHandler _fileHandler;
        private readonly IUserAccessor _userAccessor;
        private readonly ILibraryRepository _libraryRepository;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ILibraryTypeRepository _libraryTypeRepository;
        public LibraryService(ILibraryRepository libraryRepository, IMapper mapper, IFileHandler fileHandler, UserManager<ApplicationUser> userManager, IUserAccessor userAccessor, ILibraryTypeRepository libraryTypeRepository)
        {
            _mapper = mapper;
            _usermanager = userManager;
            _fileHandler = fileHandler;
            _userAccessor = userAccessor;
            _libraryRepository = libraryRepository;
            _libraryTypeRepository = libraryTypeRepository;
        }


        public async Task<List<string>> GetLibraryTypes()
        {
            List<LibraryType> libraryTypes = await _libraryTypeRepository.GetLibraryTypes();

            return libraryTypes.Select(q => q.Category).ToList();
        }


        public async Task<List<LibraryResponseDto>> GetLibrariesForAdmin(Guid gradeId)
        {
            List<Library> libraries = await _libraryRepository.GetLibrariesForAdmin(gradeId);

            return _mapper.Map<List<LibraryResponseDto>>(libraries);
        }



        public async Task<List<MobileLibraryResponseDto>> GetLibraryFilesForStudent(string libraryCode)
        {
            string userId = _userAccessor.GetCurrentUserId();

            ApplicationUser student = await _usermanager.Users.Include(q => q.Student).FirstOrDefaultAsync(q => q.Id == Guid.Parse(userId));

            List<Library> libraries = await _libraryRepository.GetLibraryFilesForStudent(libraryCode, student.GradeId.Value, student.Student.PremiumSubscription);

            return _mapper.Map<List<MobileLibraryResponseDto>>(libraries);
        }



        public async Task AddLibrary(CreateLibraryDto library)
        {
            string fileImage = null;

            string file = null;

            string extension = library.File.FileName.ToLower().Split('.').Last();

            if (library.FileImage != null)
            {
                fileImage = await _fileHandler.SaveImageConverter(library.FileImage, FolderName.Libraries.ToString());
            }
            else
            {
                switch (extension.ToLower())
                {
                    case nameof(FileExtension.Docx):
                        fileImage = ImageAvatar.WordAvatar;
                        break;

                    case nameof(FileExtension.Xlsx):
                        fileImage = ImageAvatar.ExcelAvatar;
                        break;

                    case nameof(FileExtension.Pdf):
                        fileImage = ImageAvatar.PDFAvatar;
                        break;

                    case nameof(FileExtension.PowerPoint):
                        fileImage = ImageAvatar.PowerPointAvatar;
                        break;

                    case nameof(FileExtension.Txt):
                        fileImage = ImageAvatar.TextAvatar;
                        break;

                    default:
                        fileImage = ImageAvatar.PhotoAvatar;
                        break;

                }

            }

            if (library.File != null)
            {
                file = await _fileHandler.SaveFile(library.File, FolderName.Libraries.ToString());
            }


            Library newLibrary = new Library()
            {
                Id = Guid.NewGuid(),
                GradeId = library.GradeId,
                SemesterId = library.SemesterId,
                CategoryCode = library.CategoryCode,
                Name = library.Name,
                FileImage = fileImage,
                File = file,
                FileType = ((extension == "JPG".ToLower()) || (extension == "PNG".ToLower()) || (extension == "JPEG".ToLower()) || (extension == "MOV".ToLower()) || (extension == "HEIC".ToLower()) || (extension == "PLIST".ToLower())) ? FileType.Image.ToString() : FileType.Link.ToString(),
                IsPremium = library.IsPremium,
                Index = library.Index,
            };

            await _libraryRepository.AddAsync(newLibrary);

            await _libraryRepository.SaveChangesAsync();

        }



        public async Task DeleteLibrary(Guid libraryId)
        {
            Library library = (await _libraryRepository.FindAsync(q => q.Id == libraryId)).FirstOrDefault();

            if (library == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Library with id = {libraryId} not found ...!" });

            if (!(string.IsNullOrEmpty(library.FileImage)) || !(string.IsNullOrWhiteSpace(library.FileImage)))
            {
                bool pdfDeleted = _fileHandler.DeleteFile(library.FileImage, FolderName.Libraries.ToString());
            }

            if (!(string.IsNullOrEmpty(library.File)) || !(string.IsNullOrWhiteSpace(library.File)))
            {
                bool imageDeleted = _fileHandler.DeleteFile(library.File, FolderName.Libraries.ToString());
            }

            _libraryRepository.Remove(library);

            await _libraryRepository.SaveChangesAsync();

        }

    }
}
