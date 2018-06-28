using AutoMapper;
using eDoc.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers.Base
{
    public abstract class ControllerBase : Controller
    {
        private IMapper _mapper;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    _mapper = DependencyResolver.Current.GetService<IMapper>();
                return _mapper;
            }
        }

        private DbUnitOfWork _uow;
        protected DbUnitOfWork UnitOfWork
        {
            get
            {
                if (_uow == null)
                    _uow = DependencyResolver.Current.GetService<DbUnitOfWork>();
                return _uow;
            }
        }
    }
}