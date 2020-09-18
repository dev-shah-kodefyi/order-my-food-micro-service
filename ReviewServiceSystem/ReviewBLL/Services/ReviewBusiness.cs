using ReviewServiceSystem.Models;
using ReviewServiceSystem.ReviewBLL.Repositories;
using ReviewServiceSystem.ReviewDA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewServiceSystem.ReviewBLL.Services
{
    public class ReviewBusiness : IReviewBusiness
    {
        private readonly IReviewDataAccess _reviewDataAccess;

        public ReviewBusiness(IReviewDataAccess reviewDataAccess)
        {
            _reviewDataAccess = reviewDataAccess;
        }
        public void Save(TblReview tblReview)
        {
            _reviewDataAccess.Save(tblReview);
        }

        public List<TblReview> ViewReview()
        {
            return _reviewDataAccess.ViewReview();
        }
    }
}
