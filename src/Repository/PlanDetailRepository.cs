using System.Collections.Generic;
using src.Models;

namespace src.Repository
{
    public class PlanDetailRepository : IPlanDetailRepository
    {
        public bool BulkSaveAsync(List<PlanDetail> planDetails)
        {
            //db saveChangesAsync();
            return true;
        }

        public bool IsExists(int inventoryItemId)
        {
            //db.Get()
            return true;
        }
    }

    public interface IPlanDetailRepository
    {
        bool BulkSaveAsync(List<PlanDetail> planDetails);
        bool IsExists(int inventoryItemId);
    }
}