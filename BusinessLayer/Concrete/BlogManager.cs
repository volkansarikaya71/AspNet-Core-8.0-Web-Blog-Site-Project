using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog TGetById(int id)
		{
			return _blogDal.GetByID(id);
		}
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
			return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> Getlist()
		{
			return _blogDal.GetListAll();
		}
		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().OrderByDescending(x => x.BlogId).Take(3).ToList();
		}
        public Blog GetLastBlog()
        {
            return _blogDal.GetListAll().OrderByDescending(x => x.BlogId).FirstOrDefault();
        }

        public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.BlogId == id);
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterId == id).Take(3).ToList(); 
		}

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
			_blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
        public List<Blog> GetLast10Blog(int id)
        {
            return _blogDal.GetListWithCategory().Where(x => x.WriterId == id && x.BlogStatus==true).OrderByDescending(x => x.BlogId).Take(10).ToList();
        }

        public List<Blog> GetListWithCategoryid(int id)
		{
			return _blogDal.GetListWithCategoryid(id);
		}
	}
}
