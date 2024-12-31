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
    public  class UserDraftManager :IUserDraftService
    {
        IUserDraftDal _userDraftDal;

        public UserDraftManager(IUserDraftDal userDraftDal)
        {
            _userDraftDal = userDraftDal;
        }

        public List<UserDraft> Getlist()
        {
            throw new NotImplementedException();
        }

        public void TAdd(UserDraft t)
        {
            _userDraftDal.Insert(t);
        }

        public void TDelete(UserDraft t)
        {
            _userDraftDal.Delete(t);
        }

        public UserDraft TGetById(int id)
        {
            return _userDraftDal.GetByID(id);
        }

        public List<UserDraft> GetUserDraftByUserId(int id)
        {
            return _userDraftDal.GetListAll(x => x.UserId == id);
        }

        public void TUpdate(UserDraft t)
        {
            throw new NotImplementedException();
        }
    }
}
