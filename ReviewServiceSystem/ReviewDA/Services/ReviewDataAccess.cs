using ReviewServiceSystem.Models;
using ReviewServiceSystem.ReviewDA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewServiceSystem.ReviewDA.Services
{
    public class ReviewDataAccess : IReviewDataAccess
    {
        ReviewDbContext ReviewDbContext = new ReviewDbContext();
        public void Save(TblReview tblReview)
        {
            ReviewDbContext.TblReview.Add(tblReview);
            ReviewDbContext.SaveChanges();
        }

        public List<TblReview> ViewReview()
        {
            List<TblReview> res = ReviewDbContext.TblReview.ToList();
            return res;
        }
    }
}
