//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>
{
    new Product
    {
        Name = "Vintage Brass Door Knocker",
        Price = 89.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Polished Brass Candlesticks (Set of 2)",
        Price = 45.50m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Decorative Brass Compass",
        Price = 29.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Collected Works of Emily Dickinson (Leather-bound)",
        Price = 75.00m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Modern Love: Contemporary Poems Collection",
        Price = 19.99m,
        ProductTypeId = 2,
    },
};

List<ProductType> productTypes = new List<ProductType>
{
    new ProductType { Title = "Brass", Id = 1 },
    new ProductType { Title = "Poem", Id = 2 },
};

string greeting = "*** Brass & Poems***";
Console.WriteLine(greeting);

//implement your loop here
string choice = null;
while (choice != "5")
{
    Console.WriteLine("Please Enter In A Number From Menu Option");
    DisplayMenu();

    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("All Products");
            DisplayAllProducts(products, productTypes);
            Console.ReadLine();
            break;

        case "2":
            Console.WriteLine("Enter in the number for the product you wish to delete");
            DeleteProduct(products, productTypes);
            break;

        case "3":
            AddProduct(products, productTypes);
            break;

        case "4":
            UpdateProduct(products, productTypes);
            break;

        case "5":
            Console.WriteLine("EXITING...");
            break;
    }
    ;
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(
            $"{i + 1}. Name = {products[i].Name}, Price = {products[i].Price}, Title = {productTypes.FirstOrDefault(type => type.Id == products[i].ProductTypeId).Title}"
        );
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(
            $"{i + 1}. Name = {products[i].Name}, Price = {products[i].Price}, ProductTypeId = {products[i].ProductTypeId}"
        );
    }

    int choice = int.Parse(Console.ReadLine());
    if (choice > 0 && choice <= products.Count)
    {
        products.RemoveAt(choice - 1);
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please Enter In Your Product's Name");
    string Name = Console.ReadLine();

    Console.WriteLine("Please Enter In Your Products Price:");
    decimal Price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Please Enter In the Number that respresents the product type:");
    foreach (var type in productTypes)
    {
        Console.WriteLine($"{type.Id}. {type.Title}");
    }
    int typeChoice = int.Parse(Console.ReadLine());

    Product newProduct = new Product()
    {
        Name = Name,
        Price = Price,
        ProductTypeId = typeChoice,
    };

    products.Add(newProduct);

    Console.WriteLine("Added!");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please enter in the number of the Product you wish to edit");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    int choice = int.Parse(Console.ReadLine()) - 1;
    if (choice >= 0 && choice < products.Count)
    {
        Console.WriteLine("Please enter in the Products updated name:");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            products[choice].Name = newName;
        }

        Console.WriteLine("Please enter in the Products updated Price (00.00 format):");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice))
        {
            products[choice].Price = decimal.Parse(newPrice);
        }

        Console.WriteLine("Please Enter In the Number that respresents the product type:");
        foreach (var type in productTypes)
        {
            Console.WriteLine($"{type.Id}. {type.Title}");
        }
        string typeChoice = Console.ReadLine();
        if (!string.IsNullOrEmpty(typeChoice))
        {
            int newType = int.Parse(typeChoice);
            products[choice].ProductTypeId = newType;
        }
    }
    Console.WriteLine("Updated!");
}

// don't move or change this!
public partial class Program { }
