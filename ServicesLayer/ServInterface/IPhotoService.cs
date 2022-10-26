using CloudinaryDotNet.Actions;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile photo);
        public Task<ImageUploadResult> AddIDFilesAsync(IFormFile photo);
        public Task<ImageUploadResult> AddCADTouristFilesAsync(IFormFile photo);
        public Task<ImageUploadResult> AddLicenceFilesAsync(IFormFile photo);
        public Task<ImageUploadResult> AddRNEFilesAsync(IFormFile photo);
        public Task<DeletionResult>DeletePhotoAsync(string publicId);
        public Task<ImageUploadResult> InsertExperiencePhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertActivityPhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertFoodPhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertLodgingPhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertRestaurantshotos(IFormFile photo);
        public Task<ImageUploadResult> InsertTransportPhotos(IFormFile photo);

        public Task<ImageUploadResult> InsertTransportExperiencePhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertFoodExperiencePhotos(IFormFile photo);
        public Task<ImageUploadResult> InsertLodgingExperiencePhotos(IFormFile photo);

        public Task<Photo> InsertPhoto(Photo entity);
        public Task<Photo> DeletePic(Guid id);
        public Task<Photo> FindPicById(Guid id);

        //
        public Task<PhotosExperience> InsertExperiencePhoto(PhotosExperience entity);
        public Task<PhotosExperience> DeleteExperiencePic(Guid id);
        public Task<PhotosExperience> FindExperiencePicById(Guid id);
        public Task<PhotosActivity> InsertActivityPhoto(PhotosActivity entity);
        public Task<PhotosActivity> DeleteActivityPic(Guid id);
        public Task<PhotosActivity> FindActivityPicById(Guid id);
        public Task<PhotosLodgingsExp> InsertLodgingExpPhoto(PhotosLodgingsExp entity);
        public Task<PhotosLodgingsExp> DeleteLodgingExpPic(Guid id);
        public Task<PhotosLodgingsExp> FindLodgingExpPicById(Guid id);
        public Task<PhotosFoodExp> InsertFoodExpPicPhoto(PhotosFoodExp entity);
        public Task<PhotosFoodExp> DeleteFoodExpPicPic(Guid id);
        public Task<PhotosFoodExp> FindFoodExpPicById(Guid id);
        public Task<PhotosTransportsExp> InsertTransportExpPhoto(PhotosTransportsExp entity);
        public Task<PhotosTransportsExp> DeleteTransportExpPic(Guid id);
        public Task<PhotosTransportsExp> FindTransportExpPicById(Guid id);
        public Task<PhotosLodgings> InsertLodgingPhoto(PhotosLodgings entity);
        public Task<PhotosLodgings> DeleteLodgingPic(Guid id);
        public Task<PhotosLodgings> FindLodgingPicById(Guid id);
        public Task<PhotosTransports> InsertTransportPhoto(PhotosTransports entity);
        public Task<PhotosTransports> DeleteTransportPic(Guid id);
        public Task<PhotosTransports> FindTransportPicById(Guid id);
        public Task<PhotosFood> InsertFoodPhoto(PhotosFood entity);
        public Task<PhotosFood> DeleteFoodPic(Guid id);
        public Task<PhotosFood> FindFoodPicById(Guid id);
        public Task<PhotosRestaurants> InsertRestaurantPhoto(PhotosRestaurants entity);
        public Task<PhotosRestaurants> DeleteRestaurantPic(Guid id);
        public Task<PhotosRestaurants> FindRestaurantPicById(Guid id);


    }
}
