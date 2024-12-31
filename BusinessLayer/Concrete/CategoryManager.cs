﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> Getlist()
        {
            return _categoryDal.GetListAll().Where(x => x.CategoryStatus == true).ToList();
        }
        public List<Category> GetlistAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
        public List<Category> GetLast10Category()
        {
            return _categoryDal.GetListAll().Take(10).ToList();
        }
    }
}