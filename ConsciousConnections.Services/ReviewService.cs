using ConsciousConnections.Data;
using ConsciousConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    Id = _userId.ToString(),
                    Rating = model.Rating,
                    ReviewDescription = model.ReviewDescription,
                    CreatedUtc = DateTime.Now,
                    ProductId = model.ProductId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.Id == _userId.ToString())//e.Product.Id == _userId.ToString())   //review entity associated with product id equal to the userid associated with the company
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    Rating = e.Rating,
                                    CreatedUtc = DateTime.Now,
                                    ReviewDescription = e.ReviewDescription,
                                    // ProductId = e.ProductId, doesn't matter as much
                                    ProductName = e.Product.ProductName,
                                    Id = e.ApplicationUser.FullName
                                    
                                }
                        );
                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == id && e.Id == _userId.ToString()); //&& e.Id == _userId.ToString());
                // .Single(e => e.ReviewId == id && e.Product.Id == _userId.ToString());
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        Rating = entity.Rating,
                        ReviewDescription = entity.ReviewDescription,
                        CreatedUtc = DateTime.Now,
                        //ProductName - entity.Product.ProductName,
                        ModifiedUtc = entity.ModifiedUtc,
                   
              

                        //ProductId = entity.ProductId don't need?
                    };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.Id == _userId.ToString());
    

              //  entity.ReviewId = model.ReviewId;
                entity.Rating = model.Rating;
                entity.ReviewDescription = model.ReviewDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.Id == _userId.ToString());
                //.Single(e => e.ReviewId == reviewId && e.Product.Id == _userId.ToString());

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
