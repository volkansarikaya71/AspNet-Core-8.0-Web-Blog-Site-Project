﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
		void CommentAdd(Comment comment);

		void CommentDelete(Comment comment);

		void CommentUpdate(Comment comment);

		List<Comment> Getlist(int id);

        List<Comment> GetCommentWithBlog();

        Comment GetById(int id);

        List<Comment> GetCommentWithBlogByWriter(int id);
    }
}
