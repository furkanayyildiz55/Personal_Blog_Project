﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;


namespace DataAccesLayer.EntityFramework
{
    public class EfSocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaDal
    {
    }
}
