namespace SuperMarketManagement.Models
{
	public class ProductsRepository
	{
		private static List<Product> _products = new List<Product>()
		{
			new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
			new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
			new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
			new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 },
			new Product { ProductId = 5, CategoryId = 1, Name = "Coca Cola", Quantity = 150, Price = 1.25 },
			new Product { ProductId = 6, CategoryId = 1, Name = "Orange Juice", Quantity = 80, Price = 2.49 },
			new Product { ProductId = 7, CategoryId = 2, Name = "Croissant", Quantity = 50, Price = 1.75 },
			new Product { ProductId = 8, CategoryId = 2, Name = "Chocolate Muffin", Quantity = 60, Price = 2.00 },
			new Product { ProductId = 9, CategoryId = 3, Name = "Beef Steak", Quantity = 40, Price = 14.99 },
			new Product { ProductId = 10, CategoryId = 3, Name = "Chicken Breast", Quantity = 85, Price = 7.99 },
			new Product { ProductId = 11, CategoryId = 3, Name = "Brazlian Beef", Quantity = 150, Price = 11.50 },
			new Product { ProductId = 12, CategoryId = 4, Name = "Fresh Tomatoes", Quantity = 120, Price = 0.99 },
			new Product { ProductId = 13, CategoryId = 4, Name = "Potatoes", Quantity = 200, Price = 0.75 },
			new Product { ProductId = 14, CategoryId = 4, Name = "Lettuce", Quantity = 45, Price = 1.10 },
			new Product { ProductId = 15, CategoryId = 1, Name = "Apple Juice", Quantity = 90, Price = 2.49 },
			new Product { ProductId = 16, CategoryId = 1, Name = "Mineral Water 500ml", Quantity = 500, Price = 0.50 },
			new Product { ProductId = 17, CategoryId = 1, Name = "Green Tea Box", Quantity = 120, Price = 3.99 },
			new Product { ProductId = 18, CategoryId = 1, Name = "Instant Coffee", Quantity = 75, Price = 5.49 },
			new Product { ProductId = 19, CategoryId = 1, Name = "Diet Soda", Quantity = 180, Price = 1.25 },
			new Product { ProductId = 20, CategoryId = 2, Name = "Garlic Bread", Quantity = 40, Price = 2.50 },
			new Product { ProductId = 21, CategoryId = 2, Name = "Apple Pie", Quantity = 25, Price = 4.99 },
			new Product { ProductId = 22, CategoryId = 2, Name = "Bagels 6-Pack", Quantity = 60, Price = 3.20 },
			new Product { ProductId = 23, CategoryId = 2, Name = "Pancake Mix", Quantity = 85, Price = 2.80 },
			new Product { ProductId = 24, CategoryId = 2, Name = "Chocolate Chip Cookies", Quantity = 110, Price = 3.50 },
			new Product { ProductId = 25, CategoryId = 3, Name = "Ground Beef", Quantity = 65, Price = 9.99 },
			new Product { ProductId = 26, CategoryId = 3, Name = "Lamb Chops", Quantity = 30, Price = 18.50 },
			new Product { ProductId = 27, CategoryId = 3, Name = "Chicken Wings", Quantity = 140, Price = 4.99 },
			new Product { ProductId = 28, CategoryId = 3, Name = "Turkey Breast", Quantity = 50, Price = 8.99 },
			new Product { ProductId = 29, CategoryId = 3, Name = "Salmon Fillet", Quantity = 35, Price = 16.99 },
			new Product { ProductId = 30, CategoryId = 4, Name = "Carrots", Quantity = 150, Price = 0.80 },
			new Product { ProductId = 31, CategoryId = 4, Name = "Onions 1kg Bag", Quantity = 250, Price = 1.20 },
			new Product { ProductId = 32, CategoryId = 4, Name = "Cucumbers", Quantity = 180, Price = 0.95 },
			new Product { ProductId = 33, CategoryId = 4, Name = "Broccoli", Quantity = 70, Price = 1.75 },
			new Product { ProductId = 34, CategoryId = 4, Name = "Red Bell Peppers", Quantity = 95, Price = 1.99 }
		};

		public static void AddProduct(Product product)
		{
			if (_products != null && _products.Count() > 0)
			{
				var maxId = _products.Max(x => x.ProductId);
				product.ProductId = maxId + 1;
			}
			else 
			{
				product.ProductId = 1;
			}
			if (_products == null) _products = new List<Product>();
			_products.Add(product);
		}

		public static List<Product> GetProducts(bool loadCategory = false) 
		{
			if (!loadCategory)
			{
				return _products;
			}
			else
			{
				if (_products != null && _products.Count() > 0)
				{
					_products.ForEach(x =>
					{
						if (x.CategoryId.HasValue)
						{
							x.Category = CategoriesRepository.GetCategoryById(x.CategoryId.Value);
						}
					});
				}

				return _products ?? new List<Product>();
			}
		}

		public static Product? GetProductById(int productId, bool loadCategory = false)
		{
			var product = _products.FirstOrDefault(x => x.ProductId == productId);
			if (product != null)
			{
				var prod =  new Product
				{
					ProductId = product.ProductId,
					Name = product.Name,
					Quantity = product.Quantity,
					Price = product.Price,
					CategoryId = product.CategoryId
				};

				if (loadCategory && prod.CategoryId.HasValue)
				{
					prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);
				}

				return prod;
			}

			return null;
		}

		public static void UpdateProduct(int productId, Product product)
		{
			if (productId != product.ProductId) return;

			var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
			if (productToUpdate != null)
			{
				productToUpdate.Name = product.Name;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.Price = product.Price;
				productToUpdate.CategoryId = product.CategoryId;
			}
		}

		public static void DeleteProduct(int productId)
		{
			var product = _products.FirstOrDefault(x => x.ProductId == productId);
			if (product != null)
			{
				_products.Remove(product);
			}
		}

		public static List<Product> GetProductsByCategoryId(int categoryId)
		{
			var products = _products.Where(x => x.CategoryId == categoryId);
			if (products != null)
			{
				return products.ToList();
			}
			else 
			{
				return new List<Product>();
			}
		}
	}
}
