using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public class StorageMaster
    {
        public StorageMaster()
        {
            this.productPool = new List<Product>();
            this.storages = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.currentVehicle = null;
        }

        private List<Product> productPool;
        private List<Storage> storages;
        private Vehicle currentVehicle;

        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;

        public string AddProduct(string type, double price)
        {
            this.productPool.Add(productFactory.CreateProduct(type, price));
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            this.storages.Add(storageFactory.CreateStorage(type, name));
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.currentVehicle = this.storages.FirstOrDefault(a => a.Name == storageName).GetVehicle(garageSlot);
            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            var productCount = productNames.Count();
            foreach (var productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }
                var currentProduct = this.productPool.LastOrDefault(a => a.GetType().Name == productName);
                if (currentProduct == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                this.productPool.Remove(currentProduct);
                this.currentVehicle.LoadProduct(currentProduct);
                loadedProductsCount++;
            }
            return $"Loaded {loadedProductsCount}/{productCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourseStorage = this.storages.FirstOrDefault(a => a.Name == sourceName);
            if (sourseStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            var destinationStorage = this.storages.FirstOrDefault(a => a.Name == destinationName);
            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            var slot = sourseStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            return $"Sent {destinationStorage.GetVehicle(slot).GetType().Name} to {destinationName} (slot {slot})";
        } 

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storages.FirstOrDefault(a => a.Name == storageName);
            var vehile = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehile.Trunk.Count();
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var builder = new StringBuilder();
            var currentStorage = this.storages.FirstOrDefault(a => a.Name == storageName);
            var products = new List<string>();
            foreach (var product in currentStorage.Products.GroupBy(a => a.GetType().Name).OrderByDescending(a => a.Count()).ThenBy(a => a.Key))
            {
                products.Add($"{product.Key} ({product.Count()})");
            }
            builder.AppendLine($"Stock ({currentStorage.GetSumProductWeight()}/{currentStorage.Capacity}): [{string.Join(", ", products)}]");
            builder.AppendLine($"Garage: [{currentStorage.GetGaragesPrint()}]");
            return builder.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var builder = new StringBuilder();
            foreach (var storage in this.storages.OrderByDescending(a => a.Products.Sum(b => b.Price)))
            {
                builder.AppendLine($"{storage.Name}:")
                    .AppendLine($"Storage worth: ${storage.Products.Sum(a => a.Price):F2}");
            }
            return builder.ToString().TrimEnd();
        }
    }
}