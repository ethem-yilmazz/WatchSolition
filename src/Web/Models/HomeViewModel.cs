﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models
{
	public class HomeViewModel
	{
        public List<CatalogItemViewModel> CatalogItems { get; set; } = new();
        public List<SelectListItem> Brands { get; set; } = new();
        public List<SelectListItem> Categories { get; set; } = new();
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public PaginationInfoViewModal PaginationInfo { get; set; } = null!;




    }
}
