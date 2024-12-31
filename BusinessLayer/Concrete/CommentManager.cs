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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentdal;

		public CommentManager(ICommentDal commentdal)
		{
			_commentdal = commentdal;
		}

		public void CommentAdd(Comment comment)
		{
			 _commentdal.Insert(comment);
		}

		public void CommentDelete(Comment comment)
		{
            _commentdal.Delete(comment);
        }

		public void CommentUpdate(Comment comment)
		{
			throw new NotImplementedException();
		}

		public Comment GetById(int id)
		{
            return _commentdal.GetByID(id);
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentdal.GetListWithBlog();
        }

        public List<Comment> GetCommentWithBlogByWriter(int id)
        {
			return _commentdal.GetListWithBlogByWriter(id);
        }

        public List<Comment> Getlist(int id)
		{
			return _commentdal.GetListAll(x => x.BlogId == id);
		}
	}
}
