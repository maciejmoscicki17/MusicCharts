using BusinessLogicLayer.Interfaces;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AlbumBLL : IAlbumBLL
    {
        private IUnitOfWork unitOfWork;

        public AlbumBLL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int IleAlbumow()
        {
            return this.unitOfWork.Albums.GetAll().Count();
        }

        public void DodajLosoweAlbumy(int x)
        {
            for(int i = 0; i < x; i++)
            {
                Album a = new Album();
                this.unitOfWork.Albums.Add(a);
                this.unitOfWork.Save();
            }
        }
    }
}
