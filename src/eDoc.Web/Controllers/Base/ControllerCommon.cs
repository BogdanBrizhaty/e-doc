using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers.Base
{
    public class ControllerCommon : Controller
    {
        private IMapper _mapper = null;

        protected IMapper mapper
        {
            get
            {
                if (_mapper == null)
                    _mapper = DependencyResolver.Current.GetService<IMapper>();

                return _mapper;
            }
        }
    }
}