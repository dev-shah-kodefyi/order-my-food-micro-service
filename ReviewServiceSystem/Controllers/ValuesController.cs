using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewServiceSystem.Models;
using ReviewServiceSystem.ReviewBLL.Repositories;

namespace ReviewServiceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IReviewBusiness _reviewBusiness;

        public ValuesController(IReviewBusiness reviewBusiness)
        {
            _reviewBusiness = reviewBusiness;
        }
        [Route("Save")]
        public ActionResult Save(TblReview tblReview)
        {
            _reviewBusiness.Save(tblReview);
            return Ok();
        }
        [Route("ViewReview")]
        public ActionResult ViewReview()
        {
            List<TblReview> tblReviews = _reviewBusiness.ViewReview();
            return Ok(tblReviews);
        }
    }
}
