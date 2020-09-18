using ReviewServiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewServiceSystem.ReviewBLL.Repositories
{
    public interface IReviewBusiness
    {
        void Save(TblReview tblReview);
        List<TblReview> ViewReview();
    }
}
