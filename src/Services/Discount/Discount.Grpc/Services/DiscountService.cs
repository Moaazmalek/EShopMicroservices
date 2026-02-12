using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            // TODO: Get Discount from database
            return base.GetDiscount(request, context);
        }
        public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            // TODO: Create Discount in database
            return base.CreateDiscount(request, context);
        }
        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            // TODO: Update Discount in database
            return base.UpdateDiscount(request, context);
        }
        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            // TODO: Delete Discount from database
            return base.DeleteDiscount(request, context);
        }


    }
}
