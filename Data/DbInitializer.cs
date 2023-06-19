using EcommerceClothing.Models;
using System.Linq.Expressions;

namespace EcommerceClothing.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            var products = new Product[]
            {
                //T-Shirts
                new Product {Name="Crew Neck Short-Sleeve T-Shirt",Img= "",Price=9.90},
                
                //Casual Shirts
                new Product {Name="Open Collar Short-Sleeve Shirt",Img= "",Price=39.90},
                
                //Dress Shirts
                new Product {Name="Care Stretch Slim-Fit Long-Sleeve Shirt",Img= "",Price=19.90 },
                
                //Ankle Pants
                new Product {Name="Smart Ankle Pants",Img="",Price=49.90},
                
                //Cargo pants
                new Product {Name="Cargo Pants",Img="",Price=39.90}

            };
            context.Products.AddRange(products);
            context.SaveChanges();
            ////////////////////////////////////////////////////////
            ///
           
            var colors = new Color[]
            {
                new Color {Name = "Black"},
                new Color {Name = "White"},
                new Color {Name = "Brown"},
                new Color {Name = "Blue"},
                new Color {Name = "Beige"},
                new Color {Name = "Grey"}
            };

            context.Colors.AddRange(colors);
            context.SaveChanges();

            var sizes = new Size[]
            {
                new Size {Name = "Small"},
                new Size {Name = "Medium"},
                new Size {Name = "Large"},
                new Size {Name = "Xtra Large"}

            };
            context.Sizes.AddRange(sizes);
            context.SaveChanges();

            var availableProducts = new AvailableProduct[]
           {
                new AvailableProduct {ProductId = 1,ColorID = 1, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 1,ColorID = 1, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 1,ColorID = 1, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 1,ColorID = 6, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 1,ColorID = 6, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 1,ColorID = 6, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 1, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 1, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 1, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 4, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 4, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 2,ColorID = 4, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 4, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 4, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 4, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 5, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 5, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 5, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 3, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 3, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 4,ColorID = 3, SizeID = 3, Quantity = 10},
                new AvailableProduct {ProductId = 5,ColorID = 6, SizeID = 1, Quantity = 10},
                new AvailableProduct {ProductId = 5,ColorID = 6, SizeID = 2, Quantity = 10},
                new AvailableProduct {ProductId = 5,ColorID = 6, SizeID = 3, Quantity = 10}

           };
            context.AvailableProducts.AddRange(availableProducts);
            context.SaveChanges();


            //////////////////////////////////////////////////////
            var categories = new Category[]
            {
                new Category {CategoryName="T-Shirts"},
                new Category {CategoryName="Casual Shirts"},
                new Category {CategoryName="Dress Shirts"},
                new Category {CategoryName="Ankle Pants"},
                new Category {CategoryName="Cargo Pants"}
                
            };
            context.Categories.AddRange(categories); 
            context.SaveChanges();

            var prodCategories = new ProductCategory[]
            {
                new ProductCategory {CategoryID=1, ProductID=1},
                new ProductCategory {CategoryID=2, ProductID=2},
                new ProductCategory {CategoryID=3, ProductID=3},
                new ProductCategory {CategoryID=4, ProductID=4},
                new ProductCategory {CategoryID=5, ProductID=5}
              
            };
            context.ProductCategories.AddRange(prodCategories);
            context.SaveChanges();

        }
     }
}
