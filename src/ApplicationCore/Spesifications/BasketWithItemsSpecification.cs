﻿using ApplicationCore.Constants.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Spesifications
{
	public class BasketWithItemsSpecification : Specification<Basket>
	{
		public BasketWithItemsSpecification(string buyerId)
		{
			Query.Where(x => x.BuyerId == buyerId)
				.Include(x => x.BasketItems)
				.ThenInclude(x => x.Product);
		}
	}
}