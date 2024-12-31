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
    public  class Message2Manager:IMessage2Service
    {
        IMessage2Dal _Message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _Message2Dal = message2Dal;
        }


        public List<Message2> GetInBoxListByWriter(int id)
        {
            return _Message2Dal.GetInboxListWithMessageByWriter(id);

        }

        public List<Message2> Getlist()
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            return _Message2Dal.GetSendBoxListWithMessageByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _Message2Dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            return _Message2Dal.GetByID(id);
        }

        public void TUpdate(Message2 t)
        {
            _Message2Dal.Update(t);
        }
    }
}
