namespace Web.Models
{
	public class PaginationInfoViewModal
	{
		public int PageId { get; set; }
		public int TotalItems { get; set; }
		public int ItemsOnPage { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalItems / Constance.ITEM_PER_PAGE);
		public bool HasPrevious => PageId > 1;
		public bool HasNext => PageId < TotalPages;
		public int RageStart => (PageId - 1) * Constance.ITEM_PER_PAGE + 1;
		public int RageEnd => RageStart + ItemsOnPage -1;
	}
}
