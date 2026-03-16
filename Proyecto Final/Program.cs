

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
        case "6":
            Console.WriteLine("Saliendo del sistema. ¡Gracias por usar La Tiendita!");
            return;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
}
