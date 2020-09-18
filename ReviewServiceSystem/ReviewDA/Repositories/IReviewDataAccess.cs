using ReviewServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewServiceSystem.ReviewDA.Repositories
{
    public interface IReviewDataAccess
    {
        List<TblReview> ViewReview();
        void Save(TblReview tblReview);
    }
}
