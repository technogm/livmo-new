using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public PhotoService(IOptions<CloudinarySettings> config , ApplicationDbContext db , IUserService userService )
        {
            _context = db;
            _userService = userService;
            var acc = new Account
            (
                config.Value.CloudName = "technogm",
                config.Value.ApiKey = "393748742879698",
                config.Value.ApiSecret = "JcKOotdyygwXbZfHEqjXDphXNqQ"
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddIDFilesAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Hosts ID Files",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
        public async Task<ImageUploadResult> AddCADTouristFilesAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Hosts CAD Tourist Files",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
        public async Task<ImageUploadResult> AddLicenceFilesAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Hosts Licence Files",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
        public async Task<ImageUploadResult> AddRNEFilesAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "ClientsRNEFiles",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                 //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Users Profiles Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        public async Task<ImageUploadResult> InsertExperiencePhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Experience Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> InsertActivityPhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Activity Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> InsertFoodPhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Food Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public  async Task<ImageUploadResult> InsertLodgingPhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Lodgign Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> InsertTransportPhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Transport Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> InsertRestaurantshotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Restaurants Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        // USER !!
        public async Task<Photo> InsertPhoto(Photo entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.Photos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Photo> DeletePic(Guid id)
        {
            var exp = await _context.Photos.FindAsync(id);
            if (exp != null)
            {
                _context.Photos.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }
        public async Task<Photo> FindPicById(Guid id)
        {
            var exp = await _context.Photos
                .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosExperience> InsertExperiencePhoto(PhotosExperience entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosExperiences.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosExperience> DeleteExperiencePic(Guid id)
        {
            var exp = await _context.photosExperiences.FindAsync(id);
            if (exp != null)
            {
                _context.photosExperiences.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosExperience> FindExperiencePicById(Guid id)
        {
            var exp = await _context.photosExperiences
                          .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosActivity> InsertActivityPhoto(PhotosActivity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.PhotosActivities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosActivity> DeleteActivityPic(Guid id)
        {
            var exp = await _context.PhotosActivities.FindAsync(id);
            if (exp != null)
            {
                _context.PhotosActivities.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosActivity> FindActivityPicById(Guid id)
        {
            var exp = await _context.PhotosActivities
                                      .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosLodgingsExp> InsertLodgingExpPhoto(PhotosLodgingsExp entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosLodgingsExps.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosLodgingsExp> DeleteLodgingExpPic(Guid id)
        {
            var exp = await _context.photosLodgingsExps.FindAsync(id);
            if (exp != null)
            {
                _context.photosLodgingsExps.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosLodgingsExp> FindLodgingExpPicById(Guid id)
        {
            var exp = await _context.photosLodgingsExps
                                                 .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosFoodExp> InsertFoodExpPicPhoto(PhotosFoodExp entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosFoodExps.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosFoodExp> DeleteFoodExpPicPic(Guid id)
        {
            var exp = await _context.photosFoodExps.FindAsync(id);
            if (exp != null)
            {
                _context.photosFoodExps.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosFoodExp> FindFoodExpPicById(Guid id)
        {
            var exp = await _context.photosFoodExps
                                                            .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosTransportsExp> InsertTransportExpPhoto(PhotosTransportsExp entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosTransportsExps.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosTransportsExp> DeleteTransportExpPic(Guid id)
        {
            var exp = await _context.photosTransportsExps.FindAsync(id);
            if (exp != null)
            {
                _context.photosTransportsExps.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosTransportsExp> FindTransportExpPicById(Guid id)
        {
            var exp = await _context.photosTransportsExps
                                                          .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosLodgings> InsertLodgingPhoto(PhotosLodgings entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosLodgings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosLodgings> DeleteLodgingPic(Guid id)
        {
            var exp = await _context.photosLodgings.FindAsync(id);
            if (exp != null)
            {
                _context.photosLodgings.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosLodgings> FindLodgingPicById(Guid id)
        {
            var exp = await _context.photosLodgings
                                                                     .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosTransports> InsertTransportPhoto(PhotosTransports entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosTransports.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosTransports> DeleteTransportPic(Guid id)
        {
            var exp = await _context.photosTransports.FindAsync(id);
            if (exp != null)
            {
                _context.photosTransports.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosTransports> FindTransportPicById(Guid id)
        {
            var exp = await _context.photosTransports
                                                                               .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosFood> InsertFoodPhoto(PhotosFood entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosFoods.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosFood> DeleteFoodPic(Guid id)
        {
            var exp = await _context.photosFoods.FindAsync(id);
            if (exp != null)
            {
                _context.photosFoods.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosFood> FindFoodPicById(Guid id)
        {
            var exp = await _context.photosFoods
                                                                                          .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<PhotosRestaurants> InsertRestaurantPhoto(PhotosRestaurants entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.photosRestaurants.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PhotosRestaurants> DeleteRestaurantPic(Guid id)
        {
            var exp = await _context.photosRestaurants.FindAsync(id);
            if (exp != null)
            {
                _context.photosRestaurants.Remove(exp);
                await _context.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<PhotosRestaurants> FindRestaurantPicById(Guid id)
        {
            var exp = await _context.photosRestaurants
                                                                                                    .FirstOrDefaultAsync(n => n.Id == id);

            return exp;
        }

        public async Task<ImageUploadResult> InsertTransportExperiencePhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Transport Experience Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public  async Task<ImageUploadResult> InsertFoodExperiencePhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Food Experience Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<ImageUploadResult> InsertLodgingExperiencePhotos(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //   Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Lodging Experience Pictures",
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
    }
}
