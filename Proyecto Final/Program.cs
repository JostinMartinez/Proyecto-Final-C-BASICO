const int maxProducts = 100;
string[] productNames = new string[maxProducts];
double[] productPrices = new double[maxProducts];
int[] productStocks = new int[maxProducts];
int productCount = 0;

void MostrarMenu()
{
    Console.WriteLine("\n--- La Tiendita ---");
    Console.WriteLine("1. Registrar Producto");
    Console.WriteLine("2. Listar Productos");
    Console.WriteLine("3. Actualizar Stock");
    Console.WriteLine("4. Eliminar Producto");
    Console.WriteLine("5. Generar Factura");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");
}

void RegistrarProducto()
{
    if (productCount >= maxProducts)
    {
        Console.WriteLine("Inventario lleno. No se pueden agregar más productos.");
        return;
    }

    Console.Write("Ingrese el nombre del producto: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("El nombre del producto no puede estar vacío.");
        return;
    }

    Console.Write("Ingrese el precio del producto: ");
    if (!double.TryParse(Console.ReadLine(), out double price))
    {
        Console.WriteLine("Precio inválido.");
        return;
    }

    Console.Write("Ingrese la cantidad en stock: ");
    if (!int.TryParse(Console.ReadLine(), out int stock))
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    productNames[productCount] = name;
    productPrices[productCount] = price;
    productStocks[productCount] = stock;
    productCount++;

    Console.WriteLine("Producto registrado exitosamente.");
}

void ListarProductos()
{
    Console.WriteLine("\n--- Inventario ---");
    for (int i = 0; i < productCount; i++)
    {
        Console.WriteLine($"{i + 1}. {productNames[i]} - Precio: {productPrices[i]:C} - Stock: {productStocks[i]}");
    }
}

void ActualizarStock()
{
    Console.Write("Ingrese el nombre del producto a actualizar: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("El nombre del producto no puede estar vacío.");
        return;
    }

    int index = Array.IndexOf(productNames, name);
    if (index == -1)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    Console.Write("Ingrese la nueva cantidad en stock: ");
    if (!int.TryParse(Console.ReadLine(), out int newStock))
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }

    productStocks[index] = newStock;
    Console.WriteLine("Stock actualizado exitosamente.");
}

void EliminarProducto()
{
    Console.Write("Ingrese el nombre del producto a eliminar: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("El nombre del producto no puede estar vacío.");
        return;
    }

    int index = Array.IndexOf(productNames, name);
    if (index == -1)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    for (int i = index; i < productCount - 1; i++)
    {
        productNames[i] = productNames[i + 1];
        productPrices[i] = productPrices[i + 1];
        productStocks[i] = productStocks[i + 1];
    }

    productCount--;
    Console.WriteLine("Producto eliminado exitosamente.");
}

void GenerarFactura()
{
    Console.WriteLine("\n--- Generar Factura ---");
    double total = 0;

    while (true)
    {
        Console.Write("Ingrese el nombre del producto (o 'fin' para terminar): ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name) || name.ToLower() == "fin")
        {
            break;
        }

        int index = Array.IndexOf(productNames, name);
        if (index == -1)
        {
            Console.WriteLine("Producto no encontrado.");
            continue;
        }

        Console.Write("Ingrese la cantidad a comprar: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Cantidad inválida.");
            continue;
        }

        if (quantity > productStocks[index])
        {
            Console.WriteLine("Stock insuficiente.");
            continue;
        }

        double subtotal = quantity * productPrices[index];
        total += subtotal;
        productStocks[index] -= quantity;

        Console.WriteLine($"{productNames[index]} x{quantity} - Subtotal: {subtotal:C}");
    }

    Console.WriteLine($"\nTotal a pagar: {total:C}");
}

while (true)
{
    MostrarMenu();
    string? opcion = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(opcion))
    {
        Console.WriteLine("Opción inválida. Intente de nuevo.");
        continue;
    }

    switch (opcion)
    {
        case "1":
            RegistrarProducto();
            break;
        case "2":
            ListarProductos();
            break;
        case "3":
            ActualizarStock();
            break;
        case "4":
            EliminarProducto();
            break;
        case "5":
            GenerarFactura();
            break;
        case "6":
            Console.WriteLine("Saliendo del sistema. ¡Gracias por usar La Tiendita!");
            return;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
}
