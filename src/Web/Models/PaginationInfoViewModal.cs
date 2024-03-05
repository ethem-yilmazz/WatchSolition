﻿namespace Web.Models
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
		public int[] PageNumber => Pagination(PageId, TotalPages);



        // https://gist.github.com/yigith/c6f999788b833dc3d22ac6332a053dd1
        private int[] Pagination(int current, int last)
		{
			int delta = 2;
			int left = current - delta;
			int right = current + delta + 1;
			var range = new List<int>();
			var rangeWithDots = new List<int>();
			int? l = null;

			for (var i = 1; i <= last; i++)
			{
				if (i == 1 || i == last || i >= left && i < right)
				{
					range.Add(i);
				}
			}

			foreach (var i in range)
			{
				if (l != null)
				{
					if (i - l == 2)
					{
						rangeWithDots.Add(l.Value + 1);
					}
					else if (i - l != 1)
					{
						rangeWithDots.Add(-1);
					}
				}
				rangeWithDots.Add(i);
				l = i;
			}

			return rangeWithDots.ToArray();
		}
	}
}
