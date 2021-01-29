using ConsciousConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Contracts
{
    public interface IReviewService
    {
        Guid UserId { get; set; }
        bool CreateReview(ReviewCreate model);
        IEnumerable<ReviewListItem> GetReviews();
        ReviewDetail GetReviewById(int id);
        bool UpdateReview(ReviewEdit model);
        bool DeleteReview(int reviewId);

    }
}
