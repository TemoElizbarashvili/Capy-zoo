﻿using KapyZoo.DAL.Context;
using KapyZoo.DAL.Repositories.IRepository;
using KapyZoo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapyZoo.DAL.Repositories
{
    public class GalleryPicturesRepository : IGalleryPicturesRepository
    {
        private ZooDbContext _db;

        public GalleryPicturesRepository(ZooDbContext db)
        {
            _db = db;
        }

        public Task CreateGalleryPicture(GalleryPicture galleryPicture)
        {
            _db.GalleryPictures.Add(galleryPicture);

            _db.SaveChanges();

            return Task.CompletedTask;
        }

        public Task DeleteGalleryPicture(int id)
        {
            var objToRemove = _db.GalleryPictures.Where(galleryPicture => galleryPicture.GalleryPictureId == id).FirstOrDefault();
            _db.GalleryPictures.Remove(objToRemove);
            _db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditGalleryPicture(GalleryPicture galleryPicture)
        {
            var itemToUpdate = _db.GalleryPictures.FirstOrDefault(gp => gp.GalleryPictureId == galleryPicture.GalleryPictureId);
            itemToUpdate.Title = galleryPicture.Title;
            itemToUpdate.Picture = galleryPicture.Picture;
            return Task.CompletedTask;
        }

        public async Task<GalleryPicture> GetByIdAsync(int id)
        {
            return await Task.FromResult(_db.GalleryPictures.Where(gp => gp.GalleryPictureId == id).FirstOrDefault());
        }

        public IQueryable<GalleryPicture> List()
        {
            return _db.GalleryPictures;
        }
    }
}
