using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Infrastructure;
using Shop.BLL.Services;
using Shop.BLL.VMs;

namespace Shop
{
    public class ConsoleHelper
    {
        private BuyerService buyerService;
        private ManagerService managerService;
        private ProductService productService;
        private ShoppingCartItemService shoppingCartItemService;
        private OrderService orderService;

        public ConsoleHelper()
        {
            buyerService = new BuyerService();
            managerService = new ManagerService();
            productService = new ProductService();
            shoppingCartItemService = new ShoppingCartItemService();
            orderService = new OrderService();
        }

        public void ShowMainPage()
        {
            const string InviteCode = "987654";
            bool rightAnswer = false;
            Console.WriteLine("Добро пожаловать в мой магаз ಠoಠ!");
            while (rightAnswer == false)
            {
                Console.WriteLine("Нажмите:");
                Console.WriteLine("1 - Войти");
                Console.WriteLine("2 - Регистрация");
                Console.WriteLine("3 - Выйти");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            Console.Write("Введите инвайт-код: ");
                            string code = Console.ReadLine();

                            if (code == InviteCode) { LoginManager(); }

                            else { LoginBuyer(); }
                            break;
                        }
                    case "2":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            Console.Write("Введите инвайт-код: ");
                            string code = Console.ReadLine();

                            if (code == InviteCode) { RegisterManager(); }

                            else { RegisterBuyer(); }
                            break;
                        }
                    case "3":
                        {
                            rightAnswer = true;
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный ответ. Попробуйте снова.");
                            Console.Beep();
                            break;
                        }
                }
            }
            ShowMainPage();
        }
        public void RegisterBuyer()
        {
            var buyer = new BuyerVM();

            Console.Write("Введиите логин: ");
            buyer.Login = Console.ReadLine();
            Console.Write("Введиите пароль: ");
            buyer.PasswordHash = Console.ReadLine().GetHashCode().ToString();
            Console.Write("Введиите имя: ");
            buyer.Name = Console.ReadLine();
            Console.Write("Введиите фамилию: ");
            buyer.Surname = Console.ReadLine();
            Console.Write("Введиите номер телефона: ");
            buyer.PhoneNumber = Console.ReadLine();
            Console.Write("Введиите адрес: ");
            buyer.Adress = Console.ReadLine();
            Console.Write("Введиите дату рождения: ");
            buyer.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Clear();

            if (buyerService.RegistNewBuyer(buyer)) { Console.WriteLine("Регистрация прошла успешно."); }
            else { Console.WriteLine("Произошла ошибка при регистрации. Попробуйте снова"); }
        }
        public void LoginBuyer()
        {
            var buyer = new BuyerVM();

            Console.Write("Введиите логин: ");
            buyer.Login = Console.ReadLine();
            Console.Write("Введиите пароль: ");
            buyer.PasswordHash = Console.ReadLine().GetHashCode().ToString();
            Console.Clear();

            bool isBuyerExist = buyerService.LogInBuyer(buyer.Login, buyer.PasswordHash);

            if (isBuyerExist)
            {
                Console.Clear();
                ShowBuyerMenu();
            }
            else
            {
                Console.WriteLine("Неверные данные. Попробуйте снова!");
                ShowMainPage();
            }

        }
        public void ShowBuyerMenu()
        {
            bool rightAnswer = false;
            while (rightAnswer == false)
            {
                Console.WriteLine($"{CurrentUser.Surname} {CurrentUser.Name} добро пожаловать в мой магаз ಠoಠ!");
                Console.WriteLine("Нажмите:");
                Console.WriteLine("1 - Показать товары в магазине.");
                Console.WriteLine("2 - Показать заказы");
                Console.WriteLine("3 - Выйти из аккаунта");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowProducts();
                            break;
                        }
                    case "2":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowOrders();
                            break;
                        }
                    case "3":
                        {
                            CurrentUser.Id = Guid.Empty;
                            CurrentUser.Name = null;
                            CurrentUser.Surname = null;
                            CurrentUser.Role = null;
                            ShowMainPage();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный ответ. Попробуйте снова.");
                            Console.Beep();
                            break;
                        }
                }
            }

        }
        public void ShowProducts()
        {
            bool rightAnswer = false;
            Console.Clear();
            var products = productService.GetProductListFromShop();
            foreach (var product in products)
            {
                Console.WriteLine($"\n{product.Id}\n {product.Name} - {product.Price}");
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 - Вернуться в главное меню.");
            Console.WriteLine("ID - Показать продукт");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    {
                        rightAnswer = true;
                        Console.Clear();
                        ShowMainPage();
                        break;
                    }
                default:
                    {
                        if (CurrentUser.Role == "покупатель") { OpenProductAsBuyer(answer); }
                        else OpenProductAsManager(answer);
                        break;
                    }
            }

        }
        public void OpenProductAsBuyer(string id)
        {
            bool rightAnswer = false;
            while (rightAnswer == false)
            {
                Console.Clear();
                var product = productService.GetProductById(System.Guid.Parse(id));
                CurrentProduct.Id = product.Id;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"{product.Name} \t {product.Price}$ \tОсталось: {product.Amount}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"{product.Description}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("\nНажмите:");
                Console.WriteLine("1 - Положить продукт в корзину.");
                Console.WriteLine("2 - Вернуться к списку продуктов.");
                Console.WriteLine("3 - Вернуться на главную страницу");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            AddProductToCart(); //!!!!!!!!!!!!!!
                            break;
                        }
                    case "2":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowProducts();
                            break;
                        }
                    case "3":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowBuyerMenu();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный ответ. Попробуйте снова.");
                            Console.Beep();
                            break;
                        }
                }
            }

        }
        public void AddProductToCart()
        {

            try
            {
                var shoppingCartItem = new ShoppingCartItemVM();
                shoppingCartItem.ProductId = CurrentProduct.Id;
                Console.WriteLine("Введите количество: ");
                shoppingCartItem.Count = Int32.Parse(Console.ReadLine());
                shoppingCartItemService.CreateNewShoppingCartItem(shoppingCartItem.ProductId, shoppingCartItem.Count);
                Console.WriteLine("Продукт успешно добавлен в корзину");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка добавления продукта!");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nНажмите:");
            Console.WriteLine("1 - Вернуться к списку продуктов.");
            Console.WriteLine("2 - Вернуться на главную страницу");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            bool rightAnswer = false;
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    {
                        rightAnswer = true;
                        Console.Clear();
                        ShowProducts();
                        break;
                    }
                case "2":
                    {
                        rightAnswer = true;
                        Console.Clear();
                        ShowBuyerMenu();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный ответ. Попробуйте снова.");
                        Console.Beep();
                        break;
                    }
            }

        } //!!!!!!!!!!!
        public void ShowOrders()
        {
            bool rightAnswer = false;
            Console.Clear();
            var orders = orderService.GetOrdersListByUserId(CurrentUser.Id);
            foreach (var order in orders)
            {
                Console.WriteLine($"\n{order.CreationDate}\t{order.Id}");
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 - Вернуться в главное меню.");
            Console.WriteLine("ID - Посмотреть/Изменить заказ");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    {
                        rightAnswer = true;
                        Console.Clear();
                        ShowBuyerMenu();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        rightAnswer = true;
                        ShowOrderById(answer);
                        break;
                    }
            }

        }
        public void ShowOrderById(string id)
        {
            bool rightAnswer = false;
            Console.Clear();
            var orderItems = orderService.GetOrdersListByUserId(CurrentUser.Id);
            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"\n{orderItem.CreationDate}\t{orderItem.Id}");
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 - Вернуться в главное меню.");
            Console.WriteLine("ID - Посмотреть/Изменить заказ");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    {
                        rightAnswer = true;
                        Console.Clear();
                        ShowBuyerMenu();
                        break;
                    }
                default:
                    {
                        rightAnswer = true;
                        UpdateOrderById(Guid.Parse(answer));
                        break;
                    }
            }
        }
        public void UpdateOrderById(Guid id) //!!!!!!!!!!
        {
            ShowBuyerMenu();
        }
        // функционал менеджера
        public void RegisterManager()
        {
            var manager = new ManagerVM();

            Console.Write("Введиите логин: ");
            manager.Login = Console.ReadLine();
            Console.Write("Введиите пароль: ");
            manager.PasswordHash = Console.ReadLine().GetHashCode().ToString();
            Console.Write("Введиите имя: ");
            manager.Name = Console.ReadLine();
            Console.Write("Введиите фамилию: ");
            manager.Surname = Console.ReadLine();
            Console.Write("Введиите номер телефона: ");
            manager.PhoneNumber = Console.ReadLine();
            Console.Clear();

            if (managerService.RegistNewManager(manager)) { Console.WriteLine("Регистрация прошла успешно."); }
            else { Console.WriteLine("Произошла ошибка при регистрации. Попробуйте снова"); }

            ShowMainPage();
        }
        public void LoginManager()
        {
            var manager = new ManagerVM();

            Console.Write("Введиите логин: ");
            manager.Login = Console.ReadLine();
            Console.Write("Введиите пароль: ");
            manager.PasswordHash = Console.ReadLine().GetHashCode().ToString();
            Console.Clear();

            bool isManagerExist = managerService.LogInManager(manager.Login, manager.PasswordHash);

            if (isManagerExist)
            {
                Console.Clear();
                ShowManagerMenu();
            }
            else
            {
                Console.WriteLine("Неверные данные. Попробуйте снова!");
                ShowMainPage();
            }
        }
        public void ShowManagerMenu()
        {
            bool rightAnswer = false;
            while (rightAnswer == false)
            {
                Console.WriteLine($"{CurrentUser.Surname} {CurrentUser.Name} добро пожаловать в мой магаз ಠoಠ! \t Ты вошел как {CurrentUser.Role}");
                Console.WriteLine("Нажми:");
                Console.WriteLine("1 - Показать товары в магазине.");
                Console.WriteLine("2 - Показать товары в магазине.");
                Console.WriteLine("3 - Выйти из аккаунта");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowProducts();
                            break;
                        }
                    case "2":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            AddNewProduct();
                            break;
                        }
                    case "3":
                        {
                            CurrentUser.Id = Guid.Empty;
                            CurrentUser.Name = null;
                            CurrentUser.Surname = null;
                            CurrentUser.Role = null;
                            ShowMainPage();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный ответ. Попробуйте снова.");
                            Console.Beep();
                            break;
                        }
                }
            }
        }
        public void OpenProductAsManager(string id)
        {
            bool rightAnswer = false;
            while (rightAnswer == false)
            {
                Console.Clear();
                var product = productService.GetProductById(System.Guid.Parse(id));
                CurrentProduct.Id = product.Id;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"{product.Id}");
                Console.WriteLine($"{product.Name} \t {product.Price}$ \tОсталось: {product.Amount}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine($"{product.Description}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("\nНажмите:");
                Console.WriteLine("1 - Редактировать продукт");
                Console.WriteLine("2 - Удалить продукт");
                Console.WriteLine("3 - Вернуться к списку продуктов.");
                Console.WriteLine("4 - Вернуться на главную страницу");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                CurrentProduct.Name = product.Name;
                CurrentProduct.Description = product.Description;
                CurrentProduct.Amount = product.Amount;
                CurrentProduct.Price = product.Price;

                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            UpdateProduct();
                            break;
                        }
                    case "2":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            DeleteProduct();
                            break;
                        }
                    case "3":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowProducts();
                            break;
                        }
                    case "4":
                        {
                            rightAnswer = true;
                            Console.Clear();
                            ShowManagerMenu();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный ответ. Попробуйте снова.");
                            Console.Beep();
                            break;
                        }
                }
            }

        }
        public void UpdateProduct()
        {
            var product = new ProductVM();
            Console.WriteLine("Введите название продукта: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание продукта: ");
            var description = Console.ReadLine();
            Console.WriteLine("Введите количество продукта: ");
            int amount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену продукта: ");
            decimal price = Decimal.Parse(Console.ReadLine());
            productService.UpdateProduct(product);
            ShowProducts();
        } //!!!!!!!!!
        public void AddNewProduct()//!!!!!!!!!
        {
            var product = new ProductVM();
            Console.WriteLine("Введите название продукта: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание продукта: ");
            var description = Console.ReadLine();
            Console.WriteLine("Введите количество продукта: ");
            int amount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену продукта: ");
            decimal price = Decimal.Parse(Console.ReadLine());
            productService.CreateNewProduct(product);
            ShowManagerMenu();
        }
        public void DeleteProduct() //!!!!!!!!!
        {
            productService.DeleteProduct(CurrentProduct.Id);
            ShowProducts();
        }
    }
}

